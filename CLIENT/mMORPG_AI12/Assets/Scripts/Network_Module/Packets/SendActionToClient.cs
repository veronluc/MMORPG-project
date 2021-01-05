using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to send an action to the client (GameState)
/// </summary>
[Serializable]
public class SendActionToClient : Packet
{
    /// <summary>
    /// The new gameState
    /// </summary>
    GameState state;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pState">The game State</param>
    public SendActionToClient(GameState pState)
    {
        state = pState;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.ReceiveAction(state);
    }

    /// <summary>
    /// Server side handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
