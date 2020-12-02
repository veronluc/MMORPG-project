using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

/// <summary>
/// Global client which manage the connection to the server and receive/send messages
/// </summary>
public class Client : MonoBehaviour
{
    /// <summary>
    /// Wrapper to read bytes
    /// </summary>
    private BasePacket receivedData;
    /// <summary>
    /// Data buffer size, can be changed 
    /// </summary>
    public static int dataBufferSize = 32768;

    /// <summary>
    /// Intern connection verification
    /// </summary>
    bool isConnected = false;

    /// <summary>
    /// Server adress ip
    /// </summary>
    public string ip = "127.0.0.1";

    /// <summary>
    /// Server Port
    /// </summary>
    public int port = 26950;

    /// <summary>
    /// Reference to the data implementation for packets
    /// </summary>
    public DataInterfaceForNetwork data;

    /// <summary>
    /// Current socket connected to the server
    /// </summary>
    public TcpClient socket;

    /// <summary>
    /// Stream used in the socket
    /// </summary>
    private NetworkStream stream;

    /// <summary>
    /// Buffer used to read messaged
    /// </summary>
    private byte[] receiveBuffer;
    /// <summary>
    /// Client constructor
    /// </summary>
    public Client()
    {
        
    }

    /// <summary>
    /// Connect the client to the server
    /// </summary>
    /// <param name="ipAdress">Server ip adress</param>
    /// <param name="pPort">Server opened port</param>
    public void ConnectToServer(string ipAdress, int pPort)
    {
        ip = ipAdress;
        port = pPort;

        isConnected = true;

        socket = new TcpClient
        {
            ReceiveBufferSize = dataBufferSize,
            SendBufferSize = dataBufferSize
        };

        receiveBuffer = new byte[dataBufferSize];
        socket.BeginConnect(ip, port, ConnectCallback, socket);
    }

    /// <summary>
    /// Method called by the socket when connection is established
    /// </summary>
    /// <param name="_result"><Result from the socket/param>
    private void ConnectCallback(IAsyncResult _result)
    {
        socket.EndConnect(_result);

        if (!socket.Connected)
        {
            return;
        }

        stream = socket.GetStream();
        receivedData = new BasePacket();
        stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
    }

    /// <summary>
    /// Method called by the socket when he received data
    /// </summary>
    /// <param name="_result">Data received by the socket</param>
    private void ReceiveCallback(IAsyncResult _result)
    {
        try
        {
            int _byteLength = stream.EndRead(_result);
            if (_byteLength <= 0)
            {
                Disconnect();
                data.DisconnectServerError();
                return;
            }

            byte[] _data = new byte[_byteLength];
            Array.Copy(receiveBuffer, _data, _byteLength);

            receivedData.Reset(HandleData(_data));
            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }
        catch (Exception e)
        {
            data.DisconnectServerError();
            Disconnect();
        }
    }

    /// <summary>
    /// Manage received data to a packet
    /// </summary>
    /// <param name="_data">Data received</param>
    /// <returns>Message correctly received</returns>
    private bool HandleData(byte[] _data)
    {
        //DebugIt("Handle data size : " + _data.Length);
        //ThreadManager.ExecuteOnMainThread(() =>{
        Dispatcher.RunOnMainThread(
            () => {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Position = 0;
                    ms.Write(_data, 0, _data.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    Packet res = (Packet)bf.Deserialize(ms);
                    res.Handle(this);
                }
            }
            );
        //});
        /*ThreadManager.ExecuteOnMainThread(() =>
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = new CustomizedBinder();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(_data, 0, _data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Packet obj = (Packet)bf.Deserialize(ms);
                obj.Handle(this);
                Console.WriteLine("Object handled");
            }

        });*/
        return true;
    }
    /// <summary>
    /// Disconnection from the server
    /// </summary>
    public void Disconnect()
    {
        if (isConnected)
        {
            isConnected = false;
            socket.Close();
            Debug.Log("Disconnected from server.");
        }
        stream = null;
        receiveBuffer = null;
        socket = null;
        receivedData = null;
    }


    /// <summary>
    /// Sends data (Packet) to the server in the socket
    /// </summary>
    /// <param name="_packet">The packet to send</param>
    public void SendData(Packet _packet)
    {
        try
        {
            if (socket != null)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Position = 0;
                    bf.Serialize(ms, _packet);
                    stream.BeginWrite(ms.ToArray(), 0, ms.ToArray().Length, null, null);
                }
                
            }
        }
        catch (Exception _ex)
        {
            DebugIt($"Error sending data to server via TCP: {_ex}");
        }
    }

    /// <summary>
    /// For debugging puropose only to debug on the console
    /// </summary>
    /// <param name="mes">The string message</param>
    public void DebugIt(string mes)
    {
        Debug.Log(mes.ToString());
    }
}