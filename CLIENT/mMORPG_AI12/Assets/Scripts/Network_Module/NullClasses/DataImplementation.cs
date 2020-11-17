

using AI12_DataObjects;
using System;
using System.Collections.Generic;

public class DataImplementation
{
    
    /// <summary>
    /// Méthode appelée une fois le serveur démarré.
    /// </summary>
    /// <param name="n">Référence à l'implémmentation de l'nterface network</param>
    public void SetupServer()
    {
        throw new NotImplementedException();
    }

    public List<World> GetWorlds()
    {
        throw new NotImplementedException();
    }

    public void ReceiveNewWorld(World world)
    {
        throw new NotImplementedException();
    }

    public void ReceiveUser(User user)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public void ReceiveConnexionUserToWorld(Player player, World world)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
