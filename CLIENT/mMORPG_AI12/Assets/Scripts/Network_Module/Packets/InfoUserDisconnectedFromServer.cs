using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
/// <summary>
/// Packet to say that a user has disconnected from a server
/// </summary>
public class InfoUserDisconnectedFromServer : Packet
{
    /// <summary>
    /// The user that disconnects
    /// </summary>
    User user;

    /// <summary>
    /// The constructor of the class
    /// </summary>
    /// <param name="disconnectedUser">The user that disconnects</param>
    public InfoUserDisconnectedFromServer(User disconnectedUser)
    {
        user = disconnectedUser;
    }

    /// <summary>
    /// The Client handle
    /// </summary>
    /// <param name="c">The client that disconnected from the server</param>
    public override void Handle(Client c)
    {
        c.data.UserDisconnectedFromServer(user);
    }

    /// <summary>
    /// The server handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }

}
