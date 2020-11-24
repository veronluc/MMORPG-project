using Server.Network;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class InitializationPacket : Packet
{
    private int clientID;

    public InitializationPacket(int pClientId)
    {
        clientID = pClientId;
    }

    public override void Handle(Client c)
    {
        c.DebugIt(c.ToString());
        c.currentUser.id = clientID.ToString();
        //TO DO : Informer data (client) que connexion serveur reussie ou non
        SendUserInfosPacket msg = new SendUserInfosPacket(c.currentUser);
        c.SendData(msg);
    }


    public override void Handle(GameServer c)
    {
        throw new NotImplementedException();
    }

}
