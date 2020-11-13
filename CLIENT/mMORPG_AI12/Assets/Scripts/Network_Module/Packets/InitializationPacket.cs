using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class InitializationPacket : Packet
{
    private int clientID;
    public InitializationPacket(int pClientId)
    {
        clientID = pClientId;
    }
    public override void Handle(Client c)
    {
        c.myId = clientID;
        c.DebugIt("Id seted to client to : " + c.myId);
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException("Méthode ne doit pas être appelée");
    }
}
