using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// The main class of the server
/// </summary>
public class GameServer : MonoBehaviour
{
    /// <summary>
    /// The data interface reference
    /// </summary>
    public ServerDataImplementation data;
    /// <summary>
    /// The network interface ref
    /// </summary>
    ServerNetworkImplementation network;

    /// <summary>
    /// The tcp listener of the connection socket
    /// </summary>
    private static TcpListener tcpListener;
    /// <summary>
    /// The dictionnary containing the clients id and the client sockets
    /// This is where we can access the sockets of the client
    /// </summary>
    public static Dictionary<int, ClientServer> clients = new Dictionary<int, ClientServer>();
    /// <summary>
    /// The max number of player connected to the server
    /// </summary>
    public static int MaxPlayers { get; private set; }
    /// <summary>
    /// The connection port
    /// </summary>
    public static int Port { get; private set; }

    /// <summary>
    /// Method that starts the server and open the TCP listener
    /// </summary>
    /// <param name="_maxPlayers">The max number of player</param>
    /// <param name="_port">The port to listen to</param>
    public void StartServer(int _maxPlayers, int _port)
    {
        MaxPlayers = _maxPlayers;
        Port = _port;

        Console.WriteLine("Starting server...");
        InitializeServerData();

        tcpListener = new TcpListener(IPAddress.Any, Port);
        tcpListener.Start();
        tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);


        Console.WriteLine($"Server started on port {Port}.");
        network = new ServerNetworkImplementation();
        data = new ServerDataImplementation();
        data.SetupServer(network);
    }

    /// <summary>
    /// Is called when recieving a connection request from a client (that is not connected yet)
    /// </summary>
    /// <param name="_result">The result of the callback</param>
    private void TCPConnectCallback(IAsyncResult _result)
    {
        TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
        tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);
        Console.WriteLine($"Incoming connection from {_client.Client.RemoteEndPoint}...");

        for (int i = 1; i <= MaxPlayers; i++)
        {
            if (clients[i].socket == null)
            {
                clients[i].Connect(_client);
                SendInitialisation(clients[i].id);
                return;
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{_client.Client.RemoteEndPoint} failed to connect: Server full!",Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Creates all the sockets (maxium number)
    /// </summary>
    private void InitializeServerData()
    {
        for (int i = 1; i <= MaxPlayers; i++)
        {
            clients.Add(i, new ClientServer(i, this));
        }
        Console.WriteLine("Initialized packets.");
    }

    //SERVER SEND ************************************************
    /// <summary>
    /// Call the sendData method of the given User
    /// </summary>
    /// <param name="_toClient"></param>
    /// <param name="_packet"></param>
    private void SendTCPData(int _toClient, Packet _packet)
    {
        clients[_toClient].SendData(_packet);
    }

    /// <summary>
    /// Send the initialization packet to the client (with its id on the server)
    /// </summary>
    /// <param name="_toClient">The client ID to send to</param>
    public void SendInitialisation(int _toClient)
    {
        InitializationPacket p = new InitializationPacket(_toClient);
        SendTCPData(_toClient, p);


     //************************************************************

    }

    /// <summary>
    /// Disconnect a client
    /// </summary>
    /// <param name="id">The is of the client</param>
    public void DisconnectClient(int id)
    {
        clients[id].Disconnect();
    }

    /// <summary>
    /// Debug method to debug on the console for class that are not monobehaviour
    /// </summary>
    /// <param name="message">The string message</param>
    public void DebugIt(string message)
    {
        Console.WriteLine(message);
    }
}
