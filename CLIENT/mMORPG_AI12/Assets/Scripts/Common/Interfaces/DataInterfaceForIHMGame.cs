﻿using AI12_DataObjects;

public interface DataInterfaceForIHMGame
{
    /// <summary>
    /// Send a message to the chat
    /// </summary>
    /// <param name="message">Message instance</param>
    void SendMessage(Message message);

    /// <summary>
    /// Make an action
    /// </summary>
    /// <param name="action">Instance of the action</param>
    void MakeAction(Action action);

    /// <summary>
    /// Get the current connected user
    /// </summary>
    /// <returns>
    /// Current user object
    /// </returns>
    User GetCurrentUser();

    /// <summary>
    /// Get the current play
    /// </summary>
    /// <returns>
    /// Current player object
    /// </returns>
    Player GetCurrentPlayer();

    /// <summary>
    /// Get the current world
    /// </summary>
    /// <returns>
    /// Current world object
    /// </returns>
    World GetCurrentWorld();
}
