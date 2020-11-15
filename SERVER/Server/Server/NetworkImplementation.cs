using AI12_DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class NetworkImplementation : NetworkInterface
    {
 
        public void SendWorldsList(User user, List<World> worlds)
        {
            throw new NotImplementedException();
        }
        public void SendUsersList(User user, List<User> users)
        {
            throw new NotImplementedException();
        }
        public void SendUsersListFromWorld(User user, List<User> users, World world)
        {
            throw new NotImplementedException();
        }
        public void SendMessageToUser(User user, Message message)
        {
            throw new NotImplementedException();
        }
        public void SendActionToUser(User user, AI12_DataObjects.Action action, Player player)
        {
            throw new NotImplementedException();
        }
        public void SendActionToUser(User user, AI12_DataObjects.Action action, Monster monster)
        {
            throw new NotImplementedException();
        }
        public void SendConfirmationUserConnectionToWorld(User user, World world, bool result, string message)
        {
            throw new NotImplementedException();
        }
        public void SendStopServer(User user)
        {
            throw new NotImplementedException();
        }
        public void SendUserDisconnectedWorld(User userDestination, User userDisconnected)
        {
            throw new NotImplementedException();
        }
        public void SendUserDisconnectedServer(User userDestination, User userDisconnected)
        {
            throw new NotImplementedException();
        }
    }
}
