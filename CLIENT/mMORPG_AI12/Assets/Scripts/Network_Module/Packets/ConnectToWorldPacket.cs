using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to connect a user (his player) to a world
/// </summary>
[Serializable]
public class ConnectToWorldPacket : Packet
{
    /// <summary>
    /// The player that connects to the world
    /// </summary>
    Player player;
    /// <summary>
    /// The id of the world he connects to
    /// </summary>
    string IdWorld;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pPlayer">The player</param>
    /// <param name="pIdWorld">The id of the world</param>
    public ConnectToWorldPacket(Player pPlayer, string pIdWorld)
    {
        player = pPlayer;
        IdWorld = pIdWorld;
    }

    /// <summary>
    /// Server side Handle
    /// </summary>
    /// <param name="server">The server</param>
    public override void Handle(GameServer server)
    {
        server.data.ReceiveConnexionUserToWorld(player, IdWorld);
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="client">The client</param>
    public override void Handle(Client client)
    {
        throw new NotImplementedException();
    }
}
