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
    void DisplayNewConnectedUser(List<User> users);

    /// <summary>
    /// Diplays every user's details
    /// </summary>
    /// <param name="token">The user's token</param>
    void DisplayUserDetail(string token);

    /// <summary>
    /// Displays every information about the world specified in parameter
    /// </summary>
    /// <param name="world"></param>
    void DisplayWorldDetail(World world);

    /// <summary>
    /// Diplays a log out confirmation
    /// </summary>
    void IHMLogOutConfirmation();

    /// <summary>
    /// Diplays the disconnected owner and stops the game
    /// </summary>
    /// <param name="user">The owner of the game</param>
    void DisplayOwnerDisconnected(User user);

    /// <summary>
    /// Diplays the disconnected user
    /// </summary>
    /// <param name="user">The user who is disconnected</param>
    void DisplayUserLogOut(User user);

    /// <summary>
    /// Notify that the server has been shut down
    /// </summary>
    void ServerStopped();
}
