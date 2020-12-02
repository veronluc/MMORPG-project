using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to tell the server that a user will logout from the server soon
/// </summary>
[Serializable]
public class AskDisconnectServer : Packet
{
    /// <summary>
    /// The user that disconnects
    /// </summary>
    public User currentUser;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="u">The user that disconnects</param>
    public AskDisconnectServer(User u)
    {
        currentUser = u;
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
    /// Server side Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        s.data.UserAskDisconnectFromServer(currentUser);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Client "+currentUser.id+" asks to disconnect.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
