using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Packet to initialise the connection (send user id)
/// </summary>
[Serializable]
public class InitializationPacket : Packet
{
    /// <summary>
    /// The user id
    /// </summary>
    private int clientID;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pClientId">The client id</param>
    public InitializationPacket(int pClientId)
    {
        clientID = pClientId;
    }

    /// <summary>
    /// Client side handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        c.data.setUserId(clientID.ToString());
        //TO DO : Informer data (client) que connexion serveur reussie ou non
        SendUserInfosPacket msg = new SendUserInfosPacket(c.data.GetUser());
        c.SendData(msg);
    }


    /// <summary>
    /// Server side Handle
    /// </summary>
    /// <param name="c">The server</param>
    public override void Handle(GameServer c)
    {
        throw new NotImplementedException();
    }

}
