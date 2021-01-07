using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

/// <summary>
/// La classe GameMovement est liée au GameObject Controller.
/// Elle permet d'instancier le joueur sur la map et de le déplacer à une case donnée.
/// </summary>
public class GameMovements : MonoBehaviour
{
    //La var entityObject est initialisée par un prefab qu'on clique et dépose dans l'inspector du GameObject Controller, dans le champ EntityObject
    public GameObject entityObject;

    //La var position correspond à la grille sur laquelle nous allons positionner les joueurs
    private GameObject[,] positions;

    //La var entities va contenir l'ensemble des joueurs et monstres de la partie
    private GameObject[] entities;

    //Variable nous permettant d'avoir accès aux attributs et méthodes de ihmGameModule
    private IHMGameModule ihmGameModule;

    //La var _camera va être utilisée pour qu'elle soit toujours centrée sur le joueur, peut importe sa position sur la map.
    private Camera _camera; // non respect des conventions de nommage voulu, le nom camera est déjà pris par une variable native de Unity.

    public GameState gameState;
    public Player playerUser;
    public User user;

    private void Awake()
    {
        //On initialise la caméra avec la Main Camera.
        _camera = Camera.main;
        
        //On met la camera en orthographic afin de supprimer l'effet de perspective sur la scène.
        _camera.orthographic = true;
    }

    // Start is called before the first frame update
    /// <summary>
    /// Crée à la fois la grille de déplacement et la liste des players de la map.
    /// </summary>
    void Start()
    {
        // récupération des attributs et méthodes de ihmGameModule
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();

        gameState = ihmGameModule.gameState;
        playerUser = ihmGameModule.player;
        user = ihmGameModule.user;

        // Crée la grille de déplacement
        Debug.Log(ihmGameModule.world);
        if (ihmGameModule.world != null)
        {
            positions = new GameObject[ihmGameModule.world.sizeMap, ihmGameModule.world.sizeMap];
            // nombre d'entities présentes dans le jeu + le player actuel
            entities = new GameObject[ihmGameModule.world.players.Count + ihmGameModule.world.monstersList.Count + 1];
        }
        Debug.Log(entities.Length);
        //On fait appelle à la méthode Create() définie ci-dessous pour créer un nouveau personnage 
        //en précisant son type et sa position initiale sur la map pour l'insérer dans la liste players
        for (int i = 0; i < entities.Length - 1; i++)
        {
            Debug.Log("FOR");
            entities[i] = Create(gameState.turns[i].entityClass.name,
                null, // user = null
                gameState.turns[i].location.x,
                gameState.turns[i].location.y);
        }
        //On parcoure chaque personnage de la liste players pour les placer sur la map à l'aide 
        //de la méthode SetPosition() définie ci-dessous
        for (int i = 0; i < entities.Length - 1; i++)
        {
            Debug.Log("SET");
            SetPosition(entities[i]);
        }
        
        // On crée et insère notre joueur actif lié à l'utilisateur à la liste entities[]
        entities[entities.Length - 1] = Create(playerUser.entityClass.name,
            user,
            playerUser.location.x,
            playerUser.location.y);
        
        //SetPositionPlayerUser fait la même chose que SetPosition() à la seule différence 
        //que la caméra se centre sur le personnage de l'utilisateur une fois qu'il s'est déplacé
        SetPositionPlayerUser(entities[entities.Length - 1]);
        
    }

    /// <summary>
    /// La méthode Create() permet d'instancier un personnage avec son type et sa position initiale sur la map
    /// </summary>
    /// <param name="name">Type du personnage (voleur, guerrier, monstre, etc)</param>
    /// <param name="x">Position initiale du personnage sur l'axe x</param>
    /// <param name="y">Position initiale du personnage sur l'axe y</param>
    /// <returns>GameObject</returns>
    public GameObject Create(string name, User user, int x, int y)
    {
        GameObject obj = Instantiate(entityObject, new Vector3(0, 0, -0.2f), Quaternion.identity);
        GameEntity gp = obj.GetComponent<GameEntity>();
        gp.name = name; // entityClassName
        gp.user = user;
        gp.SetXBoard(x);
        gp.SetYBoard(y);
        gp.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        GameEntity gp = obj.GetComponent<GameEntity>();

        positions[gp.GetXBoard(), gp.GetYBoard()] = obj;

    }
    
    public void SetPositionPlayerUser(GameObject obj)
    {
        GameEntity gp = obj.GetComponent<GameEntity>();

        positions[gp.GetXBoard(), gp.GetYBoard()] = obj;

        //On centre la caméra sur la position du joueur de l'utilisateur
        _camera.transform.position = new Vector3(gp.transform.position.x, gp.transform.position.y, -6.5f);

    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    /// <summary>
    /// Cette fonction assure que le joueur ne peut se déplacer que dans la map et non en dehors
    /// </summary>
    /// <param name="x">Position sur l'axe x</param>
    /// <param name="y">Position sur l'axe y</param>
    /// <returns>Booléen</returns>
    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

}
