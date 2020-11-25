using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForIHMGameImpl : DataInterfaceForIHMGame
{
    public DataInterfaceForIHMGameImpl()
    {
    }

<<<<<<< HEAD
    public void SendMessage(Message message) {
        DataModule.networkInterface.SendChatMessage(message);
    }
=======
    public void SendMessage(Message message) { }
>>>>>>> data-processing-develop-classes-refactor

    public void MakeAction(Action action) {
        DataModule.networkInterface.SendAction(action.player, action);
    }

    public User GetCurrentUser() { return null; }
    public Player GetCurrentPlayer() { return null; }
    public World GetCurrentWorld() { return null; }
}
