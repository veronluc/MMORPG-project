﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataInterfaceForIHMMainImpl : DataInterfaceForIHMMain
{

    private DataModule dataModule;
    private LocalUsersManager localUsersManager;
    private ConnectedUserManager connectedUserManager;

    public DataInterfaceForIHMMainImpl() {
        this.dataModule = GameObject.FindGameObjectWithTag("DataModule").GetComponent<DataModule>();
        this.localUsersManager = dataModule.localUsersManager;
        this.connectedUserManager = dataModule.connectedUserManager;
    }

    public void LoadWorld(ref World world)
    {
        DataModule.networkInterface.AddNewWorld(world);
    }

    [Obsolete("Please use the new method CreateWorld, directly below")]
    public World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, List<Player> players, List<Monster> monsters, User creator, GameState gameState)
    {
        throw new NotImplementedException();
    }

    public World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, User creator)
    {
        return new World(name, sizeMap, gameMode, realDeath, difficulty, roundTimeSec, nbMaxPlayer, nbMaxMonsters, nbShops, hasCity, hasPlain, hasSwamp, hasRiver, hasForest, hasRockyPlain, hasMontain, hasSea, creator);
    }

    public void DeleteWorld(World world)
    {
        //TODO supprimer le world en local
    }

    public void UpdateWorld(World world)
    {
        //TODO mettre à jour le world en local
    }

    public void JoinWorld(Player player, string worldId)
    {
        DataModule.networkInterface.ConnectToWorld(player, worldId);
    }

    public void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    public void UpdateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    
    public string CreateUserSession(string pseudo, string password) {
        this.connectedUserManager.connectedUser = this.localUsersManager.ConnectUser(pseudo, password);

        // Check if user connexion was successful
        if (this.connectedUserManager.isConnected) {
            DataModule.ihmMainInterface.GiveLocalUser(this.connectedUserManager.connectedUser);
            // Check if server ip is known
            if (this.connectedUserManager.serverInfo != null) {
                DataModule.networkInterface.ConnectUser(
                    this.connectedUserManager.connectedUser.user,
                    this.connectedUserManager.serverInfo.server,
                    this.connectedUserManager.serverInfo.port
                );
                return this.connectedUserManager.serverInfo.server + ":" + this.connectedUserManager.serverInfo.port;
            }
        }
        
        // User connection was unsuccesful or server ip was unknown
        return null;
    }
    
    public void ConnectSessionToServer(string ipServer, string port) {
        this.connectedUserManager.serverInfo = new ServerInfo(ipServer, Int32.Parse(port));
        this.localUsersManager.Save();
        DataModule.networkInterface.ConnectUser(
            this.connectedUserManager.connectedUser.user,
            this.connectedUserManager.serverInfo.server,
            this.connectedUserManager.serverInfo.port
        );
    }

    public void GetWorldDetails(string worldId) { }
    public void GetUserDetails(string userId) { }

    public void LogOut() {
        DataModule.networkInterface.DisconnectUserFromServer();
    }

    public void LogOutServer()
    {
        DataModule.networkInterface.DisconnectUserFromServer();
    }

    public void SaveWorld(World world) {
        if (world.id != null)
        {
            World backup = this.connectedUserManager.connectedUser.worlds.Find(w => w.id == world.id);
            if (backup != null)
            {
                backup = world;
            } else
            {
                this.connectedUserManager.connectedUser.worlds.Add(world);
            }
            this.localUsersManager.Save();
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
                if (connectedUserManager.isConnected && data.creator.id.Equals(connectedUserManager.connectedUser.id))
                    return data;
                return null;
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
