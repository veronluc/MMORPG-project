﻿using AI12_DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class DataImplementation : DataInterfaceForNetwork
    {
        NetworkImplementation network;
        /// <summary>
        /// Méthode appelée une fois le serveur démarré.
        /// </summary>
        /// <param name="n">Référence à l'implémmentation de l'nterface network</param>
        public void SetupServer(NetworkImplementation n)
        {
            network = n;
            Console.WriteLine("Démarrage du serveur effectué");
        }
        public void ReceiveMessage(Message message)
        {
            throw new NotImplementedException();
        }
        public void ReceiveUser(User user)
        {
            throw new NotImplementedException();
        }
        public void ReceiveNewAction(World world)
        {
            throw new NotImplementedException();
        }
        public void ReceiveNewAction(AI12_DataObjects.Action action)
        {
            throw new NotImplementedException();
        }
        public void ReceiveNewWorld(World world)
        {
            throw new NotImplementedException();
        }
        public void ReceiveConnexionUserToWorld(User user, World world)
        {
            throw new NotImplementedException();
        }
        public void UserAskWorldList(User user)
        {
            throw new NotImplementedException();
        }
        public void UserAskUsersList(User user)
        {
            throw new NotImplementedException();
        }
        public void UserRefreshInfos(User user)
        {
            throw new NotImplementedException();
        }
        public void UserAskDisconnectFromWorld(User user)
        {
            throw new NotImplementedException();
        }
        public void UserAskDisconnectFromServer(User user)
        {
            throw new NotImplementedException();
        }
        public void UserBrutalDisconnected(User user)
        {
            throw new NotImplementedException();
        }
    }
}
