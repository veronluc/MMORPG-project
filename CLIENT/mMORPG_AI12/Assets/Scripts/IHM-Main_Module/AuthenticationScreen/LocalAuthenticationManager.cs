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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLogin(string login)
    {
        this.login = login;
    }

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public void ClickOnLogIn()
    {
        Debug.Log(this.login);
        Debug.Log(this.password);
        //Call the AuthenticationScreen (script) function to discuss with other modules
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<AuthenticationScreen>().UserLogIn(login,password);
    }
}
