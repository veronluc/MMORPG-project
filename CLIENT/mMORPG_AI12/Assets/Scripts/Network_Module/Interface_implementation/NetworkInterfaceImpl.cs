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
        UserAskUserListsPacket msg = new UserAskUserListsPacket(client.data.GetUser());
        client.SendData(msg);
    }

    public void AskServerWorldList()
    {
        UserAsksWorldListPacket msg = new UserAsksWorldListPacket(client.data.GetUser());
        client.SendData(msg);
    }

    public void ConnectToWorld(Player player, string idWorld)
    {
        if (player.user == null)
        {
            player.user = client.data.GetUser();
        }
        else if (player.user.id == null)
        {
            player.user.id = client.data.GetUser().id;
        }
        ConnectToWorldPacket msg = new ConnectToWorldPacket(player, idWorld);
        client.SendData(msg);
    }

    public void ConnectUser(User user, string ipAdress, int port)
    {
        if(user == null)
        {
            Debug.LogError("Attention : Data se connecte au serveur sans passer de user à network. Un user par défaut est créé par network.");
            
        }
        client.ConnectToServer(ipAdress, port);
    }

    public void DisconnectUserFromServer()
    {
        AskDisconnectServer msg = new AskDisconnectServer(client.data.GetUser());
        client.SendData(msg);
    }

    public void DisconnectUserFromWorld()
    {
        AskDisconnectWorld msg = new AskDisconnectWorld(client.data.GetUser());
        client.SendData(msg);
    }

    public void RefreshUserInfos(User user)
    {
        throw new System.NotImplementedException();
    }

    public void SendAction(Player player, Action action)
    {
        SendActionToServerPacket msg = new SendActionToServerPacket(action, client.data.GetUser());
        client.SendData(msg);
    }

    public void SendChatMessage(Message message)
    {
        if (message == null)
            throw new System.ArgumentNullException("Message to send to server is null");
        SendMessage msg = new SendMessage(message);
        this.client.SendData(msg);
    }
}
