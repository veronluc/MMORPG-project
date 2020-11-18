
using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class ConfirmationUserConnectionToWorldPacket : Packet
{
    World world;
    bool result;
    string message;

    public ConfirmationUserConnectionToWorldPacket(World pWorld, bool pRes, string pMessage)
    {
        world = pWorld;
        result = pRes;
        message = pMessage;
    }
    public override void Handle(Client c)
    {
        //TO DO 
        //c.data.confirm...
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
