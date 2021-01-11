using System;
using System.Collections.Generic;
using AI12_DataObjects;

public class IHMMainInterfaceImpl : IHMMainInterface
{
    public IHMMainInterfaceImpl()
    {
    }

    public void DisplayListUser(List<User> users)
    {
        throw new NotImplementedException();
    }

    public void DisplayListUsersWorlds(List<User> usersList, List<World> worldsList)
    {
        throw new NotImplementedException();
    }

    public void DisplayNewAvailableWorld(List<World> worlds)
    {
        throw new NotImplementedException();
    }

    public void GiveLocalUser(LocalUser localUser)
    {
        Console.WriteLine(localUser);
    }

    public void LoadMainScene()
    {
        throw new NotImplementedException();
    }
}
