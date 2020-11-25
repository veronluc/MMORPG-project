using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHMGameModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMGame dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    public IHMGameInterface ihmGameInterface { get; set; }

    private void Awake()
    {
        ihmGameInterface = new IHMGameInterfaceImpl();
    }
}
