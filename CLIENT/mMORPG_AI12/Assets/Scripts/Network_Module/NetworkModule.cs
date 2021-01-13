using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Network Module
/// It is an object in the scene that can be accessed by all modules
/// </summary>
public class NetworkModule : MonoBehaviour
{
    /// <summary>
    /// The client reference (class representing the connection to the server)
    /// </summary>
    Client client;
    /// <summary>
    /// The network interface
    /// </summary>
    private NetworkInterface networkInterface;
    /// <summary>
    /// The data interface
    /// </summary>
    public DataInterfaceForNetwork dataInterfaceForNetwork { get; set; }

    /// <summary>
    /// Awake function of monobehaviour
    /// </summary>
    private void Awake()
    {
        client = new Client();
        this.networkInterface = new NetworkInterfaceImpl(client);
    }

    /// <summary>
    /// Getter of the network interface
    /// </summary>
    /// <returns></returns>
    public NetworkInterface GetNetworkInterface()
    {
        return this.networkInterface;
    }

    /// <summary>
    /// Start function of monobehaviour
    /// </summary>
    private void Start()
    {
        client.data = dataInterfaceForNetwork;
    }

    /// <summary>
    /// Called when the application is closed
    /// </summary>
    private void OnApplicationQuit()
    {
        client.Disconnect();
    }
}
