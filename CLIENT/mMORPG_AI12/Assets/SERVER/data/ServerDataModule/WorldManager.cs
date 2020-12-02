using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class WorldManager
{
    /// <summary>
    /// Add a Player instance to a World
    /// </summary>
    /// <param name="world"></param>
    /// <param name="newPlayer"></param>
    public static void AddPlayerToWorld(World world, Player newPlayer)
    {
        // If no players, create the player list with the new Player
        if (world.players == null)
        {
            world.players = new List<Player> { newPlayer };
        } else
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

    public static GameState GenerateGameState(World w)
    {
        GameState g;
        int NB_TILES = w.sizeMap;
        if (w.gameState == null)
        {
            // Generate the tiles
            Tile[,] tiles = new Tile[NB_TILES, NB_TILES];
            for (int i = 0; i < tiles.Rank; i++)
            {
                for (int j = 0; j < tiles.GetLength(i); j++)
                {
                    tiles[i, j] = new TilePlain("" + i + "," + j, new Location(i, j), "?");
                }
            }
            // Add Players (should contain only the creator player btw) then monsters
            List<Entity> all = new List<Entity>(w.players);
            all.AddRange(w.monstersList);
            g = new GameState(
                0,
                0,
                all,
                tiles
            );
        } else
        {
            // Remove every player except the one of the creator
            g = w.gameState;
            g.turns.RemoveAll(p =>
                typeof(Player).IsInstanceOfType(p) &&
                ((Player) p).user.id == w.creator.id
            );
        }
        return g;
    }
}