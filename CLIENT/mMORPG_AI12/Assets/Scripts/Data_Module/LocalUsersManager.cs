using System.Collections.Generic;
using AI12_DataObjects;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

public class LocalUsersManager
{
    private List<LocalUser> usersStorage;
    private const string PATH = "/localUsers.dat";
    public List<LocalUser> users {get => this.usersStorage; }

    public LocalUsersManager ()
    {
        RetrieveAndSetLocalUsers();
    }

    private void RetrieveAndSetLocalUsers()
    {
        // TODO Get local users from local storage
        // For the moment, we hardcode the local users
        /*
        User alex = new User();
        alex.login = "alex";
        alex.password = "alex123";
        User celia = new User();
        celia.login = "celia";
        celia.password = "celia123";
        */
        // this.usersStorage = new List<User>{alex, celia};
        /*try
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + PATH;
            if (File.Exists(path))
            {
                FileStream file = File.Open(path, FileMode.Open);
                List<LocalUser> data = (List<LocalUser>)bf.Deserialize(file);
                file.Close();
                this.usersStorage = data;
            }
            else
            {
                this.usersStorage = new List<LocalUser>();
                this.Save();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw e;
        }*/

        this.usersStorage = new List<LocalUser>();
        LocalUser localUser = new LocalUser(new User("test", "test123"));
        Player player = TestCreatePlayer(localUser.user, "Bibi");
        localUser.players.Add(player);
        usersStorage.Add(localUser);
    }
    
    public Player TestCreatePlayer(User user, string name = "JOUEUR")
    {
        // TO MODIFY (v2) : replace those lines with the user's chosen player (via choose player Popup) when the connection will be implemented
        Skill skill = new Skill("kick",2,4,2,false);
        // skill.range = new Range(shapes.star, 10);
        List<Skill> skills = new List<Skill>();
        skills.Add(skill);
        EntityClass entity = new EntityClass("GUERRIER", 100, 100, 25, 2, 12, 8, Entities.player, skills);
        Player player = new Player(name, 0, 100, 100, 100, 100, 25, 20, 12, 8, new Location(0, 0), entity, 0, 0, user);
        return player;
    }

    public LocalUser ConnectUser(string pseudo, string password) {
        foreach (LocalUser _ in this.usersStorage)
        {
            User user = _.user;
            if (user != null && user.login.Equals(pseudo) && user.password.Equals(password)) {
                return _;
            }
        }
        return null;
    }

    public bool Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            string path = Application.persistentDataPath + PATH;
            FileStream file;
            if (File.Exists(path))
            {
                file = File.Open(path, FileMode.Open);
            }
            else
            {
                file = File.Create(path);
            }
            bf.Serialize(file, this.usersStorage);
            file.Close();
            file.Close();
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
    }
}
