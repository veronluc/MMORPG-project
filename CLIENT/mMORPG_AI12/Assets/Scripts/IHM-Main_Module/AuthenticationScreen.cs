using System;
using UnityEngine;

public class AuthenticationScreen : MonoBehaviour
{
    // Properties
    private IHMMainModule ihmMainModule;
    private DataInterfaceForIHMMain dataInterface;

    public void Awake()
    {
        this.ihmMainModule = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>();
        this.dataInterface = ihmMainModule.dataInterface;
    }

    public void Start()
    {
        this.dataInterface = ihmMainModule.dataInterface;
    }

    /// <summary>
    /// Create a local session for the user
    /// If the user was connected to a server during its last session,
    /// the client connects directly to this server
    /// </summary>
    /// <param name="login">User pseudo</param>
    /// <param name="password">User password</param>
    public void UserLogIn(string login, string password)
    {
        Debug.Log("2 : " + login);
        Debug.Log("2 : " + password);
        try
        {
            if (!login.Equals("") || !password.Equals(""))
            {
                dataInterface.CreateUserSession(login, password);
            }
            else
            {
                MessagePopupManager.ShowWarningMessage("Vous n'avez pas entré votre login ou votre mot de passe");
            }
        }
        catch (Exception e)
        {
            // handle user log in error 
        }
    }
}