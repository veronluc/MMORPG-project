
using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to confirm that a user (player) has connected to a world
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
    /// The player
    /// </summary>
    Player player;
    /// <summary>
    /// The result of the connection
    /// </summary>
    bool result;
    /// <summary>
    /// The message of the result
    /// </summary>
    string message;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pWorld">The world</param>
    /// <param name="pUser">The user</param>
    /// <param name="pPlayer">the player</param>
    /// <param name="pRes">the result</param>
    /// <param name="pMessage">The message</param>
    public ConfirmationUserConnectionToWorldPacket(World pWorld, User pUser, Player pPlayer, bool pRes, string pMessage)
    {
        world = pWorld;
        user = pUser;
        player = pPlayer;
        result = pRes;
        message = pMessage;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        //TO DO 
        //c.data.confirm...
        c.data.ReceiveWorld(user, world, player);
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
