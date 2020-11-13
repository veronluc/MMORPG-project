using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Network.Messages
{
    [Serializable]
    public abstract class Packet
    {
        public abstract void Handle(GameServer s);
        public abstract void Handle(Client c);
    }

}
