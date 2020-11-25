using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;

public class IHMMainModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMMain dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    public IHMMainInterface ihmMainInterface { get; set; }
    
    // Intern variable needed in all IHMMAIN module 
    private User currentUser = new User();

    private void Awake()
    {
        ihmMainInterface = new IHMMainInterfaceImpl();
    }

    /// <summary>
    /// getter for currentUser
    /// </summary>
    /// <returns></returns>
    public User GetCurrentUser()
    {
        return currentUser;
    }

    /// <summary>
    /// setter for currentUser 
    /// </summary>
    /// <param name="user"></param>
    public void SetCurrentUser(User user)
    {
        this.currentUser = user; 
    }
}
