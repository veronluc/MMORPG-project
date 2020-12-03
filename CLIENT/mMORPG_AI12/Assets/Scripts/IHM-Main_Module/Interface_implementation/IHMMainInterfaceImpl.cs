using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

using AI12_DataObjects;

public class IHMMainInterfaceImpl : IHMMainInterface
{

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

    /// <summary>
    /// Gives IHM Main the user currently logged in, his last connection to the server, and his lists of players and worlds.
    /// </summary>
    /// <param name="localUser">Last connection of the user to the server, contains :
    ///  - user credentials, 
    ///  - server credentials, 
    ///  - a list of the user's players, 
    ///  - and a list of the user's worlds.
    /// </param>
    public void GiveLocalUser(LocalUser localUser)
    {
        Debug.Log("NEW GIVE : " + localUser.user.players.Count);
        
        //Retrieves the game object IHMMainModule
        GameObject iHMMainGameObject = GameObject.FindGameObjectWithTag("IHMMainModule");

        //Updates the server credentials in MainConnectedScreen
        //Class ServerInfo contains string "server" (Ip) and int "port"
        if (localUser.lastServerConnection != null)
        {
            iHMMainGameObject.GetComponent<MainConnectedScreen>().UpdateIpandPortDisplay(
                localUser.lastServerConnection.server, localUser.lastServerConnection.port.ToString());
        }

        //Set the current user credentials in IHMMainModule
        iHMMainGameObject.GetComponent<IHMMainModule>().localUser = localUser;

        //Updates the list of user worlds in ManageMyWorldScreen
        iHMMainGameObject.GetComponent<ManageMyWorldsScreen>().UpdateListWorldsDisplay(localUser.worlds);
        if (ScreensManager.GetCurrentScreen() == ScreensManager.AUTHENTICATION_MENU)
        {
            ScreensManager.ShowMainConnectedScreen();
        }

        // TODO V3
        //Updates the list of user players in ManageMyPlayersScreen (Not yet implemented)
        //iHMMainGameObject.GetComponent<ManageMyPlayersScreen>().UpdateListWorldsDisplay(localUser.players);
    }
}
