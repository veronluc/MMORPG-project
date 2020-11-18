using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System;
using Action = AI12_DataObjects.Action;

public class DataInterfaceForNetworkImpl : DataInterfaceForNetwork
{
    public void ReceiveListWorlds(List<World> worlds)
    {
        DataModule.ihmMainInterface.DisplayNewAvailableWorld(worlds);
    }

    [Obsolete("Use the othe ReceiveWorld method instead")]
    public void ReceiveWorld(World world)
    {
        // TODO DO NOT USE
    }

    public void ReceiveWorld(User user, World world, Player player)
    {
        DataModule.ihmGameInterface.LaunchGame(user, world, world.gameState, player);
    }

    public void ReceiveListUsers(List<User> users) {
        DataModule.ihmMainInterface.DisplayListUser(users);
    }
    public void ReceiveListUsersFromWorld(List<User> users, World world) { }

    public void ReceiveListUsersWorlds(List<User> users, List<World> worlds) {
        DataModule.ihmMainInterface.DisplayListUsersWorlds(users, worlds);
    }
    
    public void ReceiveMessage(Message message) { }
    public void ReceiveAction(Action action, Player player) { }
    public void ReceiveAction(Action action, Monster monster) { }
    
    public void ReceiveUser(User user) { }
    public void DisconnectServerStop() { }
    public void DisconnectServerError() { }
    public void UserDisconnectedFromWorld(User user) { }
    public void UserDisconnectedFromServer(User user) { }
    public void OwnerDisconnectedFromWorld(User user) { }
}
