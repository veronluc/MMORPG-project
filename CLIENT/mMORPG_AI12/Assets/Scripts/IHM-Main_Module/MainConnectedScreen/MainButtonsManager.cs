using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonsManager : MonoBehaviour
{
    /// <summary>
    /// Called when the user click on the "MANAGE MY WORLDS" button
    /// </summary>
    public void ClickOnManageMyWorlds()
    {
        ScreensManager.ShowWorldsManagerScreen();
    }
}
