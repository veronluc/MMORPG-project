using AI12_DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Network
{
    public class DataInterfaceForNetworkImpl
    {
        public void ReceiveListWorlds(List<World> worlds)
        {
        }

        public void ReceiveWorld(World world)
        {
        }
        public void ReceiveListUsers(List<User> users) { }
        public void ReceiveListUsersFromWorld(List<User> users, World world) { }
        public void ReceiveMessage(Message message) { }
        public void ReceiveAction(AI12_DataObjects.Action action, Player player) { }
        public void ReceiveAction(AI12_DataObjects.Action action, Monster monster) { }

        public void ReceiveUser(User user) { }
        public void DisconnectServerStop() { }
        public void DisconnectServerError() { }
        public void UserDisconnectedFromWorld(User user) { }
        public void UserDisconnectedFromServer(User user) { }
        public void OwnerDisconnectedFromWorld(User user) { }
    }
}
