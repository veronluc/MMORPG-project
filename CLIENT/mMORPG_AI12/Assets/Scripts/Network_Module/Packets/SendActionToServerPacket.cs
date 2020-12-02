using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SendActionToServerPacket : Packet
{
    User CurrentUser;
    AI12_DataObjects.Action ActionToDo;
    public SendActionToServerPacket(AI12_DataObjects.Action pAction, User pUser)
    {
        CurrentUser = pUser;
        ActionToDo = pAction;
    }
    public override void Handle(Client c)
    {
        throw new NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.ReceiveNewAction(ActionToDo);
    }
}
