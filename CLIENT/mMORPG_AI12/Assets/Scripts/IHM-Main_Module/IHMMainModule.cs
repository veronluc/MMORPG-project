using System.Collections.Generic;
using UnityEngine;

public class IHMMainModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMMain dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    public IHMMainInterface ihmMainInterface { get; set; }

    private void Awake()
    {
        ihmMainInterface = new IHMMainInterfaceImpl();
    }
    
}
