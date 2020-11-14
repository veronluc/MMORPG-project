using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnectionManager : MonoBehaviour
{

    private string serverIp;
    public string serverPort;

    private void Awake()
    {
        this.gameObject.SetActive(false);
        this.serverIp = "";
        this.serverPort = "";
    }

    /// <summary>
    /// Open or close the server connection popup
    /// </summary>
    public void OpenClosePopup()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    /// <summary>
    /// Set the server IP
    /// Called by a Unity Component when the user fill in the "SERVER IP" field
    /// </summary>
    /// <param name="ip"></param>
    public void SetServerIp(string ip)
    {
        this.serverIp = ip;
    }

    /// <summary>
    /// Set the server PORT
    /// Called by a Unity Component when the user fill in the "PORT" field
    /// </summary>
    /// <param name="port"></param>
    public void SetServerPort(string port)
    {
        this.serverPort = port;
    }

    /// <summary>
    /// Called when a user click on the "CONNECT" button of the popup
    /// It simply calls a function from the MainConnectedScreen
    /// </summary>
    public void ClickOnConnect()
    {
        Debug.Log(this.serverIp);
        Debug.Log(this.serverPort);
        //Call the MainConnectedScreen (script) function to discuss with other modules
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .ConnectToAServer(serverIp, serverPort);

    }
}
