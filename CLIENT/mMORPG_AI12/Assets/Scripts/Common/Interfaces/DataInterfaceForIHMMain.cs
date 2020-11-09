using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

public interface DataInterfaceForIHMMain
{
    World LoadWorld(World world);
    World UnloadWorld(World world);
    List<World> GetWorlds();
    void SaveWorld(World world);
    World RestoreWorld(string name);
    void ConnectPlayerToWorld(Player player, World world);
    void ChangeScene(GameState scene);
    void CreateUser(string login, string password, string firstName, string lastName, string birthDate, string image);
    (List<User>, List<World>) ConnectUser(User user);
    void DisconnectUser(User user);
    List<User> GetConnectedUsers();
    // Player CreatePlayer(Class class, string name);
    List<Player> ListPlayers();
    void DeletePlayer(Player player);
    Player EditPlayer(Player editedPlayer);
    World CreateWorld(string name, int sizeMap, GameMode gameMode, bool realDeath);
}