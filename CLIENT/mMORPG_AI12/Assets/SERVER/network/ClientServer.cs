using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// The class represent a client on the server side. It contains the socket and is used for the communication between the server and the client.
/// </summary>
public class ClientServer
{
    /// <summary>
    /// The id of the client on the server
    /// </summary>
    public int id;
    /// <summary>
    /// The connected user
    /// </summary>
    private User user;
    /// <summary>
    /// The size of the communication buffer (32768), size can be changed (client and server)
    /// </summary>
    public static int dataBufferSize = 4194304;
    /// <summary>
    /// The communication socket between the client and the server
    /// </summary>
    public TcpClient socket { get; set; }
    /// <summary>
    /// The class containing the data reception (wrapper for reading bytes)
    /// </summary>
    private BasePacket receivedData;
    /// <summary>
    /// Network stream to be used with the socket for communication (comes from the socket)
    /// </summary>
    private NetworkStream stream;
    /// <summary>
    /// The recieve buffer, used to read from the socket
    /// </summary>
    private byte[] receiveBuffer;
    /// <summary>
    /// The game server reference
    /// </summary>
    private GameServer s;

    /// <summary>
    /// Only constructor of the class
    /// </summary>
    /// <param name="_clientId">The id of the client</param>
    /// <param name="ps">The game server reference</param>
    public ClientServer(int _clientId, GameServer ps)
    {
        id = _clientId;
        s = ps;
    }

    /// <summary>
    /// Connect to the client and link the socket to the client
    /// </summary>
    /// <param name="_socket">The socket linking to the client</param>
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

    /// <summary>
    /// Method to send the data to the client
    /// It serialize the data into binary
    /// </summary>
    /// <param name="_packet">A specific packet</param>
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
        }
    }

    /// <summary>
    /// Is called when data is recieved on the socket (after each read we call this method, if data has been sent, it reads the data)
    /// </summary>
    /// <param name="_result">Result of the callback</param>
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

    /// <summary>
    /// Method that handle the behaviour of the recieved packet
    /// It executes this behavior on the main thread but recieves the packet on a specific thread
    /// </summary>
    /// <param name="_data">The data byte array</param>
    /// <returns>Return True if successful</returns>
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

    /// <summary>
    /// Disconnect the user from the server
    /// It cleans the stream, the buffer, the socket and the other buffers
    /// </summary>
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
