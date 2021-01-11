using System.Collections;
using System.Collections.Generic;
using AI12_DataObjects;
using System;
using Action = AI12_DataObjects.Action;

public class DataInterfaceForNetworkImpl : DataInterfaceForNetwork
{
    private DataModule dataModule;
    private ConnectedUserManager connectedUserManager;

    public DataInterfaceForNetworkImpl(DataModule _dataModule)
    {
        this.dataModule = _dataModule;
        this.connectedUserManager = dataModule.connectedUserManager;
    }

    public void ReceiveListWorlds(List<World> worlds)
    {
        DataModule.ihmMainInterface.DisplayNewAvailableWorld(worlds);
    }

    public User GetUser()
    {
        return dataModule.connectedUserManager.connectedUser.user;
    }

    public void setUserId(string userId)
    {
        dataModule.connectedUserManager.connectedUser.user.id = userId;
    }

    public void ReceiveWorld(User user, World world, Player player)
    {
        connectedUserManager.currentWorld = world;
        connectedUserManager.currentPlayer = player;
        DataModule.ihmGameInterface.LaunchGame(user, world, player);
    }

    public void ReceiveListUsers(List<User> users)
    {
        if (DataModule.ihmMainInterface == null)
            Debug.LogError("Interface cliente ihmMainInterface non implémentée");
        //GameObject.FindObjectOfType<DataModule>().GetInterfaceForIHMMain().DisplayListUser(users);
        //DataModule.GetInterfaceForIHMMain() .DisplayListUser(users);
        DataModule.ihmMainInterface.DisplayListUser(users);
    }

    public void ReceiveListUsersWorlds(List<User> users, List<World> worlds)
    {
        DataModule.ihmMainInterface.DisplayListUsersWorlds(users, worlds);
    }

    public void ReceiveMessage(Message message)
    {
        DataModule.ihmGameInterface.DisplayMessage(message);
    }

    public void ReceiveAction(GameState newGameState)
    {
        DataModule.ihmGameInterface.UpdateDisplay(newGameState);
    }

    public void ReceiveUser(User user) { }

    public void DisconnectServerStop()
    {
        connectedUserManager.currentWorld = null;
        connectedUserManager.currentPlayer = null;
        DataModule.ihmGameInterface.DisplayServerStop();
    }
    public void DisconnectServerError()
    {
        connectedUserManager.currentWorld = null;
        connectedUserManager.currentPlayer = null;
        DataModule.ihmGameInterface.DisplayServerStop();
    }

    public void UserDisconnectedFromWorld(User user)
    {
        connectedUserManager.currentWorld = null;
        connectedUserManager.currentPlayer = null;
        DataModule.ihmGameInterface.DisplayUserLogout();
    }

    public void UserDisconnectedFromServer(User user)
    {
        connectedUserManager.currentWorld = null;
        connectedUserManager.currentPlayer = null;
        DataModule.ihmGameInterface.DisplayUserLogout();
    }

    public void OwnerDisconnectedFromWorld(User user)
    {
        connectedUserManager.currentWorld = null;
        connectedUserManager.currentPlayer = null;
        DataModule.ihmGameInterface.DisplayServerStop();
    }

    [Obsolete("Use the othe ReceiveWorld method instead")]
    public void ReceiveWorld(World world) { }
}
