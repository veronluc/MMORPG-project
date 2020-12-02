using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientWrapper : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DebugIt(string message)
    {
        Debug.Log(message);
    }
}
