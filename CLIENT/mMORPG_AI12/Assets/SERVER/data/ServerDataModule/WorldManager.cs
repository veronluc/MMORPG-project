using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        world.players.ForEach(player =>
        {
            // If the player is already in the world, update its information
            if (player.user.id == newPlayer.user.id)
            {
                player = newPlayer;
                exists = true;
            }
        });

        // If the player isn't already in the world, add it
        if (!exists)
        {
            world.players.Add(newPlayer);
        }
    }
}