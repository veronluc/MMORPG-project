using System.Collections;
using System.Collections.Generic;
using AI12_DataObjects;

public class DataInterfaceForIHMGameImpl : DataInterfaceForIHMGame
{
    // private DataModule dataModule;
    private ConnectedUserManager connectedUserManager;

    public DataInterfaceForIHMGameImpl(DataModule _dataModule)
    {
        // this.dataModule = _dataModule;
        this.connectedUserManager = DataModule.connectedUserManager;
    }

    public void SendMessage(Message message)
    {
        DataModule.networkInterface.SendChatMessage(message);
    }

    public void MakeAction(Action action)
    {
        DataModule.networkInterface.SendAction((Player)action.entity, action);
    }

    public User GetCurrentUser()
    {
        return connectedUserManager.connectedUser.user;
    }

    public Player GetCurrentPlayer()
    {
        return connectedUserManager.currentPlayer;
    }

    public World GetCurrentWorld()
    {
        return connectedUserManager.currentWorld;
    }
}
