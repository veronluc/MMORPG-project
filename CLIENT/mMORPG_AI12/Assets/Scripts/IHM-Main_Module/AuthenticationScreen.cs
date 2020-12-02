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
        try
        {
            if (!login.Equals("") && !password.Equals(""))
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
    
        /// <summary>
        /// Create a user locally and control input
        /// </summary>
        /// <param name="login">Login identifier</param>
        /// <param name="password">Password</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="birthDate">Birthdate</param>
        /// <param name="image">Image</param>
        public void CreateProfile(string login, string firstName, string lastName, string birthDate, string password, string passwordConfirmation,
            string image)
        {
            try
            {
                if (!login.Equals("") && !password.Equals("") && !passwordConfirmation.Equals(""))
                {
                    if (password.Equals(passwordConfirmation))
                    {
                        dataInterface.CreateUser(login, password, firstName, lastName, birthDate, image);
                    }
                    else
                    {
                        MessagePopupManager.ShowWarningMessage("Le mot de passe de confirmation n'est pas égal au mot de passe");
                    }
                }
                else
                {
                    MessagePopupManager.ShowWarningMessage("Un ou plusieurs champs n'a pas été rempli");
                }
            }
            catch (Exception e)
            {
                Debug.Log("Exception : " + e);
                // handle user creation error
            }
        }
}