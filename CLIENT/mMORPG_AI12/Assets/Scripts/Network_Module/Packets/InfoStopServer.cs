using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Packet used to tell the client that the server is going to shut down
/// </summary>
[Serializable]
public class InfoStopServer : Packet
{
    /// <summary>
    /// Client handle
    /// </summary>
    /// <param name="c">The client to disconnect</param>
    public override void Handle(Client c)
    {
        c.data.DisconnectServerStop();
    }

    /// <summary>
    /// Server Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
