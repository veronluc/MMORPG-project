using AI12_DataObjects;
using Server.Network.Messages;
using System.Collections;
using System.Collections.Generic;

public class SendActionPlayerToClient : Packet
{
    public Action action;
    public Player player;
    public SendActionPlayerToClient(Player pPlayer, Action pAction)
    {
        action = pAction;
        player = pPlayer;
    }
    public override void Handle(Client c)
    {
        c.data.ReceiveAction(action, player);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
