using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerNetworkImplementation : MonoBehaviour
{
    public void SendWorldsList(User user, List<World> worlds)
    {
        if (worlds == null)
            worlds = new List<World>();
        SendWorldsListPacket msg = new SendWorldsListPacket(worlds);
        SendPacket(user.id, msg);
    }
    public void SendUsersList(User user, List<User> users)
    {
        if (users == null)
            users = new List<User>();
        SendUsersListPacket msg = new SendUsersListPacket(users);
        SendPacket(user.id, msg);
    }
    public void SendUsersListFromWorld(User user, List<User> users, World world)
    {
        throw new NotImplementedException();
    }
    public void SendMessageToUser(User user, Message message)
    {
        throw new NotImplementedException();
    }
    public void SendActionToUser(User user, AI12_DataObjects.Action action, Player player)
    {
        SendActionPlayerToClient msg = new SendActionPlayerToClient(player, action);
        SendPacket(user.id, msg);
    }
    public void SendActionToUser(User user, AI12_DataObjects.Action action, Monster monster)
    {
        SendActionMonsterToClient msg = new SendActionMonsterToClient(monster, action);
        SendPacket(user.id, msg);
    }
    public void SendConfirmationUserConnectionToWorld(User user, World world, Player player, bool result, string message)
    {
        Console.WriteLine("User dest : " + user + "; World : " + world + "; Player : " + player);
        ConfirmationUserConnectionToWorldPacket msg = new ConfirmationUserConnectionToWorldPacket(world, user, player, result, message);
        SendPacket(user.id, msg);
    }
    public void SendStopServer(User user)
    {
        throw new NotImplementedException();
    }
    public void SendUserDisconnectedWorld(User userDestination, User userDisconnected)
    {
        throw new NotImplementedException();
    }
    public void SendUserDisconnectedServer(User userDestination, User userDisconnected)
    {
        throw new NotImplementedException();
    }
    public void SendListUsersWorlds(User user, List<User> users, List<World> worlds)
    {
        if (users == null)
            users = new List<User>();
        if (worlds == null)
            worlds = new List<World>();
        SendUsersAndWorlds msg = new SendUsersAndWorlds(users, worlds);
        SendPacket(user.id, msg);
    }
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
