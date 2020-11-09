using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public interface DataInterfaceForIHMGame
{
    void SendMessage(string idWorld, string text);
    void MakeAction(Action action);
    User GetCurrentUser();
    Player GetCurrentPlayer();
    World GetCurrentWorld();
}
