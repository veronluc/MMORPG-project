using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AddNewWorldAndConnect : Packet
{
    World w;
    Player player;

    public AddNewWorldAndConnect(World pw, Player pPlayer)
    {
        w = pw;
        player = pPlayer;
    }
    public override void Handle(Client c)
    {
        throw new NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.ReceiveNewWorld(w);
        s.data.ReceiveConnexionUserToWorld(player, w.id);
    }
}
