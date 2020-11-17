using AI12_DataObjects;
using Server.Network.Messages;
using System.Collections;
using System.Collections.Generic;

public class SendUsersListPacket : Packet
{
    List<User> users;

    public SendUsersListPacket(List<User> pUsers)
    {
        users = pUsers;
    }

    public override void Handle(Client c)
    {
        c.data.ReceiveListUsers(users);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
