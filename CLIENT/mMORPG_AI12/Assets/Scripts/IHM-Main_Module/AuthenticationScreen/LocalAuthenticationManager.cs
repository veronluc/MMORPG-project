using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAuthenticationManager : MonoBehaviour
{
    private string login;
    private string password;

    // Start is called before the first frame update
    void Awake()
    {
        this.login = "";
        this.password = "";
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
    /// Set the password
    /// Called by a Unity Component when the user fill in the "PASSWORD" field
    /// </summary>
    /// <param name="password"></param>
    public void SetPassword(string password)
    {
        this.password = password;
    }


    /// <summary>
    /// Called when the user click on the "LOG IN" button
    /// </summary>
    public void ClickOnLogIn()
    {
        Debug.Log(this.login);
        Debug.Log(this.password);
        //Call the AuthenticationScreen (script) function to discuss with other modules
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<AuthenticationScreen>().UserLogIn(login,password);
    }
}
