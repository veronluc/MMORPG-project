using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections.Generic;

/// <summary>
/// Packet to send a list of users and a list of worlds
/// </summary>
[Serializable]
public class SendUsersAndWorlds : Packet
{
    /// <summary>
    /// The user list
    /// </summary>
    List<User> users;
    /// <summary>
    /// The world list
    /// </summary>
    List<World> worlds;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pUsers">The user list to send</param>
    /// <param name="pWorlds">The worl list to send</param>
    public SendUsersAndWorlds(List<User> pUsers, List<World> pWorlds)
    {
        users = pUsers;
        worlds = pWorlds;
    }

    /// <summary>
    /// Client side Handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.ReceiveListUsers(users);
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
