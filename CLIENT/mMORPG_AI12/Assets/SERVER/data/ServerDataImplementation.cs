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
        Debug.Log("Demarrage du serveur effectue");
    }

    public List<World> GetWorlds()
    {
        return WorldsManager.GetOnlineWorlds();
    }

    public void ReceiveNewWorld(World world)
    {
        WorldsManager.AddWorld(world);
    }

    public void ReceiveUser(User user)
    {
        UsersManager.AddUser(user);
    }

    public List<User> GetUsers()
    {
        return UsersManager.GetConnectedUsers();
    }

    public void ReceiveConnexionUserToWorld(Player player, string worldId)
    {
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
        UsersManager.RemoveUser(user);
    }
    public void UserAskDisconnectFromServer(User user)
    {
        throw new NotImplementedException();
    }
    public void UserBrutalDisconnected(User user)
    {
        throw new NotImplementedException();
    }
}
