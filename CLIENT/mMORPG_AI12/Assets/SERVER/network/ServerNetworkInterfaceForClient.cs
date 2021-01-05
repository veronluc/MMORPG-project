using AI12_DataObjects;
using Server.Network.Messages;
using System.Collections.Generic;

/// <summary>
/// The interface given to data to use network module methods
/// This interface allows data to use the network functionalitites
/// </summary>
public interface ServerNetworkInterfaceForClient
{
    /// <summary>
    /// Sends a list of worlds to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="worlds">The list of worlds we want to send</param>
    void SendWorldsList(User user, List<World> worlds);

    /// <summary>
    /// Sends a list of users to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="users">The user list we want to send</param>
    void SendUsersList(User user, List<User> users);

    /// <summary>
    /// Sends a list of users in a specific world world to the client (the given user)
    /// </summary>
    /// <param name="user">The user we want to send the list to</param>
    /// <param name="users">The user list we want to send</param>
    /// <param name="world">The world</param>
    void SendUsersListFromWorld(User user, List<User> users, World world);

    /// <summary>
    /// Send a message to the given user client
    /// </summary>
    /// <param name="user">The user we want to send the message to</param>
    /// <param name="message">The message to send</param>
    void SendMessageToUser(User user, Message message);

    /// <summary>
    /// Send an action to the given user
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    /// <param name="gameState">The gamestate with the action being made</param>
    void SendActionToUser(User user, GameState gameState);

    /// <summary>
    /// Send a confirmation that the user has connected to a world
    /// </summary>
    /// <param name="user">The user who connected</param>
    /// <param name="world">The world concerned</param>
    /// <param name="player">The player connected</param>
    /// <param name="result">The result of the connection, true is good, false is not good</param>
    /// <param name="message">The message of the result</param>
    void SendConfirmationUserConnectionToWorld(User user, World world, Player player, bool result, string message);

    /// <summary>
    /// Send a message to the user when the server is about to stop
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    void SendStopServer(User user);

    /// <summary>
    /// Send a message saying that a player has disconnected from a given world
    /// </summary>
    /// <param name="userDestination">The User we want to send to</param>
    /// <param name="userDisconnected">The player who has disconnected</param>
    void SendUserDisconnectedWorld(User userDestination, User userDisconnected);

    /// <summary>
    /// Send a message saying that a player has disconnected from a given world (and is theowner of the world)
    /// </summary>
    /// <param name="userDestination">The User we want to send to</param>
    /// <param name="userDisconnected">The player who has disconnected</param>
    void SendOwnerDisconnectedWorld(User userDestination, User userDisconnected);

    /// <summary>
    /// Send a message saying that a player has disconnected from the server
    /// </summary>
    /// <param name="userDestination">The User we want to send to</param>
    /// <param name="userDisconnected">The player who has disconnected</param>
    void SendUserDisconnectedServer(User userDestination, User userDisconnected);

    /// <summary>
    /// Send two lists of users and worlds to the user 
    /// </summary>
    /// <param name="user">The user we want to send to</param>
    /// <param name="users">The list of users</param>
    /// <param name="worlds">The list of worlds</param>
    void SendListUsersWorlds(User user, List<User> users, List<World> worlds);

    /// <summary>
    /// Sends a packet to the user represented by its id
    /// </summary>
    /// <param name="idString">The id of the user</param>
    /// <param name="packet">The packet we want to send</param>
    void SendPacket(string idString, Packet packet);
}
