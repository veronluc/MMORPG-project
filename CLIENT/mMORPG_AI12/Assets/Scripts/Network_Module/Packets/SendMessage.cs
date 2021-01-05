using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to send a chat message
/// </summary>
[Serializable]
public class SendMessage : Packet
{
    /// <summary>
    /// The message
    /// </summary>
    Message message;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pMessage">The message to send</param>
    public SendMessage(Message pMessage)
    {
        this.message = pMessage;
    }

    /// <summary>
    /// Server side handle
    /// </summary>
    /// <param name="s">The Server</param>
    public override void Handle(GameServer s)
    {
        s.data.ReceiveMessage(this.message);

    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.ReceiveMessage(this.message);
    }
}
