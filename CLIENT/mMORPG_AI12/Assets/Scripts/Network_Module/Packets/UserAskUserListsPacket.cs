using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A packet to request the server to send a list of users to the client
/// </summary>
[Serializable]
public class UserAskUserListsPacket : Packet
{
    /// <summary>
    /// The user that ask the list to the server
    /// </summary>
    User CurrentUser;

    /// <summary>
    /// Constructor of the packet
    /// </summary>
    /// <param name="u">The user that sent the request</param>
    public UserAskUserListsPacket(User u)
    {
        CurrentUser = u;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Server side Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        s.data.UserAskUsersList(CurrentUser);
    }
}
