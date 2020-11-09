using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHMGameInterface {
        /// <summary>
        /// Launch the game. Start the display of the game view
        /// </summary>
        void launch_game();

        /// <summary>
        /// Diplays the message sent by the Data module in the chat
        /// </summary>
        /// <param name="message">New message to display</param>
        void display_Message();

        /// <summary>
        /// Update the display of the user. It will ask to Data module the new position of each entities and their caracteristics (life point, mana point...)
        /// </summary>
        void update_Display();

        /// <summary>
        /// Notifies the actual user that it can do an action. It means he can use a skill (if he has not already do it) or move (if he still have movement point)
        /// </summary>
        void notify_action_possible();

        /// <summary>
        /// Displays on user's screen that the server has stopped
        /// </summary>
        void display_Server_Stop();

        /// <summary>
        /// Displays on user's screen that the user has logout 
        /// </summary>
        /// <param name="user">user that just log out</param>
        void display_User_Logout();
}
