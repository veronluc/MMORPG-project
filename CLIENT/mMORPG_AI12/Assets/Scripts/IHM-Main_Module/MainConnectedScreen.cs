using System;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using TMPro;
using UnityEngine.UI;

public class MainConnectedScreen : MonoBehaviour
{
    // Properties
    private string serverIp;
    private string port;
    private List<User> usersList;
    private List<World> worldsList;
    private IHMMainModule ihmMainModule;
    private DataInterfaceForIHMMain dataInterface;
    private GameObject usersManager;
    private GameObject worldsManager;
    private GameObject serverInformation;

    public void Awake()
    {
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
        this.dataInterface = ihmMainModule.dataInterface;
    }

    public void Start()
    {

        usersManager = GameObject.FindGameObjectWithTag("OnlineUsers");
        worldsManager = GameObject.FindGameObjectWithTag("OnlineWorlds");
        serverInformation = GameObject.FindGameObjectWithTag("InfoConnectedServer");
        
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
        usersManager.GetComponent<OnlineUsersManager>().SetUserList(newListUsers);
    }
    
    /// <summary>
    /// Update the current list of worlds available on the server
    /// <param name="newListWorlds">Worlds currently available</param>
    /// </summary>
    public void UpdateListWorldsDisplay(List<World> newListWorlds)
    {
        worldsList = newListWorlds;
        worldsManager.GetComponent<OnlineWorldsManager>().SetWorldList(newListWorlds);
    }

    /// <summary>
    /// Connect the local user to a specific server
    /// </summary>
    /// <param name="ip">Server ip address for connexion</param>
    /// <param name="port">Port for connexion</param>
    public void ConnectToAServer(string ip, string port) {
        try
        {
            // TODO : uncomment during integration
            //dataInterface.ConnectSessionToServer(ip, port);
        
        }
        catch (Exception e)
        {
            // handle server connexion errors
        }

        // Set the new server information (ip and port) and close the connection pop-up
        serverInformation.GetComponent<TextMeshProUGUI>().SetText("IP = " + ip + " - Port = " + port);
        GameObject.FindGameObjectWithTag("ServerConnection").GetComponent<ServerConnectionManager>().OpenClosePopup();
        
        
        // For tests purpose we populate users and worlds here (keep it for v1)
        
        // List<User> users = new List<User>();
        // users.Add(new User(){players = new List<Player>(), firstName = "Ines", lastName = "Ryder", login="iryder", birthDate = new DateTime(2000, 1, 1)});
        // users.Add(new User(){players = new List<Player>(), firstName = "Lucie",lastName = "Gratreau", login="lgratreau", birthDate = new DateTime(2000, 1, 1)});
        // users.Add(new User(){players = new List<Player>(), firstName = "Anais",lastName = "Mace", login="amace", birthDate = new DateTime(2000, 1, 1)});
        // users.Add(new User(){players = new List<Player>(), firstName = "Manuel",lastName = "Beaudru", login="mbeaudru", birthDate = new DateTime(2000, 1, 1)});
        // UpdateListUsersDisplay(users);
        
        // List<World> worlds = new List<World>();
        // worlds.Add(CreateTestWorld("Forest Map"));
        // worlds.Add(CreateTestWorld("Welcome to hell"));
        // worlds.Add(CreateTestWorld("Banana Land"));
        // worlds.Add(CreateTestWorld("Mario Land"));
        // UpdateListWorldsDisplay(worlds);

    }
    
    public void OnClickManageMyWorlds() {
        throw new System.NotImplementedException();
    }

    public void OnClickManageMyCharacters() {
        throw new System.NotImplementedException();
    }

    public void OnClickOneUser() {
        throw new System.NotImplementedException();
    }

    public void OnClickOneWorld() {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Request to join a specific world regarding its identifier
    /// </summary>
    /// <param name="idWorld">Identifier of the world to join</param>
    public void JoinWorld(string idWorld) {
        
        Debug.Log("Join World -> " + idWorld);

        try
        {
            // TODO : uncomment during integration
            //dataInterface.JoinWorld(idWorld);
        }
        catch (Exception e)
        {
            // handle join world errors
        }
    }

    /// <summary>
    /// Log out of the server
    /// </summary>
    public void LogOutServer()
    {
        // TODO : review
        try
        {
            // TODO : uncomment during integration
            // dataInterface.LogOutServer();
        }
        catch (Exception e)
        {
            // handle logout errors
        }

        serverInformation.GetComponent<TextMeshProUGUI>().SetText("None");
        UpdateListUsersDisplay(new List<User>());
        UpdateListWorldsDisplay(new List<World>());
    }
    
    
    // TESTS functions ---------
    private World CreateTestWorld(string name)
    {
        World newWorld = new World();
        newWorld.name = name;
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
        newWorld.creator = new Player() {name = "Gus le Chat"};
        newWorld.gameState = null;

        return newWorld;
    }


}