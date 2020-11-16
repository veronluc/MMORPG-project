using System;
using System.Collections.Generic;
using AI12_DataObjects;

namespace Server.Data
{
    public static class WorldsManager
    {
        /// <summary>
        /// List of World instances on the server
        /// </summary>
        private static List<World> onlineWorlds = new List<World>();

        /// <summary>
        /// Get the list of World instnace on the server
        /// </summary>
        /// <returns></returns>
        public static List<World> GetOnlineWorlds()
        {
            return onlineWorlds;
        }

        /// <summary>
        /// Add a World instance to the list of availables World of the server
        /// </summary>
        /// <param name="world"></param>
        public static void AddWorld(World world)
        {
            onlineWorlds.Add(world);
        }

        /// <summary>
        /// Add a Player instance to a World
        /// </summary>
        /// <param name="newPlayer">Instance of the new Player</param>
        /// <param name="world">Instance of the World</param>
        public static void AddPlayerToWorld(Player newPlayer, World world)
        {
            // Check if the user is already in the list by looking at its ID
            onlineWorlds.ForEach(onlineWorld =>
            {
                if (onlineWorld.id == world.id)
                {
                    WorldManager.AddPlayerToWorld(world, newPlayer);
                }
            });
        }

        /// <summary>
        /// List Users connected to the World
        /// </summary>
        /// <param name="world">Instance of the World</param>
        /// <returns></returns>
        public static List<User> GetPlayersUsers(World world)
        {
            List<User> users = new List<User>();
            world.Players.ForEach(player =>
            {
                users.Add(player.user);
            });
            return users;
        }
    }
}
