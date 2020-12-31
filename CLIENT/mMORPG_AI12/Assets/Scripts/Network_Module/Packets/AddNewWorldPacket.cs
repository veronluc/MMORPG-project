using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to send to add a new world to the server
/// </summary>
[Serializable]
public class AddNewWorldPacket : Packet
{
    /// <summary>
    /// The world to add
    /// </summary>
    World world;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="w">The world to add</param>
    public AddNewWorldPacket(World w)
    {
        world = w;
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
        s.data.ReceiveNewWorld(world);
    }
}
