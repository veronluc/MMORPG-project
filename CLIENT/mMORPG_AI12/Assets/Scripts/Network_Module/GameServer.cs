using Server.Network.Messages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class GameServer
{
    private static TcpListener tcpListener;
    public delegate void PacketHandler(int _fromClient, Packet _packet);
    public static Dictionary<int, PacketHandler> packetHandlers;
    public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
    public static int MaxPlayers { get; private set; }
    public static int Port { get; private set; }
    public void Start(int _maxPlayers, int _port)
    { }
    private void TCPConnectCallback(IAsyncResult _result)
    {

    }

    private void InitializeServerData()
    {

    }



    //SERVER SEND ************************************************
    private void SendTCPData(int _toClient, Packet _packet)
    {

    }

    private void SendTCPDataToAll(Packet _packet)
    {

    }
    private void SendTCPDataToAll(int _exceptClient, Packet _packet)
    {

    }

    #region Packets
    public void SendMessageToCLient(int fromClient, string message)
    {

    }

    public void SendInitialisation(int _toClient)
    {

    }
    #endregion
    public void HandleInitialization(int _fromClient, Packet _packet)
    {


    }
    public void HandleClientMessage(int _fromClient, Packet _packet)
    {

    }
}
