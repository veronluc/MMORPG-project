using AI12_DataObjects;
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
    bool isWorldOwner = false;
    User user;
    public InfoUserDisconnectedFromWorld(User pUser, bool isOwner)
    {
        user = pUser;
        isWorldOwner = isOwner;
    }
    public override void Handle(Client c)
    {
        if (isWorldOwner)
        {
            c.data.OwnerDisconnectedFromWorld(user);
        }
        else
        {
            c.data.UserDisconnectedFromWorld(user);
        }
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
