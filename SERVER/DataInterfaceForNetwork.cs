using System;
using AI12_DataObjects;
public interface DataInterfaceForNetwork
{
    List<User> GetUsersFromWorld(World world);
    GameState MakeAction(Action action, World world, Player player);
    Player GetNextPlayer(World world);
    void LoadWorld(World world);
    void UnloadWorld(World world);
    List<World> GetWorlds();
    World GetWorldDetails(string idWorld);
    (List<User>, List<World>) ConnectUser(User user);
    void DisconnectUser();
    List<User> GetConnectedUsers();
    User GetUserData(string userId);
    void SendChatMessage(World world, Message message, Player player);
}
