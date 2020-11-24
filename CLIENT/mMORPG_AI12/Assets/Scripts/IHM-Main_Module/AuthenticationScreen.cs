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
    /// <param name="pseudo">User pseudo</param>
    /// <param name="password">User pseudo</param>
    public void UserLogIn(string login, string password)
    {
        try
        {
            if (login != null && password != null)
            {
                dataInterface.CreateUserSession(login, password);

            }
        }
        catch (Exception e)
        {
            // handle user log in error 
        }
    }
}