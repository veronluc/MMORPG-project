using TMPro;
using UnityEngine;

public class MessagePopupManager : MonoBehaviour
{
    private static MessagePopupManager messagePopupManager; //Automatically implemented when the screen appears

    public TextMeshProUGUI title; //idem but via the editor

    public TextMeshProUGUI content; // idem via the editor

    // Start is called before the first frame update
    void Start()
    {
        messagePopupManager = this;
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Show the popup entitled "ERROR" with the wanted message
    /// </summary>
    /// <param name="msg">The message to show</param>
    public static void ShowErrorMessage(string msg)
    {
        if (messagePopupManager == null)
        {
            Debug.LogError("ERROR in IHMMainModule - MessagePopupManager : The Popup does not exist in the screen. Please make sure to have it in your Hierarchy.");
            return;
        }
        messagePopupManager.title.text = "ERROR";
        messagePopupManager.title.color = Color.red;
        messagePopupManager.content.text = msg;
        messagePopupManager.ShowPopup();
    }

    /// <summary>
    /// Show the popup entitled "WARNING" with the wanted message
    /// </summary>
    /// <param name="msg">The message to show</param>
    public static void ShowWarningMessage(string msg)
    {
        if (messagePopupManager == null)
        {
            Debug.LogError("ERROR in IHMMainModule - MessagePopupManager : The Popup does not exist in the screen. Please make sure to have it in your Hierarchy.");
            return;
        }
        messagePopupManager.title.text = "WARNING";
        messagePopupManager.title.color = new Color(0.8f,0.8f,0);
        messagePopupManager.content.text = msg;
        messagePopupManager.ShowPopup();
    }

    /// <summary>
    /// Show the popup entitled "INFORMATION" with the wanted message
    /// </summary>
    /// <param name="msg">The message to show</param>
    public static void ShowInfoMessage(string msg)
    {
        if (messagePopupManager == null)
        {
            Debug.LogError("ERROR in IHMMainModule - MessagePopupManager : The Popup does not exist in the screen. Please make sure to have it in your Hierarchy.");
            return;
        }
        messagePopupManager.title.text = "INFORMATION";
        messagePopupManager.title.color = Color.black;
        messagePopupManager.content.text = msg;
        messagePopupManager.ShowPopup();
    }

    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }

    private void ShowPopup()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    public void Test() {
        MessagePopupManager.ShowErrorMessage("Vous êtes allé trop loin Monsieur Jean Pierre !");
        //MessagePopupManager.ShowWarningMessage("Attention vous être très laid !");
        //MessagePopupManager.ShowInfoMessage("Ceci est une information nulle");
    }
}
