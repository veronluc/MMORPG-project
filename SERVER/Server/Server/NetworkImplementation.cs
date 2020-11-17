using AI12_DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class NetworkImplementation : NetworkInterface
    {
 
        public void SendWorldsList(User user, List<World> worlds)
        {
            int id = Convert.ToInt32(user.id);
            SendWorldsListPacket msg = new SendWorldsListPacket(worlds);
            GameServer.clients[id].SendData(msg);
        }
        public void SendUsersList(User user, List<User> users)
        {
            int id = Convert.ToInt32(user.id);
            SendUsersListPacket msg = new SendUsersListPacket(users);
            GameServer.clients[id].SendData(msg);
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
            int id = Convert.ToInt32(user.id);
            ConfirmationUserConnectionToWorldPacket msg = new ConfirmationUserConnectionToWorldPacket(world, result, message); ;
            GameServer.clients[id].SendData(msg);
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
        public void SendListUsersWorlds(User user, List<User> users, List<World> worlds)
        {
            int id = Convert.ToInt32(user.id);
            SendUsersAndWorlds msg = new SendUsersAndWorlds(users, worlds);
            GameServer.clients[id].SendData(msg);
        }
    }
}
