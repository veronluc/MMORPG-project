using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A packet to send a list of worlds
/// </summary>
[Serializable]
public class SendWorldsListPacket : Packet
{
    /// <summary>
    /// The list of worlds
    /// </summary>
    List<World> worlds;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pWorlds">The list of worlds to send</param>
   public SendWorldsListPacket(List<World> pWorlds)
    {
        worlds = pWorlds;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {

        c.data.ReceiveListWorlds(worlds);
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
