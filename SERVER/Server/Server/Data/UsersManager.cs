using System;
using System.Collections.Generic;
using AI12_DataObjects;

namespace Server.Data
{
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
    }
}
