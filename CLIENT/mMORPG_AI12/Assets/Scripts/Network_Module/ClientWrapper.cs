using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wrapper for the client (USED FOR DEBUG AND PRINT)
/// </summary>
public class ClientWrapper : MonoBehaviour
{
    /// <summary>
    /// The associated client
    /// </summary>
    public Client client { get; set; }
   
    // Start is called before the first frame update
    private void Awake()
    {
        client = new Client();
        //client.wrapper = this;
        client.data = new DataInterfaceForNetworkImpl();
    }


    void Start()
    {
        client.ConnectToServer("127.0.0.1", 26950);
        SendUserInfosPacket msg = new SendUserInfosPacket(client.data.GetUser());
    }
    
    /// <summary>
    /// To debug messages on console
    /// </summary>
    /// <param name="message"></param>
    public void DebugIt(string message)
    {
        Debug.Log(message);
    }
}
