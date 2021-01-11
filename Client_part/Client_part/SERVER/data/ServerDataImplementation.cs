using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;

public class ServerDataImplementation : ServerDataInterfaceForNetwork
{
    ServerNetworkImplementation network;
    /// <summary>
    /// Méthode appelée une fois le serveur démarré.
    /// </summary>
    /// <param name="n">Référence à l'implémmentation de l'nterface network</param>
    public void SetupServer(ServerNetworkImplementation n)
    {
        network = n;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Demarrage du serveur effectue", Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public List<World> GetWorlds()
    {
        return WorldsManager.GetOnlineWorlds();
    }

    public void ReceiveNewWorld(World world)
    {
        Console.WriteLine("Recieved new world");
        world.gameState = WorldManager.GenerateGameState(world);
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
        World w = WorldsManager.AddPlayerToWorld(player, worldId);
        network.SendConfirmationUserConnectionToWorld(player.user, w, player);
    }

    public void ReceiveMessage(Message message)
    {
        World currentWorld = WorldsManager.getWorldFromId(message.worldId);
        WorldsManager.GetPlayersUsers(currentWorld).ForEach(user =>
        {
            network.SendMessageToUser(user, message);
        });
    }

    public Entity ReceiveNewAction(World world)
    {
        return world.gameState.currentEntity();
    }

    public GameState ReceiveNewAction(AI12_DataObjects.Action action)
    {
        GameState newGameState =  action.makeAction();
        WorldsManager.UpdateWorldFromId(action.world.id, newGameState);
        return newGameState;
    }

    public GameState MakeMonsterTurn(World world)
    {
        world.gameState = WorldManager.AutoPlayMonster(world);
        world.gameState = new ActionEndRound(world.gameState.currentEntity(), world).makeAction();
        WorldsManager.UpdateWorldFromId(world.id, world.gameState);
        return world.gameState;
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
    public void UserBrutalDisconnected(string userID)
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsersFromWorld(World world)
    {
        return WorldsManager.GetPlayersUsers(world);
    }

    public List<User> GetUsersFromWorld(string idWorld)
    {
        World world = WorldsManager.getWorldFromId(idWorld);
        if (world == null) throw new Exception("World is not online");
        return GetUsersFromWorld(world);
    }
}
