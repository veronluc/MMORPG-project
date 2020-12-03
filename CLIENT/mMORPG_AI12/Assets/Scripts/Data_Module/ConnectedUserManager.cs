using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ConnectedUserManager
{
    public LocalUser connectedUser { get; set; }
    public bool isConnected { get => connectedUser != null; }
    public ServerInfo serverInfo { get => connectedUser.lastServerConnection; set { connectedUser.lastServerConnection = value; } }

    public ConnectedUserManager() {
        // this.connectedUser = null;
        // RetrieveServerInfo();
    }

    public void AddWorld(World world)
    {
        connectedUser.AddWorld(world);
    }

    public void RemoveWorld(string worldId)
    {
        connectedUser.RemoveWorld(worldId);
    }

    public World GetWorld(string worldId)
    {
        return connectedUser.GetWorld(worldId);
    }

    public Player GetPlayer(string playerId)
    {
        return connectedUser.GetPlayer(playerId);
    }

    public void UpdateWorld(World world)
    {
        connectedUser.ModifyWorld(world);
    }

    public void AddPlayer(Player player)
    {
        connectedUser.AddPlayer(player);
    }

    public void RemovePlayer(string playerId)
    {
        connectedUser.RemovePlayer(playerId);
    }

    public void ModifyPlayer(Player player)
    {
        connectedUser.ModifyPlayer(player);
    }

    /*
    public void SaveServerInfo() {
        try {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + "/lastServerInfo.dat";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream file = File.Create(path);
            bf.Serialize(file, this.serverInfo);
            file.Close();
            // Debug.Log("Saved Server Info : " + path);
        } catch(Exception e) {
            Debug.LogError(e);
            throw e;
        }
    }

    public void RetrieveServerInfo() {
        try {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + "/lastServerInfo.dat";
            if (File.Exists(path)) {
                FileStream file = File.Open(path, FileMode.Open);
                this.serverInfo = (ServerInfo) bf.Deserialize(file);
                file.Close();
                // Debug.Log("Retrieved Server Info : " + path);
            } else {
                this.serverInfo = null;
            }
        }
        catch (Exception e) {
            Debug.LogError(e);
            throw e;
        }
    }
    */
}
