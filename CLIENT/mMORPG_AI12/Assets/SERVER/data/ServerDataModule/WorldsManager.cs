using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// <returns></returns>
    public static World AddPlayerToWorld(Player newPlayer, string worldId)
    {
        // Check if the user is already in the list by looking at its ID
        World w = null;
        onlineWorlds.ForEach(onlineWorld =>
        {
            if (onlineWorld.id == worldId)
            {
                WorldManager.AddPlayerToWorld(onlineWorld, newPlayer);
                w = onlineWorld;
            }
        });
        return w;
    }

    /// <summary>
    /// List Users connected to the World
    /// </summary>
    /// <param name="world">Instance of the World</param>
    /// <returns></returns>
    public static List<User> GetPlayersUsers(World world)
    {

        List<User> users = new List<User>();
        if (world.players != null)
        {
            world.players.ForEach(player =>
            {
                users.Add(player.user);
            });
        }
        return users;
        
    }

    public static World getWorldFromId(string idWorld)
    {
        foreach(World world in onlineWorlds)
        {
            if (world.id == idWorld)
            {
                return world;
            }
        }
        return null;
    }

    /*
    /// <summary>
    /// Remove the world own by an user
    /// </summary>
    /// <param name="user">Owner</param>
    /// <returns>Worlds erased</returns>
    public static List<World> RemoveWorldOwnByUser(User user)
    {
        List<World> oldWorlds = onlineWorlds.FindAll(w => user.id == w.creator.id);
        onlineWorlds.RemoveAll(w => user.id == w.creator.id);
        return oldWorlds;
    }
    */

    /// <summary>
    /// Remove the world own by an user
    /// </summary>
    /// <param name="user">Owner</param>
    public static void RemoveWorldOwnByUser(User user)
    {
        onlineWorlds.RemoveAll(w => user.id == w.creator.id);
    }

    public static void UpdateWorldFromId(string idWorld, GameState game)
    {
        foreach (World world in onlineWorlds)
        {
            if (world.id == idWorld)
            {
                world.gameState = game;
            }
        }
    }
}