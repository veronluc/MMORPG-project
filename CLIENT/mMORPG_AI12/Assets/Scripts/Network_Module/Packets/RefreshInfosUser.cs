using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The packet used to refresh user info in the server
/// </summary>
[Serializable]
public class RefreshInfosUser : Packet
{
    /// <summary>
    /// The new info
    /// </summary>
    User NewUserInfos;

    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pNewUserInfos">The new info</param>
    public RefreshInfosUser(User pNewUserInfos)
    {
        NewUserInfos = pNewUserInfos;
    }

    /// <summary>
    /// The client handle
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// The server Handle
    /// </summary>
    /// <param name="s">The server</param>
    public override void Handle(GameServer s)
    {
        s.data.UserRefreshInfos(NewUserInfos);
    }
}
