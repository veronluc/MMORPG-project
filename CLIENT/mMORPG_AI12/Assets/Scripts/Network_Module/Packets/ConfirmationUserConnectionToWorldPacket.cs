using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;

/// <summary>
/// Packet to confirm that a user has connected to a world
/// </summary>
[Serializable]
public class ConfirmationUserConnectionToWorldPacket : Packet
{
    /// <summary>
    /// The world
    /// </summary>
    World world;
    /// <summary>
    /// The user
    /// </summary>
    User user;
    /// <summary>
    /// The player used by the user
    /// </summary>
    Player player;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pWorld">The world concerned</param>
    /// <param name="pUser">The user concerned</param>
    /// <param name="pPlayer">The player that connected</param>
    public ConfirmationUserConnectionToWorldPacket(World pWorld, User pUser, Player pPlayer)
    {
        world = pWorld;
        user = pUser;
        player = pPlayer;
    }

    /// <summary>
    /// Client side Handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {

        c.data.ReceiveWorld(user, world, player);
        c.DebugIt("Client received connexion confirmation.");
    }

    /// <summary>
    /// Server side Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}