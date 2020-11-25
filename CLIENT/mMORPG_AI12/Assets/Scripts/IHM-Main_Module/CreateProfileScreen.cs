using System;
using AI12_DataObjects;
using UnityEngine;

public class CreateProfileScreen
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
    /// Create an user locally and control input
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
            if (login != null && firstName != null && lastName != null && birthDate != null && password != null && passwordConfirmation != null &&
                image != null)
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
