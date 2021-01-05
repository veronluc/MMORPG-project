using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Packet used to send a list of users connected to a world
/// </summary>
[Serializable]
public class SendUserListFromWorld : Packet
{
    /// <summary>
    /// The user list
    /// </summary>
    List<User> users;

    /// <summary>
    /// The world
    /// </summary>
    World world;

    /// <summary>
    /// Constructor of the packet
    /// </summary>
    /// <param name="pUsers">The user list</param>
    /// <param name="pWorld">The world</param>
    public SendUserListFromWorld(List<User> pUsers, World pWorld)
    {
        users = pUsers;
        world = pWorld;
    }

    /// <summary>
    /// The client handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.ReceiveListUsersFromWorld(users, world);
    }

    /// <summary>
    /// The server Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
