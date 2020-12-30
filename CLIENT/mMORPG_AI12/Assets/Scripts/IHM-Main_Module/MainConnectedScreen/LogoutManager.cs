using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Called when the user click on "LOGOUT"
    /// </summary>
    public void ClickOnLogout()
    {
        GameObject ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule");
        //Disconnection from server
        ihmMainModule.GetComponent<MainConnectedScreen>().LogOutServer();
        //Deletion of the User in the main module script
        ihmMainModule.GetComponent<IHMMainModule>().localUser = null;
        //Go back to the authenticationScreen
        ScreensManager.ShowAuthenticationMenu();
    }
}
