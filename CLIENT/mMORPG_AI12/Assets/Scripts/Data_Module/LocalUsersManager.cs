using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class LocalUsersManager
{
    private List<User> usersStorage;
    public List<User> users {get => this.usersStorage; }

    public LocalUsersManager ()
    {
        RetrieveAndSetLocalUsers();
    }

    private void RetrieveAndSetLocalUsers()
    {
        // TODO Get local users from local storage
        // For the moment, we hardcode the local users
        User alex = new User();
        alex.login = "alex";
        alex.password = "alex123";
        User celia = new User();
        celia.login = "celia";
        celia.password = "celia123";
        this.usersStorage = new List<User>{alex, celia};
    }

    public User ConnectUser(string pseudo, string password) {
        foreach (User user in this.users)
        {
            if (user.login == pseudo && user.password == password) {
                return user;
            }
        }
        return null;
    }
}
