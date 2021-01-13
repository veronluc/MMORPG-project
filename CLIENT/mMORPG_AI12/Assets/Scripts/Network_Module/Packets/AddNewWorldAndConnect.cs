using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Packet to add a new world and connect a user to a world
/// </summary>
[Serializable]
public class AddNewWorldAndConnect : Packet
{
    /// <summary>
    /// The world to send
    /// </summary>
    World w;
    /// <summary>
    /// The player to connect
    /// </summary>
    Player player;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pw">The world to load</param>
    /// <param name="pPlayer">The player to connect</param>
    public AddNewWorldAndConnect(World pw, Player pPlayer)
    {
        w = pw;
        player = pPlayer;
    }

    /// <summary>
    /// Client side Handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Server side Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        Console.WriteLine("Correctly received packet Add new world and connect.");
        s.data.ReceiveNewWorld(w);
        s.data.ReceiveConnexionUserToWorld(player, w.id);
    }
}
