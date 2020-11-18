using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForIHMGameImpl : DataInterfaceForIHMGame
{
    public void SendMessage(Message message) { }
    public void MakeAction(Action action) { }
    public User GetCurrentUser() { return null; }
    public Player GetCurrentPlayer() { return null; }
    public World GetCurrentWorld() { return null; }
}
