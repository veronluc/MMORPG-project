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
        c.data.setUserId(clientID.ToString());
        //TO DO : Informer data (client) que connexion serveur reussie ou non
        SendUserInfosPacket msg = new SendUserInfosPacket(c.data.GetUser());
        c.SendData(msg);
    }


    public override void Handle(GameServer c)
    {
        throw new NotImplementedException();
    }

}
