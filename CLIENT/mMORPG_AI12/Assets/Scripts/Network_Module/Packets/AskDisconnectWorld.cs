using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class AskDisconnectWorld : Packet
{
    public User currentUser;
    public AskDisconnectWorld(User u)
    {
        currentUser = u;
    }

    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.UserAskDisconnectFromWorld(currentUser);
    }
}
