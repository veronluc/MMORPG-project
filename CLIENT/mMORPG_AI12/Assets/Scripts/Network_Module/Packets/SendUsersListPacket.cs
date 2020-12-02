using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A packet to send a list of users
/// </summary>
[Serializable]
public class SendUsersListPacket : Packet
{
    /// <summary>
    /// The list of user to send
    /// </summary>
    List<User> users;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pUsers">The user list to send</param>
    public SendUsersListPacket(List<User> pUsers)
    {
        users = pUsers;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.ReceiveListUsers(users);
    }

    /// <summary>
    /// Server side handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
