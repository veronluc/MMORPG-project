using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Network.Messages
{
    [Serializable]
    public abstract class Packet
    {
        /*
        protected Client client;
        protected GameServer server;
        protected abstract void RunHandle();

        public void Handle(Client c)
        {
            client = c;
            RunHandle();
        }
        public void Handle(GameServer s)
        {
            server = s;
            RunHandle();
        }*/

        public abstract void Handle(Client c);

        public  abstract void Handle(GameServer s);
    }
}
