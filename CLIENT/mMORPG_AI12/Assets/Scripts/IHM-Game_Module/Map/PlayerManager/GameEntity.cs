using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;

/// <summary>
/// Une GameEntity correspond à une "Entity visuelle", c'est à dire qu'elle crée un GameObject représentant un Player ou un Monster.
/// Ce GameObject n'est visible que lorsqu'on lance une partie.
/// Une GameEntity est associée à un User à travers l'attribut user :
///     - user = l'utilisateur qui joue si c'est la GameEntity de l'utilisateur qui joue ;
///     - user = null s'il s'agit d'un autre utilisateur ;
///     - user = null s'il s'agit d'un monstre ;
/// Cette classe contient également les méthodes visuelles associées à une GameEntity.
/// </summary>
public class GameEntity : MonoBehaviour
{
    //References to objects in our Unity Scene
    public GameObject controller;
    public GameObject movePlate;

    // variable nous permettant d'avoir accès aux attributs et méthodes de ihmGameModule
    private IHMGameModule ihmGameModule;

    // La variable user est affectée par la fonction Create() du script GameMovements.cs
    // Il faut donc que Create() soit appelé avant que l'on utilise la variable user.
    // User vaut :
    //    - user = l'utilisateur qui joue si c'est la GameEntity de l'utilisateur qui joue ;
    //    - user = null s'il s'agit d'un autre utilisateur ;
    //    - user = null s'il s'agit d'un monstre ;
    public User user { get; set; }

    //Position for this GameEntity on the Board
    //The correct position will be set later
    private int xBoard = -1;
    private int yBoard = -1;

    //Declaration to all the possible Entity Sprite that this Player could be
    public Sprite warrior, robber, mage, priest, goblin, wizard;

    private void Start()
    {
        user = null;  // par défaut user est affecté à null
        // récupération des attributs et méthodes de ihmGameModule (pour avoir le world, le gameState...
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
    }

    /// <summary>
    /// Crée le bon Prefab à partir du nom de l'objet GameEntity qui est définit dans la méthode Create() du script GameMovements.cs
    /// Ce Prefab permet la création du GameObject associé à l'entité.
    /// </summary>
    public void Activate()
    {
        // reference sprites for players
        warrior = (Sprite)Resources.Load("Players/warrior", typeof(Sprite));
        robber = (Sprite)Resources.Load("Players/robber", typeof(Sprite));
        mage = (Sprite)Resources.Load("Players/mage", typeof(Sprite));
        priest = (Sprite)Resources.Load("Players/priest", typeof(Sprite));

        // reference sprites for monsters
        goblin = (Sprite)Resources.Load("Monsters/goblin", typeof(Sprite));
        wizard = (Sprite)Resources.Load("Monsters/wizard", typeof(Sprite));

        //Get the game controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Take the instantiated location and adjust transform
        SetCoords();

        //Choose correct sprite based on character's name and create the Prefab via SpriteRenderer method.
        switch (this.name)
        {
            case "warrior": this.GetComponent<SpriteRenderer>().sprite = warrior; break;
            case "robber": this.GetComponent<SpriteRenderer>().sprite = robber; break;
            case "mage": this.GetComponent<SpriteRenderer>().sprite = mage; break;
            case "priest": this.GetComponent<SpriteRenderer>().sprite = priest; break;
            case "goblin": this.GetComponent<SpriteRenderer>().sprite = goblin; break;
            case "wizard": this.GetComponent<SpriteRenderer>().sprite = wizard; break;
        }
    }

    /// <summary>
    /// Affecte les bonnes coordonnées à la GameEntity, lui associe un Vector3Int à son attribut transform.position.
    /// Cela servira a placer correctement le GameObject associé par rapport à la map et à la caméra.
    /// Les ajustements et constantes permettent de bien placer ce GameObject : en effet il est légèrement au dessus de la map
    /// afin qu'il soit visible.
    /// </summary>
    public void SetCoords()
    {
        //Get the board value in order to convert to xy coords
        float x = xBoard;
        float y = yBoard;

        //Adjust by variable offset
        x *= 1f;
        y *= 1f;

        //Add constants (pos 0,0)
        x -= 2f;
        y -= 1f;

        //Set actual unity values
        this.transform.position = new Vector3(x, y, -0.2f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }


    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    /// <summary>
    /// Génère des carrés noirs montrant les cases où le joueur peut se déplacer
    /// et donc attaquer un joueur ou un monstre se trouvant sur une de ces cases
    /// </summary>
    public void ViewSkillDistance()
    {
        DestroyMovePlates();
        InitiateMovePlates();
    }

    /// <summary>
    /// Efface tous les carrés noirs.
    /// Cela peut être fait lorsqu'une action/skill a été réalisé.
    /// </summary>
    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    /// <summary>
    /// Affiche les carrés noirs.
    /// </summary>
    public void InitiateMovePlates()
    {
        // les carrés noirs s'affichent seulement pour le player de l'utilisateur
        // rappel : s'il s'agit d'un monstre ou d'un player d'un autre utilsateur
        // l'attribut user de GameEntity vaut null.
        if (user == ihmGameModule.user)
        {
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // selon le type d'Entity (guerrier, voleur...) les déplacements possibles ne sont pas tous les mêmes à vérifier dans les règles du jeu
            // pour l'instant il n'y a pas de précision dans les règles du jeu
            switch (this.name)
            {
                case "warrior":
                case "robber":
                case "mage":
                case "priest":
                    DefaultMovePlate();  // génère les déplacements possibles équivalent à celui d'un roi aux échecs
                    break;
            }
        }
    }

    /// <summary>
    /// Affiche un carré noir/rouge là où il un déplacement/action est possible
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    public void PointMovePlate(int x, int y)
    {
        GameMovements sc = controller.GetComponent<GameMovements>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)  // on a aucune Entity sur la case en question
            {
                MovePlateSpawn(x, y);
            }
            // !!!!!!!! Comment bien comparer gameMode ??
            else if (ihmGameModule.world.gameMode.Equals("pve")) // si c'est du pve, seul les monstres sont des ennemis
            {
                if (cp.GetComponent<GameEntity>().name == "goblin" || cp.GetComponent<GameEntity>().name == "wizard")
                {
                    MovePlateAttackSpawn(x, y);  // on met un carré rouge sur les monstres
                }
            }
            // !!!!!!!! Comment bien comparer gameMode ??
            else if (ihmGameModule.world.gameMode.Equals("pvp")) // si c'est du pvp, toutes les entity sont des ennemis (monstres et players)
            {
                if (cp.GetComponent<GameEntity>())  // quelle que soit l'Entity, elle est attaquable
                {
                    MovePlateAttackSpawn(x, y);  // on met un carré rouge sur les monstres et les autres joueurs selon l'Entity à cet endroit
                }
            }
        }
    }

    /// <summary>
    /// Carrés noirs (ou rouge s'il y a un ennemi) s'affichant autour du joueur (équivalent au roi dans le jeu d'échecs)
    /// </summary>
    public void DefaultMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard + 0);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard + 0);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }


    /// <summary>
    /// Méthode permettant l'affichage d'un carré noir de manière visuelle (prise en compte de la caméra, cf GameZone.cs)
    /// </summary>
    /// <param name="matrixX">X (ligne de la map)</param>
    /// <param name="matrixY">Y (colonne de la map)</param>
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        //Adjust by variable offset
        x *= 1f;
        y *= 1f;

        //Add constants (pos 0,0)
        x -= 2f;
        y -= 1f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -2f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();

        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    /// <summary>
    /// Méthode permettant l'affichage d'un carré rouge de manière visuelle (prise en compte de la caméra, cf GameZone.cs)
    /// </summary>
    /// <param name="matrixX">X (ligne de la map)</param>
    /// <param name="matrixY">Y (colonne de la map)</param>
    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        //Adjust by variable offset
        x *= 1f;
        y *= 1f;

        //Add constants (pos 0,0)
        x -= 2f;
        y -= 1f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -2f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.action = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    
}
