using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SendMessage : Packet
{
    Message message;
    public SendMessage(Message pMessage)
    {
        this.message = pMessage;
    }

    public override void Handle(GameServer s)
    {
        s.data.ReceiveMessage(this.message);

    }

    public override void Handle(Client c)
    {
        c.data.ReceiveMessage(this.message);
    }
}
