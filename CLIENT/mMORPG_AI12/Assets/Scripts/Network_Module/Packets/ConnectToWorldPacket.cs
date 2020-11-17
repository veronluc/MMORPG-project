using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConnectToWorldPacket : Packet
{
    Player player;
    string IdWorld;
    public ConnectToWorldPacket(Player pPlayer, string pIdWorld)
    {
        player = pPlayer;
        IdWorld = pIdWorld;
    }

    public override void Handle(GameServer server)
    {
        //TO DO - remplacer le world par son id
        server.data.ReceiveConnexionUserToWorld(player, null);
    }

    public override void Handle(Client client)
    {
        throw new NotImplementedException();
    }
}
