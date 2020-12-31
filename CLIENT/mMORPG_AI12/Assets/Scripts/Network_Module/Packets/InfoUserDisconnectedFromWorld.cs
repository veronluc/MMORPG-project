﻿using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
/// <summary>
/// Packet to say that user has disconnected from a world
/// </summary>
public class InfoUserDisconnectedFromWorld : Packet
{
    User user;
    public InfoUserDisconnectedFromWorld(User pUser)
    {
        user = pUser;
    }
    public override void Handle(Client c)
    {
        c.data.UserDisconnectedFromWorld(user);
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
