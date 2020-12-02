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
    /// Gives IHM Main the user currently logged in, his last connection to the server, and his lists of players and worlds.
    /// </summary>
    /// <param name="localUser">Last connection of the user to the server, contains :
    ///  - user credentials, 
    ///  - server credentials, 
    ///  - a list of the user's players, 
    ///  - and a list of the user's worlds.
    /// </param>
    void GiveLocalUser(LocalUser localUser);
}
