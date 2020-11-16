using System;
using System.Collections.Generic;
using AI12_DataObjects;

namespace Server.Data
{
    public static class WorldsManager
    {
        private static List<World> onlineWorlds = new List<World>();

        public static List<World> GetOnlineWorlds()
        {
            return onlineWorlds;
        }

        public static void AddWorld(World world)
        {
            onlineWorlds.Add(world);
        }

        public static void AddUserToWorld(User user, World world)
        {
            // Check if the user is already in the list by looking at its ID
            onlineWorlds.ForEach(onlineWorld =>
            {
                onlineWorld.Players.ForEach(player =>
                {
                    if (player.name == user.id)
                    {

                    }
                });
            });
        }
    }
}
