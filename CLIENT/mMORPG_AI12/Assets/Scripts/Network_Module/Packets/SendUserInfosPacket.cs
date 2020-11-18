using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SendUserInfosPacket : Packet
{
    User user;
    public SendUserInfosPacket(User pUser)
    {
        user = pUser;
    }

    public override void Handle(GameServer s)
    {
        s.data.ReceiveUser(user);

    }

    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }
}
