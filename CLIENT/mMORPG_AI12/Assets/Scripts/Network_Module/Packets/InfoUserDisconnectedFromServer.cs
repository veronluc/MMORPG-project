using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
/// <summary>
/// Packet to say that a user has disconnected from a server
/// </summary>
public class InfoUserDisconnectedFromServer : Packet
{
    User user;
    public InfoUserDisconnectedFromServer(User disconnectedUser)
    {
        user = disconnectedUser;
    }
    public override void Handle(Client c)
    {
        c.data.UserDisconnectedFromServer(user);
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }

}
