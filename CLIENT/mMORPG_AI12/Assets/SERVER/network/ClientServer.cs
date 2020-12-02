using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

public class ClientServer
{
    public int id;
    private User user;
    public static int dataBufferSize = 32768;
    public TcpClient socket { get; set; }
    private BasePacket receivedData;
    private NetworkStream stream;
    private byte[] receiveBuffer;

    private GameServer s;
    public ClientServer(int _clientId, GameServer ps)
    {
        id = _clientId;
        s = ps;
    }

    public void Connect(TcpClient _socket)
    {
        socket = _socket;
        socket.ReceiveBufferSize = dataBufferSize;
        socket.SendBufferSize = dataBufferSize;
        receivedData = new BasePacket();
        stream = socket.GetStream();
        receiveBuffer = new byte[dataBufferSize];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Client " + id + " connected.", Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
        stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
    }

    public void SendData(Server.Network.Messages.Packet _packet)
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
            Console.WriteLine("Exception " + _ex);
            //Debug.Log($"Error sending data to server via TCP: {_ex}");
        }
    }

    private void ReceiveCallback(IAsyncResult _result)
    {
        try
        {
            int _byteLength = stream.EndRead(_result);
            if (_byteLength <= 0)
            {
                Console.WriteLine($"ReceiveCallback error. Bytelength < 0 ... Disconnecting client "+id);
                s.data.UserBrutalDisconnected(id.ToString());
                GameServer.clients[id].Disconnect();
                return;
            }

            byte[] _data = new byte[_byteLength];
            Array.Copy(receiveBuffer, _data, _byteLength);

            receivedData.Reset(HandleData(_data));
            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }
        catch (Exception _ex)
        {
            Console.WriteLine($"Error receiving TCP data: {_ex}");
            s.data.UserBrutalDisconnected(id.ToString());
            GameServer.clients[id].Disconnect();
        }
    }

    private bool HandleData(byte[] _data)
    {
        ThreadManager.ExecuteOnMainThread(() =>
        {
            BinaryFormatter bf = new BinaryFormatter();
            //bf.Binder = new CustomizedBinder();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Position = 0;
                ms.Write(_data, 0, _data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Packet res = (Packet)bf.Deserialize(ms);
                res.Handle(s);
            }
        });
        /*
        ThreadManager.ExecuteOnMainThread(() =>
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = new CustomizedBinder();
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(_data, 0, _data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                Packet obj = bf.Deserialize(ms) as Packet;
                obj.Handle(s);
                Console.WriteLine("Object handled");
            }

        });*/
        return true;

    }
    public void Disconnect()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Client " + id + " disconnected", Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
        socket.Close();
        stream = null;
        receiveBuffer = null;
        socket = null;
        receivedData = null;
    }
}
