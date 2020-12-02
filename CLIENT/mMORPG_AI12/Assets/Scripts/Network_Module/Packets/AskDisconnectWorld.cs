using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to tell the server that a user will disconnect soon from his connected world
/// </summary>
[Serializable]
public class AskDisconnectWorld : Packet
{
    /// <summary>
    /// The user that disconnects
    /// </summary>
    public User currentUser;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="u">The user</param>
    public AskDisconnectWorld(User u)
    {
        currentUser = u;
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
        s.data.UserAskDisconnectFromWorld(currentUser);
    }
}
