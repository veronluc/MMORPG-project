using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Server.Network.Messages;

public class ClientServer
{
    public int id;
    public static int dataBufferSize = 4096;
    public TcpClient socket;

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

        stream = socket.GetStream();
        receiveBuffer = new byte[dataBufferSize];

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
                    bf.Serialize(ms, _packet);
                    stream.BeginWrite(ms.ToArray(), 0, ms.ToArray().Length, null, null);
                }

            }
        }
        catch (Exception _ex)
        {
            Console.WriteLine($"Error sending data to player {id} via TCP: {_ex}");
        }
    }

    private void ReceiveCallback(IAsyncResult _result)
    {
        try
        {
            int _byteLength = stream.EndRead(_result);
            if (_byteLength <= 0)
            {
                GameServer.clients[id].Disconnect();
                return;
            }

            byte[] _data = new byte[_byteLength];
            Array.Copy(receiveBuffer, _data, _byteLength);
            stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }
        catch (Exception _ex)
        {
            Console.WriteLine($"Error receiving TCP data: {_ex}");
            GameServer.clients[id].Disconnect();
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
                Server.Network.Messages.Packet obj = (Server.Network.Messages.Packet)bf.Deserialize(ms);
                obj.Handle(s);
                Console.WriteLine("Object handled");
            }
            /*
            using (Packet _packet = new Packet(_packetBytes))
            {
                int _packetId = _packet.ReadInt();
                Server.packetHandlers[_packetId](id, _packet);
            }*/
        });
        return true;
    }
    public void Disconnect()
    {
        socket.Close();
        stream = null;
        receiveBuffer = null;
        socket = null;
    }

}