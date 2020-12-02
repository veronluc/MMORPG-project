using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    private static ScreensManager instance;

    public GameObject authenticationMenu;
    
    public GameObject mainConnectedScreen;

    public GameObject worldsManagerScreen;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowAuthenticationMenu();
    }

    /// <summary>
    /// Test if the manager is well instanciated
    /// </summary>
    /// <returns></returns>
    private static bool IsInstanciated()
    {
        if(instance == null)
        {
            Debug.LogError("ERROR in IHMMainModule - ScreensManager : This manager does not exist in the scene. Please make sure to have it in your Hierarchy.");
            return false;
        }
        return true;
    }

    /// <summary>
    /// As it is named, it hide all the screens
    /// </summary>
    private static void HideAllScreens()
    {
        if (IsInstanciated())
        {
            instance.authenticationMenu.SetActive(false);
            instance.mainConnectedScreen.SetActive(false);
            instance.worldsManagerScreen.SetActive(false);
        }
        
    }

    /// <summary>
    /// Show the Authentication Menu
    /// </summary>
    public static void ShowAuthenticationMenu()
    {
        if (IsInstanciated())
        {
            HideAllScreens();
            instance.authenticationMenu.SetActive(true);
        }
        
    }

    /// <summary>
    /// Show the Main Connected Screen
    /// </summary>
    public static void ShowMainConnectedScreen()
    {
        if (IsInstanciated())
        {
            HideAllScreens();
            instance.mainConnectedScreen.SetActive(true);
        }
    }

    public static void ShowWorldsManagerScreen()
    {
        if (IsInstanciated())
        {
            HideAllScreens();
            instance.worldsManagerScreen.SetActive(true);
        }
    }
}
