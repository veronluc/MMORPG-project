using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileCreationManager : MonoBehaviour
{
    private string login;
    private string firstname;
    private string lastname;
    private string birthdate;
    private string password;
    private string passwordConf;

    // Start is called before the first frame update
    void Awake()
    {
        this.login = "";
        this.firstname = "";
        this.lastname = "";
        this.birthdate = "";
        this.password = "";
        this.passwordConf = "";
    }

    /// <summary>
    /// Open or close the profile creation popup
    /// </summary>
    public void OpenClosePopup()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    /// <summary>
    /// Set the login
    /// Called by a Unity Component when the user fill in the "LOGIN" field
    /// </summary>
    /// <param name="login"></param>
    public void SetLogin(string login)
    {
        this.login = login;
    }

    /// <summary>
    /// Set the firstname
    /// Called by a Unity Component when the user fill in the "FIRSTNAME" field
    /// </summary>
    /// <param name="firstname"></param>
    public void SetFirstname(string firstname)
    {
        this.firstname = firstname;
    }

    /// <summary>
    /// Set the lastname
    /// Called by a Unity Component when the user fill in the "LASTNAME" field
    /// </summary>
    /// <param name="lastname"></param>
    public void SetLastname(string lastname)
    {
        this.lastname = lastname;
    }

    /// <summary>
    /// Set the birthdate
    /// Called by a Unity Component when the user fill in the "BIRTHDATE" field
    /// </summary>
    /// <param name="birthdate"></param>
    public void SetBirthdate(string birthdate)
    {
        this.birthdate = birthdate;
    }

    /// <summary>
    /// Set the password
    /// Called by a Unity Component when the user fill in the "PASSWORD" field
    /// </summary>
    /// <param name="password"></param>
    public void SetPassword(string password)
    {
        this.password = password;
    }

    /// <summary>
    /// Set the passwordConf
    /// Called by a Unity Component when the user fill in the "PASSWORD CONFIRMATION" field
    /// </summary>
    /// <param name="passwordConf"></param>
    public void SetPasswordConf(string passwordConf)
    {
        this.passwordConf = passwordConf;
    }

    /// <summary>
    /// Called when the user click on the picture button
    /// </summary>
    public void ClickOnChoosePicture()
    {
        MessagePopupManager.ShowWarningMessage("Not implemented yet");
    }

    /// <summary>
    /// Called when the user click on the "CREATE PROFILE" button
    /// </summary>
    public void ClickOnCreateProfile()
    {
        Debug.Log("Login : " + login);
        Debug.Log("Firstname : " + firstname);
        Debug.Log("Lastname : " + lastname);
        Debug.Log("Birthdate : " + birthdate);
        Debug.Log("Password : " + password);
        Debug.Log("Password Conf. : " + passwordConf);
        //TODO : Envoyer les données à AuthenticationScreen.cs
    }
}
