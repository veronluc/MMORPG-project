using AI12_DataObjects;
using Server.Network.Messages;
using System.Collections;
using System.Collections.Generic;

public class SendActionMonsterToClient : Packet
{
    public Action action;
    public Monster monster;
    public SendActionMonsterToClient(Monster pMonster, Action pAction)
    {
        action = pAction;
        monster = pMonster;
    }
    public override void Handle(Client c)
    {
        c.data.ReceiveAction(action, monster);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
