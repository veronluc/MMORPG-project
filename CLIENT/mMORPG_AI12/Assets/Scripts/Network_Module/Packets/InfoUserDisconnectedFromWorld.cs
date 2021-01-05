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
    /// <summary>
    /// If the user is the owner true, if not then false
    /// </summary>
    bool isWorldOwner = false;
    /// <summary>
    /// The user that disconnects
    /// </summary>
    User user;

    /// <summary>
    /// Constructor of the packet
    /// </summary>
    /// <param name="pUser">The user that disconnects</param>
    /// <param name="isOwner">If the user is the owner of the wolrd</param>
    public InfoUserDisconnectedFromWorld(User pUser, bool isOwner)
    {
        user = pUser;
        isWorldOwner = isOwner;
    }

    /// <summary>
    /// The Client handle
    /// </summary>
    /// <param name="c">The client</param>
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

    /// <summary>
    /// The server Handle
    /// </summary>
    /// <param name="s"></param>
    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
