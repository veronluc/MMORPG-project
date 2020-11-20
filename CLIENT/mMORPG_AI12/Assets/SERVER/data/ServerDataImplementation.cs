using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerDataImplementation : MonoBehaviour, ServerDataInterfaceForNetwork
{
    ServerNetworkImplementation network;
    /// <summary>
    /// Méthode appelée une fois le serveur démarré.
    /// </summary>
    /// <param name="n">Référence à l'implémmentation de l'nterface network</param>
    public void SetupServer(ServerNetworkImplementation n)
    {
        network = n;

        //DEBUG
        World w = new World("DefaultWorld", 10, GameMode.pvp, true, 1, 10, 2, 2, 2, true, true, true, true, false, false, false, false, new List<Player>(), new List<Monster>(), new User(), new GameState());
        w.id = "111";
        ReceiveNewWorld(w);
        Debug.Log("Demarrage du serveur effectue");
        
    }

    public List<World> GetWorlds()
    {
        return WorldsManager.GetOnlineWorlds();
    }

    public void ReceiveNewWorld(World world)
    {
        Console.WriteLine("Recieved new world");
        WorldsManager.AddWorld(world);
    }

    public void ReceiveUser(User user)
    {
        network.SendListUsersWorlds(user, UsersManager.GetConnectedUsers(), WorldsManager.GetOnlineWorlds());
        UsersManager.AddUser(user);
        foreach (User u in UsersManager.GetConnectedUsers())
        {
            if(u.id != user.id)
                network.SendUsersList(u, UsersManager.GetConnectedUsers());
        }
    }

    public List<User> GetUsers()
    {
        return UsersManager.GetConnectedUsers();
    }

    public void ReceiveConnexionUserToWorld(Player player, string worldId)
    {
        Console.WriteLine("Recieved connexion to world id : "+worldId);
        WorldsManager.AddPlayerToWorld(player, worldId);
    }

    public void ReceiveMessage(Message message)
    {
        throw new NotImplementedException();
    }
    public void ReceiveNewAction(World world)
    {
        throw new NotImplementedException();
    }
    public void ReceiveNewAction(AI12_DataObjects.Action action)
    {
        throw new NotImplementedException();
    }
    public void UserAskWorldList(User user)
    {
        throw new NotImplementedException();
    }
    public void UserAskUsersList(User user)
    {
        throw new NotImplementedException();
    }
    public void UserRefreshInfos(User user)
    {
        throw new NotImplementedException();
    }
    public void UserAskDisconnectFromWorld(User user)
    {
        World world = GetWorlds().Find(w => w.players != null && w.players.Exists(u => u.user.id == user.id));
        if (world != null)
        {
            world.players.RemoveAll(u => u.user.id == user.id);
        }
    }
    public void UserAskDisconnectFromServer(User user)
    {
        UsersManager.RemoveUser(user);
        foreach(User u in UsersManager.GetConnectedUsers())
        {
            network.SendListUsersWorlds(u, UsersManager.GetConnectedUsers(), GetWorlds());
        }
    }
    public void UserBrutalDisconnected(User user)
    {
        throw new NotImplementedException();
    }
}
