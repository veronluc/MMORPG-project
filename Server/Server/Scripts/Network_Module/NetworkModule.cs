﻿using System.Collections;
using System.Collections.Generic;

public class NetworkModule
{
    Client client;
    private NetworkInterface networkInterface;
    public DataInterfaceForNetwork dataInterfaceForNetwork { get; set; }
    private void Awake()
    {
        client = new Client();
        this.networkInterface = new NetworkInterfaceImpl(client);
    }

    public NetworkInterface GetNetworkInterface()
    {
        return this.networkInterface;
    }

    private void Start()
    {
        client.data = dataInterfaceForNetwork;
    }

    private void OnApplicationQuit()
    {
        client.Disconnect();
    }
}
