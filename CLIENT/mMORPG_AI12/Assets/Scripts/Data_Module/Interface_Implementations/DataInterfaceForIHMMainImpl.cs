using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public class DataInterfaceForIHMMainImpl : DataInterfaceForIHMMain
{
    public void LoadWorld(ref World world)
    {
        DataModule.networkInterface.AddNewWorld(world);
    }

    public World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, List<Player> players, List<Monster> monsters, Player creator, GameState gameState)
    {
        return new World(name, sizeMap, gameMode, realDeath, difficulty, roundTimeSec, nbMaxPlayer, nbMaxMonsters, nbShops, hasCity, hasPlain, hasSwamp, hasRiver, hasForest, hasRockyPlain, hasMontain, hasSea, players, monsters, creator, gameState);
    }

    public void JoinWorld(string worldId)
    {
        // TODO int ou string pour l'id du monde ?
        DataModule.networkInterface.ConnectToWorld(worldId);
        // TODO check la liste de mondes en local (ou pas, à voir en fonction de la fonction serveur), récupérer le token de l'utilisateur courant et faire l'appel au serveur
    }


    public void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    public void UpdateUser(string login, string password, string firstName, string lastName, string birthDate, string image) { }
    public string CreateUserSession(string pseudo, string password) { return null; }
    public void ConnectSessionToServer(string worldId, string ipServer, string port) { } 
    
    public void GetWorldDetails(string worldId) { }
    public void GetUserDetails(string userId) { }
    public void LogOut() { }
    public void SaveWorld(World world) { }
    public World RestoreWorld(string name) { return null; }
    public Player CreatePlayer(EntityClass entityClass, string name) { return null; }
    public List<Player> ListPlayers() { return null; }
    public void DeletePlayer(Player player) { }
    public Player EditPlayer(Player editedPlayer) { return null; }


    


    public void GetWorlds() { }
}
