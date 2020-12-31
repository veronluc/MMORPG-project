using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The implementation class for the network interface for data
/// It extends ServerNetworkInterfaceForClient
/// </summary>
public class ServerNetworkImplementation : MonoBehaviour, ServerNetworkInterfaceForClient
{
    /// <summary>
    /// Sends a list of worlds to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="worlds">The list of worlds we want to send</param>
    public void SendWorldsList(User user, List<World> worlds)
    {
        if (worlds == null)
            worlds = new List<World>();
        SendWorldsListPacket msg = new SendWorldsListPacket(worlds);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Sends a list of users to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="users">The user list we want to send</param>
    public void SendUsersList(User user, List<User> users)
    {
        if (users == null)
            users = new List<User>();
        SendUsersListPacket msg = new SendUsersListPacket(users);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Sends a list of users in a specific world world to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="users">The user list we want to send</param>
    /// <param name="world">The world</param>
    public void SendUsersListFromWorld(User user, List<User> users, World world)
    {
        SendUserListFromWorld msg = new SendUserListFromWorld(users, world);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Send a message to the given user client
    /// </summary>
    /// <param name="user">The user we want to send the message to</param>
    /// <param name="message">The message to send</param>
    public void SendMessageToUser(User user, Message message)
    {
        if (message == null)
            throw new ArgumentNullException("Message to send to user is null");
        if (user == null)
            throw new ArgumentNullException("User to send message is null");
        SendMessage msg = new SendMessage(message);
        this.SendPacket(user.id,msg);
    }

    /// <summary>
    /// Send an action to the given user
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    /// <param name="gameState">The gamestate with the action being made</param>
    public void SendActionToUser(User user, GameState gameState)
    {
        SendActionToClient msg = new SendActionToClient(gameState);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Send a confirmation that the user has connected to a world
    /// </summary>
    /// <param name="user">The user who connected</param>
    /// <param name="world">The world concerned</param>
    /// <param name="player">The player connected</param>
    /// <param name="result">The result of the connection, true is good, false is not good</param>
    /// <param name="message">The message of the result</param>
    public void SendConfirmationUserConnectionToWorld(User user, World world, Player player, bool result, string message)
    {
        Console.WriteLine("User dest : " + user + "; World : " + world + "; Player : " + player);
        ConfirmationUserConnectionToWorldPacket msg = new ConfirmationUserConnectionToWorldPacket(world, user, player, result, message);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Send a message to the user when the server is about to stop
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    public void SendStopServer(User user)
    {
        InfoStopServer msg = new InfoStopServer();
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Send a message saying that a player has disconnected from a given world
    /// </summary>
    /// <param name="userDestination">The User we want to send to</param>
    /// <param name="userDisconnected">The player who has disconnected</param>
    public void SendUserDisconnectedWorld(User userDestination, User userDisconnected)
    {
        InfoUserDisconnectedFromWorld msg = new InfoUserDisconnectedFromWorld(userDisconnected);
        SendPacket(userDestination.id, msg);
    }

    /// <summary>
    /// Send a message saying that a player has disconnected from the server
    /// </summary>
    /// <param name="userDestination">The User we want to send to</param>
    /// <param name="userDisconnected">The player who has disconnected</param>
    public void SendUserDisconnectedServer(User userDestination, User userDisconnected)
    {
        InfoUserDisconnectedFromServer msg = new InfoUserDisconnectedFromServer(userDisconnected);
        SendPacket(userDestination.id, msg);
    }

    /// <summary>
    /// Send two lists of users and worlds to the user 
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    /// <param name="users">The list of users</param>
    /// <param name="worlds">The list of worlds</param>
    public void SendListUsersWorlds(User user, List<User> users, List<World> worlds)
    {
        if (users == null)
            users = new List<User>();
        if (worlds == null)
            worlds = new List<World>();
        SendUsersAndWorlds msg = new SendUsersAndWorlds(users, worlds);
        SendPacket(user.id, msg);
    }

    /// <summary>
    /// Sends a packet to the user represented by its id
    /// </summary>
    /// <param name="idString">The id of the user</param>
    /// <param name="packet">The packet we want to send</param>
    public void SendPacket(string idString, Packet packet)
    {
        int id = Convert.ToInt32(idString);
        if (GameServer.clients[id].socket == null)
        {
            Console.WriteLine("Utilisateur " + id.ToString() + " déconnecté. Impossible de lui envoyer de messages.");
        }
        else
        {
            GameServer.clients[id].SendData(packet);
        }
    }

}
