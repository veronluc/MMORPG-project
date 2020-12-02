using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SendActionToClient : Packet
{
    GameState state;
    public SendActionToClient(GameState pState)
    {
        state = pState;
    }
    public override void Handle(Client c)
    {
        c.data.ReceiveAction(state);
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }
}
