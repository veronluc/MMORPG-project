using System.Collections.Generic;
using UnityEngine;

public class MainConnectedScreen : MonoBehaviour
{
    // Properties
    private string serverIp;
    private string port;
    // private List<User> usersList; // TODO : retrieve User object when available
    // private List<World> worldsList; // TODO : retrieve World object when available

    // Screens
    // private ConnexionScreen connexionScreen; // TODO : develop class
    // private ConnectToAServerScreen connectToAServerScreen; // TODO : develop class
    // private ManageMyWorldsScreen manageMyWorldsScreen; // TODO : develop class
    // private ManageMyCharactersScreen manageMyCharactersScreen; // TODO : develop class

    public void Awake()
    {
        // TODO : when classes available : add parameters if needed
        // connexionScreen = new ConnexionScreen();
        // connectToAServerScreen = new ConnectToAServerScreen();
        // manageMyWorldsScreen = new ManageMyWorldsScreen();
        // manageMyCharactersScreen = new ManageMyCharactersScreen();
    }

    public void Start() { }

    public void DisplayCreateProfileScreen() {
        throw new System.NotImplementedException();
    }

    public void UpdateListDisplay(/*List<User> listUsers*/) {
        throw new System.NotImplementedException();
    }

    private void OnClickConnectToAServer() {
        throw new System.NotImplementedException();
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

    private void OnClickJoin() {
        throw new System.NotImplementedException();
    }

    private void OnClickLogout() {
        throw new System.NotImplementedException();
    }

    private void ConnectWorld(string worldIpAdress) {
        throw new System.NotImplementedException();
    }

    private void ChangeScene(/*GameBoard gameBoard*/) {
        throw new System.NotImplementedException();
    }
}