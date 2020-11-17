using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

public class AskDisconnectServer : Packet
{
    public User currentUser;
    public AskDisconnectServer(User u)
    {
        currentUser = u;
    }

    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.UserAskDisconnectFromServer(currentUser);
    }
}
