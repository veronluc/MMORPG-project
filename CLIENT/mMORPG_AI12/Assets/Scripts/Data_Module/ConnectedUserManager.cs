using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ConnectedUserManager
{
    public User connectedUser {get; set;}
    public bool isConnected {get => connectedUser != null; }
    public string server {get; set;}
    public int port {get; set;}
    public ServerInfo serverInfo {get; set;}

    public ConnectedUserManager() {
        this.connectedUser = null;
        RetrieveServerInfo();
    }

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
}
