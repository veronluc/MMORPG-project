using System.Collections;
using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;

public class NetworkInterfaceImpl : NetworkInterface
{
    Client client;
    public NetworkInterfaceImpl(Client pClient)
    {
        client = pClient;
    }

    /// <summary>
    /// Send a new workd to the server
    /// </summary>
    /// <param name="world">The world to send</param>
    public void AddNewWorld(World world)
    {
        AddNewWorldPacket msg = new AddNewWorldPacket(world);
        client.SendData(msg);
    }

    /// <summary>
    /// Send a request to recieve the full list of users connected to the server
    /// </summary>
    public void AskServerUserList()
    {
        UserAskUserListsPacket msg = new UserAskUserListsPacket(client.data.GetUser());
        client.SendData(msg);
    }

    /// <summary>
    /// Send a request to recieve the list of all world on the server.
    /// </summary>
    public void AskServerWorldList()
    {
        UserAsksWorldListPacket msg = new UserAsksWorldListPacket(client.data.GetUser());
        client.SendData(msg);
    }

    /// <summary>
    /// Connect the player to a world on the server.
    /// </summary>
    /// <param name="idWorld">The world the player has to connect to</param>
    public void ConnectToWorld(Player player, string idWorld)
    {
        if (player.user == null)
        {
            player.user = client.data.GetUser();
        }
        else if (player.user.id == null)
        {
            player.user.id = client.data.GetUser().id;
        }
        ConnectToWorldPacket msg = new ConnectToWorldPacket(player, idWorld);
        client.SendData(msg);
    }

    /// <summary>
    /// Connect the client to the server.
    /// </summary>
    /// <param name="user">The info about the user WITHOUT ITS ID (Network handles it)</param>
    /// <param name="ipAdress">Server adress IP</param>
    /// <param name="port">Server connexion port</param>
    public void ConnectUser(User user, string ipAdress, int port)
    {
        if(user == null)
        {
            Debug.LogError("Attention : Data se connecte au serveur sans passer de user à network. Un user par défaut est créé par network.");
            
        }
        client.ConnectToServer(ipAdress, port);
    }

    /// <summary>
    /// Send a logout request to the server
    /// </summary>
    public void DisconnectUserFromServer()
    {
        AskDisconnectServer msg = new AskDisconnectServer(client.data.GetUser());
        client.SendData(msg);
    }

    /// <summary>
    /// Send a logout request to a world on the server.
    /// </summary>
    public void DisconnectUserFromWorld()
    {
        AskDisconnectWorld msg = new AskDisconnectWorld(client.data.GetUser());
        client.SendData(msg);
    }

    /// <summary>
    /// Refresh the infos about the user nd send them to the server (without id as always)
    /// </summary>
    /// <param name="user">The user with refreshed data</param>
    public void RefreshUserInfos(User user)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Send an action to process to the server. The client already knows the id of the user. The server links the user to the world he is currently in.
    /// </summary>
    /// <param name="player">The player in game</param>
    /// <param name="action">Action to perform</param>
    public void SendAction(Player player, Action action)
    {
        SendActionToServerPacket msg = new SendActionToServerPacket(action, client.data.GetUser());
        client.SendData(msg);
    }

    /// <summary>
    /// Send a message to the server (the client already knows the id to send it to)
    /// </summary>
    /// <param name="message">Message to send</param>
    public void SendChatMessage(Message message)
    {
        if (message == null)
            throw new System.ArgumentNullException("Message to send to server is null");
        SendMessage msg = new SendMessage(message);
        this.client.SendData(msg);
    }
}
