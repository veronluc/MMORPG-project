using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForNetworkImpl : DataInterfaceForNetwork
{
    public void ReceiveListWorlds(List<World> worlds) { }
    public void ReceiveListUsers(List<User> users) { }
    public void ReceiveListUsersFromWorld(List<User> users, World world) { }
    public void ReceiveMessage(Message message) { }
    public void ReceiveAction(Action action, Player player) { }
    public void ReceiveAction(Action action, Monster monster) { }
    public void ReceiveWorld(World world) { }
    public void ReceiveUser(User user) { }
    public void DisconnectServerStop() { }
    public void DisconnectServerError() { }
    public void UserDisconnectedFromWorld(User user) { }
    public void UserDisconnectedFromServer(User user) { }
}
