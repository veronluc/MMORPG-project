using System.Collections;
using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;

public class NetworkInterfaceImpl : NetworkInterface
{
    Client client;
    public NetworkInterfaceImpl(Client pClient)
    {
        client = pClient;
    }
    public void AddNewWorld(World world)
    {
        AddNewWorldPacket msg = new AddNewWorldPacket(world);
        client.SendData(msg);
    }

    public void AskServerUserList()
    {
        throw new System.NotImplementedException();
    }

    public void AskServerWorldList()
    {
        throw new System.NotImplementedException();
    }

    public void ConnectToWorld(Player player, string idWorld)
    {
        ConnectToWorldPacket msg = new ConnectToWorldPacket(player, idWorld);
        client.SendData(msg);
    }

    public void ConnectUser(User user, string ipAdress, int port)
    {
        client.currentUser = user;
        client.ConnectToServer(ipAdress, port);
    }

    public void DisconnectUserFromServer()
    {
        AskDisconnectServer msg = new AskDisconnectServer(client.currentUser);
        client.SendData(msg);
    }

    public void DisconnectUserFromWorld()
    {
        AskDisconnectWorld msg = new AskDisconnectWorld(client.currentUser);
        client.SendData(msg);
    }

    public void RefreshUserInfos(User user)
    {
        throw new System.NotImplementedException();
    }

    public void SendAction(Player player, Action action)
    {
        throw new System.NotImplementedException();
    }

    public void SendChatMessage(Message message)
    {
        throw new System.NotImplementedException();
    }
}
