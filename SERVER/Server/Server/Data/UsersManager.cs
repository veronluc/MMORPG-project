using System;
using System.Collections.Generic;
using AI12_DataObjects;

namespace Server.Data
{
    public static class UsersManager
    {
        private static List<User> connectedUsers = new List<User>();

        public static List<User> GetConnectedUsers()
        {
            return connectedUsers;
        }

        public static void AddUser(User user)
        {
            connectedUsers.Add(user);
        }
    }
}
