using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

using AI12_DataObjects;

public class IHMMainInterfaceImpl : IHMMainInterface
{

    //TO DO: Implement functions

    public void LoadMainScene()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Ask for an update of the displayed lists of Users and Worlds in the IHM
    /// </summary>
    /// <param name="usersList">The updated list of Users to display</param>
    /// <param name="worldsList">The updated list of Worlds to display</param>
    public void DisplayListUsersWorlds(List<User> usersList, List<World> worldsList)
    {
        //Retrieves the instance of MainConnectedScreen
        MainConnectedScreen mainConnectedScreen = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>();

        //Calls its update functions separately
        mainConnectedScreen.UpdateListUsersDisplay(usersList);
        mainConnectedScreen.UpdateListWorldsDisplay(worldsList);
    }

    /// <summary>
    /// Ask for an update of the displayed list of Worlds in the IHM
    /// </summary>
    /// <param name="worlds">The updated list of Worlds to display</param>
    public void DisplayNewAvailableWorld(List<World> worlds)
    {
        //Retrieves the instance of MainConnectedScreen and calls its update function
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .UpdateListWorldsDisplay(worlds);
    }

    /// <summary>
    /// Update the list of users displayed in the main screen
    /// </summary>
    /// <param name="users">New list of users</param>
    public void DisplayListUser(List<User> users)
    {
        //Retrieves the instance of MainConnectedScreen and calls its update functions separately
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .UpdateListUsersDisplay(users);
    }

    public void DisplayUserDetail(string token)
    {
        throw new System.NotImplementedException();
    }

    public void DisplayWorldDetail(World world)
    {
        throw new System.NotImplementedException();
    }

    public void GiveLocalUser(LocalUser localUser)
    {
        // TODO
    }
}
