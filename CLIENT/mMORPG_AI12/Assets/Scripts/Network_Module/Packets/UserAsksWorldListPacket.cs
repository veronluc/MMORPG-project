using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A packet to request the server to send a list of worlds to the client
/// </summary>
[Serializable]
public class UserAsksWorldListPacket : Packet
{
    /// <summary>
    /// The user that asks for the list
    /// </summary>
    User CurrentUser;

    /// <summary>
    /// Constructor for the packet
    /// </summary>
    /// <param name="u">The user that asks for the list</param>
    public UserAsksWorldListPacket (User u)
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
    /// Server side handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        s.data.UserAskWorldList(CurrentUser);
    }
}
