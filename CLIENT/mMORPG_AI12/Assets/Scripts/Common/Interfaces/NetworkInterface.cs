using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NetworkInterface
{
    /// <summary>
    /// Connect the client to the server.
    /// </summary>
    /// <param name="user">The info about the user WITHOUT ITS ID (Network handles it)</param>
    /// <param name="ipAdress">Server adress IP</param>
    /// <param name="port">Server connexion port</param>
    void ConnectUser(User user, string ipAdress, int port);

    /// <summary>
    /// Send a message to the server (the client already knows the id to send it to)
    /// </summary>
    /// <param name="message">Message to send</param>
    void SendChatMessage(Message message);

    /// <summary>
    /// Send an action to process to the server. The client already knows the id of the user. The server links the user to the world he is currently in.
    /// </summary>
    /// <param name="player">The player in game</param>
    /// <param name="action">Action to perform</param>
    void SendAction(Player player, Action action);

    /// <summary>
    /// Send a new workd to the server
    /// </summary>
    /// <param name="world">The world to send</param>
    void AddNewWorld(World world);

    /// <summary>
    /// Connect the player to a world on the server.
    /// </summary>
    /// <param name="idWorld">The world the player has to connect to</param>
    void ConnectToWorld(int idWorld);

    /// <summary>
    /// Send a request to recieve the full list of users connected to the server
    /// </summary>
    void AskServerUserList();

    /// <summary>
    /// Send a request to recieve the list of all world on the server.
    /// </summary>
    void AskServerWorldList();

    /// <summary>
    /// Refresh the infos about the user nd send them to the server (without id as always)
    /// </summary>
    /// <param name="user">The user with refreshed data</param>
    void RefreshUserInfos(User user);

    /// <summary>
    /// Send a logout request to a world on the server.
    /// </summary>
    void DisconnectUserFromWorld();

    /// <summary>
    /// Send a logout request to the server
    /// </summary>
    void DisconnectUserFromServer();

}