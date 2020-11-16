using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataInterfaceForIHMMainImpl : DataInterfaceForIHMMain
{
    public void LoadWorld(ref World world)
    {
        DataModule.networkInterface.AddNewWorld(world);
    }

    public World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, List<Player> players, List<Monster> monsters, User creator, GameState gameState)
    {
        return new World(name, sizeMap, gameMode, realDeath, difficulty, roundTimeSec, nbMaxPlayer, nbMaxMonsters, nbShops, hasCity, hasPlain, hasSwamp, hasRiver, hasForest, hasRockyPlain, hasMontain, hasSea, players, monsters, creator, gameState);
    }

    public void JoinWorld(Player player, string worldId)
    {
        DataModule.networkInterface.ConnectToWorld(player, worldId);
    }


    public void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    public void UpdateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    public string CreateUserSession(string pseudo, string password) { return null; }
    public void ConnectSessionToServer(string worldId, string ipServer, string port) { } 
    
    public void GetWorldDetails(string worldId) { }
    public void GetUserDetails(string userId) { }
    public void LogOut() { }

    public void SaveWorld(World world) {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + world.name + ".dat";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream file = File.Create(path);
            bf.Serialize(file, world);
            file.Close();
            Debug.Log("Saved !");
        } catch(Exception e)
        {
            Debug.LogError(e);
            throw e;
        }
    }

    public World RestoreWorld(string name) {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + name + ".dat";
            if (File.Exists(path))
            {
                FileStream file = File.Open(path, FileMode.Open);
                World data = (World)bf.Deserialize(file);
                file.Close();
                return data;
            }
            return null;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw e;
        }
    }

    public Player CreatePlayer(EntityClass entityClass, string name) { return null; }
    public List<Player> ListPlayers() { return null; }
    public void DeletePlayer(Player player) { }
    public Player EditPlayer(Player editedPlayer) { return null; }


    


    public void GetWorlds() { }
}
