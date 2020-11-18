using System.Collections.Generic;
using UnityEngine;

public class IHMMainModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMMain dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    private IHMMainInterface ihmMainInterface;

    private void Awake()
    {
        ihmMainInterface = new IHMMainInterfaceImpl();
    }
    
}
