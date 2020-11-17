using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkModule : MonoBehaviour
{
    Client client;
    private NetworkInterface networkInterface;

    private void Awake()
    {
        client = new Client();
        client.data = FindObjectOfType<DataModule>().GetInterfaceForNetwork();
        this.networkInterface = new NetworkInterfaceImpl(client);
    }

    public NetworkInterface GetNetworkInterface()
    {
        return this.networkInterface;
    }

    private void Start()
    {

    }
}
