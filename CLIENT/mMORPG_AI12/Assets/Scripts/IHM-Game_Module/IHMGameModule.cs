using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHMGameModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMGame dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    public IHMGameInterfaceImpl ihmGameInterface { get; set; }

    // GameManager to manage chat messages
    public GameManager gameManager { get; set; }

    private void Awake()
    {
        this.ihmGameInterface = new IHMGameInterfaceImpl();
        this.gameManager = new GameManager();
        this.ihmGameInterface.gameManager = this.gameManager;
    }
}
