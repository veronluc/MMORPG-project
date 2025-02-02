﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModule : MonoBehaviour
{
    // Usable for inter-module communication
    public static IHMMainInterface ihmMainInterface { get; set; }
    public static IHMGameInterface ihmGameInterface { get; set; }
    public static NetworkInterface networkInterface { get; set; }

    // Instanciated interface for the other module(s)
    private DataInterfaceForIHMMain dataInterfaceForIHMMain;
    private DataInterfaceForIHMGame dataInterfaceForIHMGame;
    private DataInterfaceForNetwork dataInterfaceForNetwork;

    // Managers
    public LocalUsersManager localUsersManager;
    public ConnectedUserManager connectedUserManager;

    private void Awake()
    {
        this.connectedUserManager = new ConnectedUserManager();
        this.localUsersManager = new LocalUsersManager();

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
