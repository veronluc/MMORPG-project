using Server.Network;
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

    /*
    protected override void RunHandle()
    {
        client.myId = clientID;
        client.DebugIt("Received new id : " + clientID);
    }*/

    public override void Handle(Client c)
    {
        c.myId = clientID;
    }


    public override void Handle(GameServer c)
    {
        throw new NotImplementedException();
    }

}
