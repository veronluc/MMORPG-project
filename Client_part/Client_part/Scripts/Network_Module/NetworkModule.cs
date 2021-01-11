using System.Collections;
using System.Collections.Generic;

public class NetworkModule
{
    Client client;
    private NetworkInterface networkInterface;
    public DataInterfaceForNetwork dataInterfaceForNetwork { get; set; }
    public void Awake()
    {
        client = new Client();
        this.networkInterface = new NetworkInterfaceImpl(client);
    }

    public NetworkInterface GetNetworkInterface()
    {
        return this.networkInterface;
    }

    public void Start()
    {
        client.data = dataInterfaceForNetwork;
    }

    public void OnApplicationQuit()
    {
        client.Disconnect();
    }
}
