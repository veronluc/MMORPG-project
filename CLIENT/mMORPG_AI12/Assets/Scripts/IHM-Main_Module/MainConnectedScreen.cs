using System;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class MainConnectedScreen : MonoBehaviour
{
    // Properties
    private string serverIp;
    private string port;
    private List<User> usersList;
    private List<World> worldsList;
    private DataInterfaceForIHMMain dataInterface;
    
    // Screens
    // private ConnexionScreen connexionScreen; // TODO : develop class
    // private ConnectToAServerScreen connectToAServerScreen; // TODO : develop class
    // private ManageMyWorldsScreen manageMyWorldsScreen; // TODO : develop class
    // private ManageMyCharactersScreen manageMyCharactersScreen; // TODO : develop class

    public void Awake()
    {
        dataInterface = new DataInterfaceForIHMMainImpl();
    }

    public void Start()
    {
        
        // TODO : link gameObjects

    }
    
    public void DisplayCreateProfileScreen() {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Update the current list of users connected on the server
    /// <param name="newListUsers">Users currently connected</param>
    /// </summary>
    public void UpdateListUsersDisplay(List<User> newListUsers) {
        usersList = newListUsers;
        // TODO
    }
    
    /// <summary>
    /// Update the current list of worlds available on the server
    /// <param name="newListWorlds">Worlds currently available</param>
    /// </summary>
    public void UpdateListWorldsDisplay(List<World> newListWorlds)
    {
        worldsList = newListWorlds;
        // TODO
    }

    /// <summary>
    /// Connect the local user to a specific server
    /// </summary>
    /// <param name="ip">Server ip address for connexion</param>
    /// <param name="port">Port for connexion</param>
    private void ConnectToAServer(string ip, string port) {
        // TODO: remove user when function signature will change
        try
        {
            dataInterface.ConnectSessionToServer(null, ip, port);

        }
        catch (Exception e)
        {
            // TODO : handle server connexion errors
        }

        World world = createTestWorld();
        dataInterface.LoadWorld(world);
    }
    
    private void OnClickManageMyWorlds() {
        throw new System.NotImplementedException();
    }

    private void OnClickManageMyCharacters() {
        throw new System.NotImplementedException();
    }

    private void OnClickOneUser() {
        throw new System.NotImplementedException();
    }

    private void OnClickOneWorld() {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Request to join a specific world regarding its identifier
    /// </summary>
    /// <param name="idWorld">Identifier of the world to join</param>
    private void JoinWorld(string idWorld) {

        try
        {
            dataInterface.JoinWorld(idWorld);
        }
        catch (Exception e)
        {
            // TODO : handle join world errors
        }
    }

    /// <summary>
    /// Log out for the server ? The authentication ? To review
    /// </summary>
    private void Logout()
    {
        // TODO : review
        try
        {
            dataInterface.LogOut();
        }
        catch (Exception e)
        {
            // TODO : handle logout errors
        }

    }
    
    // TODO : add function to handle save before logging out

    // TODO : what is GameBoard object ?
    private void ChangeScene(/*GameBoard gameBoard*/) {
        throw new System.NotImplementedException();
    }
    
    // TESTS functions ---------
    private World createTestWorld()
    {
        World newWorld = new World();
        newWorld.name = "World1";
        newWorld.sizeMap = 50;
        newWorld.gamemode = GameMode.pvp;
        newWorld.realDeath = true;
        newWorld.difficulty = 2;
        newWorld.roundTimeSec = 120;
        newWorld.nbMaxPlayer = 20;
        newWorld.nbMaxMonsters = 50;
        newWorld.nbShops = 50;
        newWorld.hasCity = true;
        newWorld.hasPlain = true;
        newWorld.hasSwamp = true;
        newWorld.hasRiver = true;
        newWorld.hasForest = true;
        newWorld.hasRockyPlain = true;
        newWorld.hasMontain = true;
        newWorld.hasSea = true;
        newWorld.players = null;
        newWorld.monsters = null;
        newWorld.creator = null;
        newWorld.gameState = null;

        return newWorld;
    }


}