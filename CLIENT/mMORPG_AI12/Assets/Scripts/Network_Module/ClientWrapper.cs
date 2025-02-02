﻿using AI12_DataObjects;
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



        User u = new User();
        u.firstName = "Theo";
        u.lastName = "Duc";
        Player p = new Player();
        Player p2 = new Player();
        client.currentUser = u;
    }
    void Start()
    {
        client.ConnectToServer("127.0.0.1", 26950);
        SendUserInfosPacket msg = new SendUserInfosPacket(client.currentUser);
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
