using System;
using System.Collections.Generic;
using AI12_DataObjects;
public interface NetworkInterface
{
    /// <summary>
    /// Send a list of all worlds to the user.
    /// </summary>
    /// <param name="user">The destination user</param>
    /// <param name="worlds">List of worlds</param>
    void SendWorldsList(User user, List<World> worlds);

    /// <summary>
    /// Send a user list of all user to the user.
    /// </summary>
    /// <param name="user">Destination User</param>
    /// <param name="users">User list to send</param>
    void SendUsersList(User user, List<User> users);

    /// <summary>
    /// Send a list of users in a specific world to a user.
    /// </summary>
    /// <param name="user">The destination user</param>
    /// <param name="users">List of user connected to the world</param>
    /// <param name="world">World we need to know who is connected to</param>
    void SendUsersListFromWorld(User user, List<User> users, World world);

    /// <summary>
    /// Send a message to a client (user)
    /// </summary>
    /// <param name="user">Destionation user</param>
    /// <param name="message">Message to send</param>
    void SendMessageToUser(User user, Message message);

    /// <summary>
    /// Send an action a Player as to do to a user
    /// </summary>
    /// <param name="user">Destination User</param>
    /// <param name="action">Action to perform</param>
    /// <param name="player">Player of the world who is doing the action</param>
    void SendActionToUser(User user, AI12_DataObjects.Action action, Player player);

    /// <summary>
    /// Send a monster action to a client.
    /// </summary>
    /// <param name="user">Destination user</param>
    /// <param name="action">Action to perform</param>
    /// <param name="monster">Monster who is doing the action</param>
    void SendActionToUser(User user, AI12_DataObjects.Action action, Monster monster);

    /// <summary>
    /// Send the result of a request about a user connexion to a world
    /// </summary>
    /// <param name="user">Destination user</param>
    /// <param name="world">World concerned</param>
    /// <param name="result">Result of the request</param>
    /// <param name="message">Result message</param>
    void SendConfirmationUserConnectionToWorld(User user, World world, bool result, string message);

    /// <summary>
    /// Send a message to a user that the server is going to shutdown
    /// </summary>
    /// <param name="user">Destination user</param>
    void SendStopServer(User user);

    /// <summary>
    /// Send a message to a user that a user has loged out form the world.
    /// </summary>
    /// <param name="userDestination">Destination user</param>
    /// <param name="userDisconnected">The disconnected user</param>
    void SendUserDisconnectedWorld(User userDestination, User userDisconnected);

    /// <summary>
    /// Send a message to a user that a user has loged out from the server.
    /// </summary>
    /// <param name="userDisconnected">The disconnected user</param>
    /// <param name="userDestination">Destination User</param>
    void SendUserDisconnectedServer(User userDestination, User userDisconnected);

    /// <summary>
    /// Send Users and worlds to a specific user
    /// </summary>
    /// <param name="user">Destination user</param>
    /// <param name="users">List of connected users</param>
    /// <param name="worlds">List of worlds</param>
    void SendListUsersWorlds(User user, List<User> users, List<World> worlds);
}
