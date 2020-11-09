using System;
public interface NetworkInterface
{
    /// <summary>
    /// Envoyer une liste de worlds à un utilisateur user.
    /// </summary>
    /// <param name="user">Utilisateur de destination</param>
    /// <param name="worlds">Liste de worlds</param>
    void SendWorldsList(User user, List<World> worlds);

    /// <summary>
    /// Envoyer une liste d'utilisateurs à un utilisateur user.
    /// </summary>
    /// <param name="user">Utilisateur de destination</param>
    /// <param name="users">Liste de users à envoyer</param>
    void SendUsersList(User user, List<User> users);

    /// <summary>
    /// Envoyer une liste d'utilisateurs connectés à un monde à un utilisateur user.
    /// </summary>
    /// <param name="user">Utilisateur de destination</param>
    /// <param name="users">Liste des utilisateurs connectés au monde world </param>
    /// <param name="world">Monde sur lequel sont connectés les utilisateurs de la liste</param>
    void SendUsersListFromWorld(User user, List<User> users, World world);

    /// <summary>
    /// Envoyer un message à un client (user)
    /// </summary>
    /// <param name="user">User de destination</param>
    /// <param name="message">Message à envoyer</param>
    void SendMessageToUser(User user, Message message);

    /// <summary>
    /// Envoyer une action d'un personnage (player) à un client (user)
    /// </summary>
    /// <param name="user">User de destination</param>
    /// <param name="action">Action effectué</param>
    /// <param name="player">Personnage de la partie qui a effectué l'action</param>
    void SendActionToUser(User user, Action action, Player player);

    /// <summary>
    /// Envoyer une action d'un monstre (monster) à un client (user)
    /// </summary>
    /// <param name="user">User de destination</param>
    /// <param name="action">Action effectué</param>
    /// <param name="monster">Monstre de la partie qui a effectué l'action</param>
    void SendActionToUser(User user, Action action, Monster monster);

    /// <summary>
    /// Envoyer le résultat de la demande de connexion d'un user à un monde
    /// </summary>
    /// <param name="user">User de destination</param>
    /// <param name="world">Monde auquel il se connecte</param>
    /// <param name="result">Resultat de connexion</param>
    /// <param name="message">Message du resultat</param>
    void SendConfirmationUserConnectionToWorld(User user, World world, bool result, string message);

    /// <summary>
    /// Envoyer un message au user User comme quoi le serveur va s'arreter
    /// </summary>
    /// <param name="user">User de destination</param>
    void SendStopServer(User user);

    /// <summary>
    /// Envoyer un message à userDestination que le user userDisconnected s'est deconnecté
    /// </summary>
    /// <param name="user"></param>
    void SendUserDisconnectedWorld(User userDestination, User userDisconnected);

    /// <summary>
    /// Envoyer un message à userDestination que le user userDisconnected s'est deconnecté du server
    /// </summary>
    /// <param name="user"></param>
    void SendUserDisconnectedServer(User userDestination, User userDisconnected);
}
