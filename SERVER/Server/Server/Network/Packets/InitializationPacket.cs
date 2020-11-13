using Server.Network.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Network.Packets
{
    [Serializable]
    class InitializationPacket : Packet
    {
        private int clientID;
        public InitializationPacket(int pClientId)
        {
            clientID = pClientId;
        }

        public override void Handle(Client c)
        {
            c.myId = clientID;
        }

        public override void Handle(GameServer s)
        {
            throw new NotImplementedException("Méthode ne doit pas être appelée");
        }
    }
}



