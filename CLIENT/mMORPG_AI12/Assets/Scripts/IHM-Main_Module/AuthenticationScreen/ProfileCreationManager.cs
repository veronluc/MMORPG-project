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

    public void SetLogin(string login)
    {
        this.login = login;
    }

    public void SetFirstname(string firstname)
    {
        this.firstname = firstname;
    }

    public void SetLastname(string lastname)
    {
        this.lastname = lastname;
    }

    public void SetBirthdate(string birthdate)
    {
        this.birthdate = birthdate;
    }

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public void SetPasswordConf(string passwordConf)
    {
        this.passwordConf = passwordConf;
    }

    public void ClickOnChoosePicture()
    {
        MessagePopupManager.ShowWarningMessage("Not implemented yet");
    }

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
