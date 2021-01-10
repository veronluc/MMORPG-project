
using AI12_DataObjects;
using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
[Serializable]
public class ConfirmationUserConnectionToWorldPacket : Packet
{
    World world;
    User user;
    Player player;

    public ConfirmationUserConnectionToWorldPacket(World pWorld, User pUser, Player pPlayer)
    {
        world = pWorld;
        user = pUser;
        player = pPlayer;
    }
    public override void Handle(Client c)
    {

        c.data.ReceiveWorld(user, world, player);
        c.DebugIt("Client received connexion confirmation.");
    }

    public override void Handle(GameServer s)
    {
        throw new System.NotImplementedException();
    }
}
