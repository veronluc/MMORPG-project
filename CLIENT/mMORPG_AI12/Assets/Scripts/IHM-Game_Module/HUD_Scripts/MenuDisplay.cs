using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{
    public GameObject menu;
    /// <summary>
    /// Display the menu if it is hidden or hide it if it is displayed
    /// </summary>
    public void ShowOrHideMenu()
    {

        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
