﻿using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class GameServer : MonoBehaviour
{
    public ServerDataImplementation data;
    ServerNetworkImplementation network;

    private static TcpListener tcpListener;
    public static Dictionary<int, ClientServer> clients = new Dictionary<int, ClientServer>();
    public static int MaxPlayers { get; private set; }
    public static int Port { get; private set; }
    public  void StartServer(int _maxPlayers, int _port)
    {
        MaxPlayers = _maxPlayers;
        Port = _port;

        Debug.Log("Starting server...");
        InitializeServerData();

        tcpListener = new TcpListener(IPAddress.Any, Port);
        tcpListener.Start();
        tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);


        Debug.Log($"Server started on port {Port}.");
        network = new ServerNetworkImplementation();
        data = new ServerDataImplementation();
        data.SetupServer(network);
    }
    private void TCPConnectCallback(IAsyncResult _result)
    {
        Console.WriteLine("TCPConnectCallBack - socket client 1 : " + clients[1].socket);
        TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
        tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);
        Console.WriteLine($"Incoming connection from {_client.Client.RemoteEndPoint}...");

        for (int i = 1; i <= MaxPlayers; i++)
        {
            if (clients[i].socket == null)
            {
                Debug.Log("Client " + i + " is null");
                clients[i].Connect(_client);
                SendInitialisation(clients[i].id);
                //Debug("Ok");

                Console.WriteLine("Sended Initialization to client id : " + clients[i].id);
                Console.WriteLine("socket client 1 : "+ clients[i].socket);
                return;
            }
        }

        Console.WriteLine($"{_client.Client.RemoteEndPoint} failed to connect: Server full!");
    }

    private void InitializeServerData()
    {
        for (int i = 1; i <= MaxPlayers; i++)
        {
            clients.Add(i, new ClientServer(i, this));
        }
        Console.WriteLine("Initialized packets.");
    }

    //SERVER SEND ************************************************
    private void SendTCPData(int _toClient, Packet _packet)
    {
        clients[_toClient].SendData(_packet);
    }

    private void SendTCPDataToAll(Packet _packet)
    {
        for (int i = 1; i <= GameServer.MaxPlayers; i++)
        {
            GameServer.clients[i].SendData(_packet);
        }
    }
    private void SendTCPDataToAll(int _exceptClient, Packet _packet)
    {
        for (int i = 1; i <= GameServer.MaxPlayers; i++)
        {
            if (i != _exceptClient)
            {
                clients[i].SendData(_packet);
            }
        }
    }

    #region Packets
    public void SendMessageToCLient(int fromClient, string message)
    {
        //TO DO
    }

    public void SendInitialisation(int _toClient)
    {
        InitializationPacket p = new InitializationPacket(_toClient);
        SendTCPData(_toClient, p);

        #endregion

        //************************************************************

    }

    public void DisconnectClient(int id)
    {
        clients[id].Disconnect();
    }

    public void DebugIt(string message)
    {
        Debug.Log(message);
    }
}
