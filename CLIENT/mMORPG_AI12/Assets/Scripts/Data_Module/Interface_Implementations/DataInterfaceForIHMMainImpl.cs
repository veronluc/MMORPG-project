﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForIHMMainImpl : DataInterfaceForIHMMain
{
    public World LoadWorld(World world){return null;}
    public World UnloadWorld(World world){return null;}
    public List<World> GetWorlds(){return null;}
    public void SaveWorld(World world){}
    public World RestoreWorld(string name){return null;}
    public void ConnectPlayerToWorld(Player player, World world){}
    public void ChangeScene(GameState scene){}
    public void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image){}
    public (List<User>, List<World>) ConnectUser(User user){return (null, null);}
    public void DisconnectUser(User user){}
    public List<User> GetConnectedUsers(){return null;}
    // public Player CreatePlayer(Class class, string name){return null;}
    public List<Player> ListPlayers(){return null;}
    public void DeletePlayer(Player player){}
    public Player EditPlayer(Player editedPlayer){return null;}
    public World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath){return null;}
}
