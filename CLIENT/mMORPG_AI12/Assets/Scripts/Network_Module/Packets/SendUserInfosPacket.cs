using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to send user info
/// </summary>
[Serializable]
public class SendUserInfosPacket : Packet
{
    /// <summary>
    /// The user to send (user infos)
    /// </summary>
    User user;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pUser">The user</param>
    public SendUserInfosPacket(User pUser)
    {
        user = pUser;
    }

    /// <summary>
    /// Server side handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        s.data.ReceiveUser(user);

    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }
}
