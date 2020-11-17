using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModule : MonoBehaviour
{
    // Usable for inter-module communication
    public static IHMMainInterface ihmMainInterface;
    public static IHMGameInterface ihmGameInterface;
    public static NetworkInterface networkInterface;

    // Instanciated interface for the other module(s)
    private DataInterfaceForIHMMain dataInterfaceForIHMMain;
    private DataInterfaceForIHMGame dataInterfaceForIHMGame;
    private DataInterfaceForNetwork dataInterfaceForNetwork;

    private void Awake()
    {
        this.dataInterfaceForIHMMain = new DataInterfaceForIHMMainImpl();
        this.dataInterfaceForIHMGame = new DataInterfaceForIHMGameImpl();
        this.dataInterfaceForNetwork = new DataInterfaceForNetworkImpl();
    }

    public DataInterfaceForIHMMain GetInterfaceForIHMMain()
    {
        return this.dataInterfaceForIHMMain;
    }

    public DataInterfaceForIHMGame GetInterfaceForIHMGame()
    {
        return this.dataInterfaceForIHMGame;
    }

    public DataInterfaceForNetwork GetInterfaceForNetwork()
    {
        return this.dataInterfaceForNetwork;
    }
}
