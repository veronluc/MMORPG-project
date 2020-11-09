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

    //test click on button
    public void ClickOnButton()
    {
        // TODO - This method is not in the conception diagrams : is this an error ?
        /* List<string> list = this.dataInterface.getListUserWorlds();
        foreach (string r in list){
            Debug.Log(r);
        }
        */
    }
}
