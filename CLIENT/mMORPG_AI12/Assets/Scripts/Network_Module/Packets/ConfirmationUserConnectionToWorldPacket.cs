
using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
[Serializable]
public class ConfirmationUserConnectionToWorldPacket : Packet
{
    World world;
    User user;
    Player player;
    bool result;
    string message;

    public ConfirmationUserConnectionToWorldPacket(World pWorld, User pUser, Player pPlayer, bool pRes, string pMessage)
    {
        world = pWorld;
        user = pUser;
        player = pPlayer;
        result = pRes;
        message = pMessage;
    }
    public override void Handle(Client c)
    {
        //TO DO 
        //c.data.confirm...
        c.data.ReceiveWorld(user, world, player);
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
