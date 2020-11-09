using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NetworkInterface
{
    /// <summary>
    /// Connecter le client au serveur.
    /// </summary>
    /// <param name="user">Informations sur l'utilisateur SANS SON ID (géré par le réseau)</param>
    /// <param name="ipAdress">Adresse IP du serveur</param>
    /// <param name="port">Port de connexion du serveur</param>
    void ConnectUser(User user, string ipAdress, int port);

    /// <summary>
    /// Envoyer un messag
    /// </summary>e au serveur (le client connait l'id du user à envoyer au serveur)
    /// <param name="message">Message à envoyer</param>
    void SendChatMessage(Message message);

    /// <summary>
    /// Envoyer une action au serveur. Le client connait l'id du user à envoyer au serveur, et le serveur fait le lien entre le user et le monde auquel appartient le joueur
    /// </summary>
    /// <param name="player">Personnage en jeu</param>
    /// <param name="action">Action à effectuer</param>
    void SendAction(Player player, Action action);

    /// <summary>
    /// Envoyer un nouveau monde (world) au serveur
    /// </summary>
    /// <param name="world"></param>
    void AddNewWorld(World world);

    /// <summary>
    /// Connecter le joueur à un monde du serveur
    /// </summary>
    /// <param name="idWorld">Monde auquel le joueur doit se connecter</param>
    void ConnectToWorld(int idWorld);

    /// <summary>
    /// Envoyer une demande de la liste de tous les utilisateurs connectés du serveur
    /// </summary>
    void AskServerUserList();

    /// <summary>
    /// Envoyer une demande de la liste de tous les utilisateurs mondes du serveur
    /// </summary>
    void AskServerWorldList();

    /// <summary>
    /// Actualiser les infos de l'utilisateur et les envoyer au serveur (TOUJOURS SANS l'ID, géré par le réseau)
    /// </summary>
    /// <param name="user"></param>
    void RefreshUserInfos(User user);

    /// <summary>
    /// Envoyer une demande de deconnexion du user au monde
    /// </summary>
    void DisconnectUserFromWorld();

    /// <summary>
    /// Envoyer une demande de deconnexion du user au serveur
    /// </summary>
    void DisconnectUserFromServer();

}