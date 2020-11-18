using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class UserAsksWorldListPacket : Packet
{
    User CurrentUser;
    public UserAsksWorldListPacket (User u)
    {
        CurrentUser = u;
    }
    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.UserAskWorldList(CurrentUser);
    }
}
