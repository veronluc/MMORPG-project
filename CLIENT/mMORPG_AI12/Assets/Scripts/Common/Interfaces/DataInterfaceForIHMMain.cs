using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System;

public interface DataInterfaceForIHMMain
{
    /// <summary>
    /// Create an user locally
    /// </summary>
    /// <param name="login">Login identifier</param>
    /// <param name="password">Password</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="birthDate">Birthdate</param>
    /// <param name="image">Image</param>
    void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image);

    /// <summary>
    /// Update user's information locally
    /// </summary>
    /// <param name="login">Login identifier</param>
    /// <param name="password">Password</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="birthDate">Birthdate</param>
    /// <param name="image">Image</param>
    void UpdateUser(string login, string password, string firstName, string lastName, string birthDate, string image);

    /// <summary>
    /// Create a local session for the user
    /// If the user was connected to a server during its last session,
    /// the client connects directly to this server
    /// </summary>
    /// <param name="pseudo">User pseudo</param>
    /// <param name="password">User pseudo</param>
    /// <returns>
    /// IP address of the server (if previously connected) or empty string
    /// </returns>
    string CreateUserSession(string pseudo, string password);

    /// <summary>
    /// Connect the session to the server
    /// </summary>
    /// <param name="ipServer">IP address of the server</param>
    /// <param name="port">Port of the server</param>
    void ConnectSessionToServer(string ipServer, string port);

    /// <summary>
    /// Load a local World instance to the server
    /// </summary>
    /// <param name="world">World instance</param>
    void LoadWorld(ref World world);

    /// <summary>
    /// Join a world on the current server
    /// </summary>
    /// <param name="player">Player instance to join the World</param>
    /// <param name="worldId">World unique identifier</param>
    void JoinWorld(Player player, string worldId);

    /// <summary>
    /// Get details of a world
    /// </summary>
    /// <param name="worldId">World unique identifier</param>
    void GetWorldDetails(string worldId);

    /// <summary>
    /// Get details of a user
    /// </summary>
    /// <param name="userId">User unique identifier</param>
    void GetUserDetails(string userId);

    /// <summary>
    /// Log out the current user and end the session
    /// </summary>
    void LogOut();

    /// <summary>
    /// Save locally a world instance
    /// </summary>
    /// <param name="world">World instance</param>
    void SaveWorld(World world);

    /// <summary>
    /// Restore locally a world instance
    /// </summary>
    /// <param name="name">Name of the World instance</param>
    /// <returns>
    /// World instance
    /// </returns>
    [Obsolete("Go through the local users instead")]
    World RestoreWorld(string name);

    /// <summary>
    /// Create a player profile locally
    /// </summary>
    /// <param name="entityClass">Caracteristics</param>
    /// <param name="name">Name of the player</param>
    /// <returns>
    /// Player instance
    /// </returns>
    Player CreatePlayer(EntityClass entityClass, string name);

    /// <summary>
    /// List local players profiles
    /// </summary>
    /// <returns>
    /// List of players instances
    /// </returns>
    List<Player> ListPlayers();

    /// <summary>
    /// Delete a player profile locally
    /// </summary>
    /// <param name="player">Player instance to delete</param>
    void DeletePlayer(Player player);

    /// <summary>
    /// Edit a player profile locally
    /// </summary>
    /// <param name="player">Player instance with updated properties</param>
    /// <returns>
    /// Updated player instance
    /// </returns>
    Player EditPlayer(Player editedPlayer);

    /// <summary>
    /// OBSOLETE Create a world locally
    /// </summary>
    /// <returns>
    /// Created world instance
    /// </returns>
    [Obsolete("Use the method definition under")]
    World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, List<Player> players, List<Monster> monsters, User creator, GameState gameState);

    /// <summary>
    /// Create a world locally
    /// </summary>
    /// <returns>
    /// Created world instance
    /// </returns>
    World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, User creator);

    /// <summary>
    /// Get list of online Worlds instances
    /// </summary>
    void GetWorlds();
}