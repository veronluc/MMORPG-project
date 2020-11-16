using System;
using System.Collections.Generic;
using AI12_DataObjects;

namespace Server.Data
{
    public static class WorldManager
    {
        /// <summary>
        /// Add a Player instance to a World
        /// </summary>
        /// <param name="world"></param>
        /// <param name="newPlayer"></param>
        public static void AddPlayerToWorld(World world, Player newPlayer)
        {
            bool exists = false;
            world.Players.ForEach(player =>
            {
                // If the player is already in the world, update its information
                if (player.User.Id == newPlayer.User.Id)
                {
                    player = newPlayer;
                    exists = true;
                }
            });

            // If the player isn't already in the world, add it
            if (!exists)
            {
                world.Players.Add(newPlayer);
            }
        }
    }
}
