using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SendUserListFromWorld : Packet
{
    List<User> users;
    World world;
    public SendUserListFromWorld(List<User> pUsers, World pWorld)
    {
        users = pUsers;
        world = pWorld;
    }

    public override void Handle(Client c)
    {
        c.data.ReceiveListUsersFromWorld(users, world);
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
