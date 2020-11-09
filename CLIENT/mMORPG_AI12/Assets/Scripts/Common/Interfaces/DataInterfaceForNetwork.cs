using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public interface DataInterfaceForNetwork
{
    void ReceiveMessage(Message message);
    void ReceiveAction(Action action, Player player);
    void ReceiveLoadedWorld(World world);
    void ReceiveGameState(GameState state);
}
