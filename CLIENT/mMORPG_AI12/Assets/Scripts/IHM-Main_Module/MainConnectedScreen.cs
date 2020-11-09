using System.Collections.Generic;
using UnityEngine;

public class MainConnectedScreen : MonoBehaviour
{
    // Proprietes
    private string serverIp;
    private string port;
    private List<User> usersList; // TODO : retrieve User object when available
    private List<World> worldsList;

    // Ecrans
    private ConnexionScreen connexionScreen; // TODO : develop class
    private ConnectToAServerScreen connectToAServerScreen; // TODO : develop class
    private ManageMyWorldsScreen manageMyWorldsScreen; // TODO : develop class
    private ManageMyCharactersScreen manageMyCharactersScreen; // TODO : develop class

    public void Awake()
    {
        // TODO : when classes available : add parameters if needed
        connexionScreen = new ConnexionScreen();
        connectToAServerScreen = new ConnectToAServerScreen();
        manageMyWorldsScreen = new ManageMyWorldsScreen();
        manageMyCharactersScreen = new ManageMyCharactersScreen();
    }

    public void Start() { }

    public void DisplayCreateProfileScreen() { }

    public void UpdateListDisplay(List<User> listUsers) { }

    private void OnClickConnectToAServer() { }

    private void OnClickManageMyWorlds() { }

    private void OnClickManageMyCharacters() { }

    private void OnClickOneUser() { }

    private void OnClickOneWorld() { }

    private void OnClickJoin() { }

    private void OnClickLogout() { }

    private void ConnectWorld(string worldIpAdress) { }

    private void ChangeScene(GameBoard gameBoard) { }
}