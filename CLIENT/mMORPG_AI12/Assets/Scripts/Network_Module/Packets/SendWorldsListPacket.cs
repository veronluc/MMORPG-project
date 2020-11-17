using AI12_DataObjects;
using Server.Network.Messages;
using System.Collections;
using System.Collections.Generic;

public class SendWorldsListPacket : Packet
{
    List<World> worlds;
   public SendWorldsListPacket(List<World> pWorlds)
    {
        worlds = pWorlds;
    }

    public override void Handle(Client c)
    {
        c.data.ReceiveListWorlds(worlds);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
