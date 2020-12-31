using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InfoStopServer : Packet
{
    public override void Handle(Client c)
    {
        c.data.DisconnectServerStop();
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
