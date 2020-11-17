using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForNetworkImpl : DataInterfaceForNetwork
{
    public void ReceiveListWorlds(List<World> worlds)
    {
        DataModule.ihmMainInterface.DisplayNewAvailableWorld(worlds);
    }

    public void ReceiveWorld(World world)
    {
        // TODO pas d'arguments ? Comment on transmet le monde ?
        DataModule.ihmGameInterface.LaunchGame();
    }

    public void ReceiveListUsers(List<User> users) {
        // TODO -- Do nothing ? No DisplayListUser in IhmMainInterface
    }
    public void ReceiveListUsersFromWorld(List<User> users, World world) { }
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
