using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class Client
{
    private BasePacket receivedData;
    public static int dataBufferSize = 1048576;
    bool isConnected = false;

    public User currentUser { get; set; }


    public string ip = "127.0.0.1";
    public int port = 26950;

    public DataInterfaceForNetwork data;

    public TcpClient socket;

    private NetworkStream stream;
    private byte[] receiveBuffer;

    void UpdateLog(int id, string msg)
    {
        //Debug.Log("\n(" + id + ") sended : <i>" + msg + "</i>.");
        //Log.text += "OK";
    }

    public Client()
    {

    }


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


    //Packets
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

    public void DebugIt(string mes)
    {
        Debug.Log(mes.ToString());
    }
}