using System.Collections;
using System.Collections.Generic;
using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class LocalUser
    {
        public List<Player> players { get; set; }
        public List<World> worlds { get; set; }
        public User user { get; set; }
        public ServerInfo lastServerConnection { get; set; }

        public LocalUser()
        {
            players = new List<Player>();
            worlds = new List<World>();
            user = null;
            lastServerConnection = null;
        }

        public LocalUser(User _user)
        {
            players = new List<Player>();
            worlds = new List<World>();
            user = _user;
            lastServerConnection = null;
        }
    }
}
