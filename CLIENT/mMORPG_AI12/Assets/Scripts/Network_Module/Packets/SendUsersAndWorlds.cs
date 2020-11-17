using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System.Collections;
using System.Collections.Generic;

public class SendUsersAndWorlds : Packet
{
    List<User> users;
    List<World> worlds;

    public SendUsersAndWorlds(List<User> pUsers, List<World> pWorlds)
    {
        users = pUsers;
        worlds = pWorlds;
    }

    public override void Handle(Client c)
    {
        c.data.ReceiveListUsers(users);
        c.data.ReceiveListWorlds(worlds);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
