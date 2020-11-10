using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public interface DataInterfaceForIHMGame
{
    /// <summary>
    /// Send a message to the chat
    /// </summary>
    /// <param name="idWorld">Identifier of the current world instance</param>
    /// <param name="text">Message content</param>
    void SendMessage(string idWorld, string text);

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
