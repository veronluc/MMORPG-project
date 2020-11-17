using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkModule : MonoBehaviour
{
    private NetworkInterface networkInterface;

    private void Awake()
    {
        this.networkInterface = new NetworkInterfaceImpl();
    }

    public NetworkInterface GetNetworkInterface()
    {
        return this.networkInterface;
    }
}
