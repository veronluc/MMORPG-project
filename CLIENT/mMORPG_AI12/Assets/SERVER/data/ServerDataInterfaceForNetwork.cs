using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ServerDataInterfaceForNetwork
{
    /// <summary>
    /// Receive a message from a client
    /// </summary>
    /// <param name="message">Received Message instance</param>
    void ReceiveMessage(Message message);

    /// <summary>
    /// A new user connect to the server
    /// </summary>
    /// <param name="user">New connected User instance</param>
    void ReceiveUser(User user);

    /// <summary>
    /// Get next Player on the game
    /// </summary>
    /// <param name="world">World instance</param>
    void ReceiveNewAction(World world);

    /// <summary>
    /// An action is performed on a client
    /// </summary>
    /// <param name="action">Action instance</param>
    void ReceiveNewAction(AI12_DataObjects.Action action);

    /// <summary>
    /// A new World is created on a client
    /// </summary>
    /// <param name="world">New World instance</param>
    void ReceiveNewWorld(World world);

    /// <summary>
    /// An User want to connect to a specified World
    /// </summary>
    /// <param name="player">Player instance</param>
    /// <param name="world">World instance</param>
    void ReceiveConnexionUserToWorld(Player player, string worldId);

    /// <summary>
    /// An User wants to obtain the Worlds instance of the server
    /// </summary>
    /// <param name="user">User instance</param>
    void UserAskWorldList(User user);

    /// <summary>
    /// An User wants to obtain the Users instance connected to the server
    /// </summary>
    /// <param name="user">User instance</param>
    void UserAskUsersList(User user);

    /// <summary>
    /// An User update its information in the client
    /// </summary>
    /// <param name="user">Modified User instance</param>
    void UserRefreshInfos(User user);

    /// <summary>
    /// An User wants to deconnect from the World instance where it plays
    /// </summary>
    /// <param name="user">User instance</param>
    void UserAskDisconnectFromWorld(User user);

    /// <summary>
    /// An User wants to deconnect from the server
    /// </summary>
    /// <param name="user">User instance</param>
    void UserAskDisconnectFromServer(User user);

    /// <summary>
    /// An User client disconnect brutally
    /// </summary>
    /// <param name="user">User instance</param>
    void UserBrutalDisconnected(User user);

    /// <summary>
    /// List worlds on server
    /// </summary>
    /// <returns>
    /// List of World instances
    /// </returns>
    List<World> GetWorlds();

    /// <summary>
    /// List users connected on server
    /// </summary>
    /// <returns>
    /// List of User instances
    /// </returns>
    List<User> GetUsers();
}
