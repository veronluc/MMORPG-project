using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class ConnectedUserManager
{
    public LocalUser connectedUser { get => connectedUser; set { connectedUser = value; serverInfo = value.lastServerConnection; } }
    public bool isConnected {get => connectedUser != null; }
    public ServerInfo serverInfo {get => serverInfo; set { serverInfo = value; connectedUser.lastServerConnection = value; } }

    public ConnectedUserManager() {
        this.connectedUser = null;
        // RetrieveServerInfo();
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
