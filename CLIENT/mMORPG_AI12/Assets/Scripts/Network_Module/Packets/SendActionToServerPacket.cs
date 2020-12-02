using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Packet to send an action
/// </summary>
[Serializable]
public class SendActionToServerPacket : Packet
{
    /// <summary>
    /// The user concerned about the action
    /// </summary>
    User CurrentUser;
    /// <summary>
    /// The Action
    /// </summary>
    AI12_DataObjects.Action ActionToDo;
    /// <summary>
    /// The constructor of the packet
    /// </summary>
    /// <param name="pAction">The action</param>
    /// <param name="pUser">The user</param>
    public SendActionToServerPacket(AI12_DataObjects.Action pAction, User pUser)
    {
        CurrentUser = pUser;
        ActionToDo = pAction;
    }

    /// <summary>
    /// Client side user
    /// </summary>
    /// <param name="c">The client</param>
    public override void Handle(Client c)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Server side handle
    /// </summary>
    /// <param name="s">The client</param>
    public override void Handle(GameServer s)
    {
        s.data.ReceiveNewAction(ActionToDo);
    }
}
