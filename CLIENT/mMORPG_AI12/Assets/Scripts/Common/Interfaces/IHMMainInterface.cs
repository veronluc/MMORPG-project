using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

using AI12_DataObjects;

public interface IHMMainInterface
{

    /// <summary>
    /// Loads the first application's scene
    /// </summary>
    void LoadMainScene();

    /// <summary>
    /// Displays all users and worlds
    /// </summary>
    /// <param name="usersList">All users</param>
    /// <param name="worldsList">All worlds</param>
    void DisplayListUsersWorlds(List<User> usersList, List<World> worldsList);

    /// <summary>
    /// Displays all worlds
    /// </summary>
    /// <param name="worlds">All worlds</param>
    void DisplayNewAvailableWorld(List<World> worlds);

    /// <summary>
    /// Displays all users
    /// </summary>
    /// <param name="users">All users</param>
    void DisplayListUser(List<User> users);

    /// <summary>
    /// Give IHM Main the current logged-in user
    /// </summary>
    /// <param name="user">Current logged-in user</param>
    void giveUser(User user);

    /// <summary>
    /// Give IHM Main the last server connection of the logged-in user
    /// </summary>
    /// <param name="ip">Ip address of the last server connection</param>
    /// <param name="port">Port of the last server connection</param>
    void giveLastConnection(String ip, String port);
}
