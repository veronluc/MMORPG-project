using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForNetworkImpl : DataInterfaceForNetwork
{
    public void ReceiveMessage(Message message){}
    public void ReceiveAction(Action action, Player player){}
    public void ReceiveLoadedWorld(World world){}
    public void ReceiveGameState(GameState state){}
}
