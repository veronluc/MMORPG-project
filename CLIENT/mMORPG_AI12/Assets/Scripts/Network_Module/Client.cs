using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

public class Client
{
    public static int dataBufferSize = 4096;
    bool isConnected = false;

    public string ip = "127.0.0.1";
    public int port = 26950;
    public int myId = 0;

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
        ConnectToServer();
    }
    private void Start()
    {
#if UNITY_EDITOR
        ip = "127.0.0.1";
#endif
        //TESTS
        ConnectToServer();
    }
    private void Update()
    {
        try
        {
        }
        catch
        {

        }

    }
    private void OnApplicationQuit()
    {
        Disconnect();
    }
    public void ConnectToServer()
    {
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
                return;
            }

            byte[] _data = new byte[_byteLength];
            Array.Copy(receiveBuffer, _data, _byteLength);

            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }
        catch
        {
            Disconnect();
        }
    }

    private bool HandleData(byte[] _data)
    {
        ThreadManager.ExecuteOnMainThread(() =>
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = new CustomizedBinder();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(_data, 0, _data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Packet obj = (Packet)bf.Deserialize(ms);
                obj.Handle(this);
            }
        });
        return true;
    }
    private void Disconnect()
    {
        if (isConnected)
        {
            isConnected = false;
            socket.Close();
            //Debug.Log("Disconnected from server.");
        }
        stream = null;
        receiveBuffer = null;
        socket = null;
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
                    bf.Serialize(ms, _packet);
                    stream.BeginWrite(ms.ToArray(), 0, ms.ToArray().Length, null, null);
                }
            }
        }
        catch (Exception _ex)
        {
            Console.WriteLine("Exception " + _ex);
            //Debug.Log($"Error sending data to server via TCP: {_ex}");
        }
    }

    public void DebugIt(string mes)
    {
        //Debug.Log(mes);
    }
}