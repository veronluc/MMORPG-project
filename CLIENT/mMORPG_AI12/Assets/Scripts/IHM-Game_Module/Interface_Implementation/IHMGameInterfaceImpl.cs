using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHMGameInterfaceImpl : IHMGameInterface
{

    /// <summary>
    /// Launch the game. Start the display of the game view
    /// </summary>
    public void launch_game()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Diplays the message sent by the Data module in the chat
    /// </summary>
    /// <param name="message">New message to display</param>
    public void display_Message()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Update the display of the user. It will ask to Data module the new position of each entities and their caracteristics (life point, mana point...)
    /// </summary>
    public void update_Display()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Notifies the actual user that it can do an action. It means he can use a skill (if he has not already do it) or move (if he still have movement point)
    /// </summary>
    public void notify_action_possible()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Displays on user's screen that the server has stopped
    /// </summary>
    public void display_Server_Stop()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Displays on user's screen that the user has logout 
    /// </summary>
    /// <param name="user">user that just log out</param>
    public void display_User_Logout()
    {
        throw new System.NotImplementedException();
    }
}
