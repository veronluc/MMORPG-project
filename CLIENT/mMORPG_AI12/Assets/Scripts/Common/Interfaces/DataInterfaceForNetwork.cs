using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public interface DataInterfaceForNetwork
{
    /// <summary>
    /// Receive a list of World instances (used for new or update)
    /// </summary>
    /// <param name="worlds">List of worlds</param>
    void ReceiveListWorlds(List<World> worlds);

    /// <summary>
    /// Receive a list of User instances (used for new or update)
    /// </summary>
    /// <param name="users">List of users</param>
    void ReceiveListUsers(List<User> users);

    /// <summary>
    /// Receive a list of User instances of a specific World (used for new or update)
    /// </summary>
    /// <param name="users">List of users</param>
    /// <param name="world">World instance</param>
    void ReceiveListUsersFromWorld(List<User> users, World world);

    /// <summary>
    /// Receive a list of User instances of a specific World (used for new or update)
    /// </summary>
    /// <param name="users">List of users</param>
    /// <param name="worlds">List of available worlds</param>
    void ReceiveListUsersWorlds(List<User> users, List<World> worlds);

    /// <summary>
    /// Receive a message
    /// </summary>
    /// <param name="message">Message content</param>
    void ReceiveMessage(Message message);

    /// <summary>
    /// Receive the new game state following an action
    /// </summary>
    /// <param name="newGameState">The new GameState</param>
    void ReceiveAction(GameState newGameState);

    /// <summary>
    /// Receive a world instance in order to launch the game
    /// </summary>
    /// <param name="world">World instance</param>
    void ReceiveWorld(World world);


    /// <summary>
    /// Receive a world instance in order to launch the game
    /// </summary>
    /// <param name="user">User instance</param>
    /// <param name="world">World instance</param>
    /// <param name="player">Player instance</param>
    void ReceiveWorld(User user, World world, Player player);

    /// <summary>
    /// Receive an user instance
    /// </summary>
    /// <param name="user">User instance</param>
    void ReceiveUser(User user);

    /// <summary>
    /// Server disctonnection (normal)
    /// </summary>
    void DisconnectServerStop();

    /// <summary>
    /// Server disctonnection (error)
    /// </summary>
    void DisconnectServerError();

    /// <summary>
    /// User disconnected from the World it belongs
    /// </summary>
    /// <param name="user">User instance</param>
    void UserDisconnectedFromWorld(User user);

    /// <summary>
    /// User disconnected from the World it owns
    /// </summary>
    /// <param name="user">User instance</param>
    void OwnerDisconnectedFromWorld(User user);

    /// <summary>
    /// User disconnected from the server it is connected to
    /// </summary>
    /// <param name="user">User instance</param>
    void UserDisconnectedFromServer(User user);
}
