using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHMGameInterfaceImpl : IHMGameInterface
{

    /// <summary>
    /// Launch the game. Start the display of the game view
    /// </summary>
    public void LaunchGame()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Diplays the message sent by the Data module in the chat
    /// </summary>
    /// <param name="message">New message to display</param>
    public void DisplayMessage()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Update the display of the user. It will ask to Data module the new position of each entities and their caracteristics (life point, mana point...)
    /// </summary>
    public void UpdateDisplay()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Notifies the actual user that it can do an action. It means he can use a skill (if he has not already do it) or move (if he still have movement point)
    /// </summary>
    public void NotifyActionPossible()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Displays on user's screen that the server has stopped
    /// </summary>
    public void DisplayServerStop()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Displays on user's screen that the user has logout 
    /// </summary>
    /// <param name="user">user that just log out</param>
    public void DisplayUserLogout()
    {
        throw new System.NotImplementedException();
    }
}
