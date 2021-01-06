﻿using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IHMGameInterfaceImpl : IHMGameInterface
{
    public GameManager gameManager { get; set; }
    IHMGameModule ihmGameModule;

    /// <summary>
    /// Launch the game. Start the display of the game view
    /// </summary>
    public void LaunchGame(User user, World world, GameState gameState, Player player)
    {
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        ihmGameModule.player = player;
        ihmGameModule.user = user;
        ihmGameModule.gameState = gameState;
        ihmGameModule.world = world;
        SceneManager.LoadScene("IHMGame");
        
        GameObject.FindGameObjectWithTag("Tilemap").GetComponent<GameZone>().CreationMap();
    }

    /// <summary>
    /// Diplays the message sent by the Data module in the chat
    /// </summary>
    /// <param name="message">New message to display</param>
    public void DisplayMessage(Message message)
    {
        gameManager.SendMessageToChat(message, ChatMessage.MessageType.playerMessage);
    }

    /// <summary>
    /// Update the display of the user. It will ask to Data module the new position of each entities and their caracteristics (life point, mana point...)
    /// </summary>
    public void UpdateDisplay(GameState gameState)
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
