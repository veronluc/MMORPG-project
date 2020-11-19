using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsersManager
{
    /// <summary>
    /// List of User instances connected to the server
    /// </summary>
    private static List<User> connectedUsers = new List<User>();

    /// <summary>
    /// Get the list of User instances connected to the server
    /// </summary>
    /// <returns></returns>
    public static List<User> GetConnectedUsers()
    {
        return connectedUsers;
    }

    /// <summary>
    /// Add a User instance to the server (due to connection)
    /// </summary>
    /// <param name="user"></param>
    public static void AddUser(User user)
    {
        connectedUsers.Add(user);
    }

    /// <summary>
    /// Add a User instance to the server (due to connection)
    /// </summary>
    /// <param name="user"></param>
    public static void RemoveUser(User user)
    {
        User foundUser = connectedUsers.Find(
                u => u.id == user.id
            );
        if (foundUser != null)
        {
            connectedUsers.Remove(foundUser);
        }
        else
        {
            throw new Exception("User not logged in");
        }
    }
}