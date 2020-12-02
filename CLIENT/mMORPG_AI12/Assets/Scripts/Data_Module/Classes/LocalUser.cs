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

        public void AddWorld(World world)
        {
            worlds.Add(world);
        }

        public void ModifyWorld(World world)
        {
            worlds[worlds.FindIndex(w => w.id == world.id)] = world;
        }

        internal World GetWorld(string worldId)
        {
            return worlds.Find(w => w.id == worldId);
        }

        internal Player GetPlayer(string playerId)
        {
            return players.Find(p => p.id == playerId);
        }

        public void RemoveWorld(string worldId)
        {
            worlds.Remove(GetWorld(worldId));
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void ModifyPlayer(Player player)
        {
            players[players.FindIndex(p => p.id == player.id)] = player;
        }

        public void RemovePlayer(string playerId)
        {
            players.Remove(GetPlayer(playerId));
        }
    }
}
