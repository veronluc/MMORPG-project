using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

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
        server.data.ReceiveConnexionUserToWorld(player, IdWorld);
    }

    public override void Handle(Client client)
    {
        throw new NotImplementedException();
    }
}
