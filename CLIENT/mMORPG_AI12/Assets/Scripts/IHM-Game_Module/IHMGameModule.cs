using System;
using System.CodeDom;
using System.Linq;
using AI12_DataObjects;
using UnityEngine;
using Action = AI12_DataObjects.Action;

public class IHMGameModule : MonoBehaviour
{
    
    public DataInterfaceForIHMGame dataInterface { get; set; }
    public IHMGameInterfaceImpl ihmGameInterface { get; set; }
    public Player player { get; set; }
    public GameState gameState { get; set; }
    public World world { get; set; }
    public User user { get; set; }
    // GameManager to manage chat messages
    public GameManager GameManager { get; set; }

    // Helps to know if a skill is being used
    private Skill CurrentSkill { get; set; }
    // placement des joueurs sur la map
    public GameEntity gamePlayer { get; set; }
    public MovePlate movePlate { get; set; }

    public GameObject targetedEntity { get; set; }

    //public world
    private void Awake()
    {
        ihmGameInterface = new IHMGameInterfaceImpl();
        GameManager = new GameManager();
        ihmGameInterface.gameManager = GameManager;
    }

    private void Start()
    {
        // récupération des attributs et méthodes de GameEntity
        gamePlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEntity>();
        // récupération des attributs et méthodes de ihmGameModule
        movePlate = GetComponent<MovePlate>();
    }

    public void clickOnSkill(string skillName)  // Il vaudrait mieux faire les actions de cette fonction dans la méthode ViewSkill Distance de GameEntity
    {
        CurrentSkill = player.entityClass.skills.Where(skill => skill.name == skillName).ToList().First();
        //Afficher sur la carte la distance d’attaque de l’utilisateur
        gamePlayer.ViewSkillDistance();  // mettre en parametre le skill et modifier la méthode ViewSkillDistance() ; pas sûr que ça compile
        //Avoir un objet qui enregistre la skill en cours (objet A)

        
    }
    public void ClickOnCase() {  // Il vaudrait mieux faire les actions de cette fonction dans la méthode OnMouseUp de MovePlate.cs

        // Récupérer la case qui a été cliquée : c'est ce qui est fait dans la fonction OnMouseUp (exemple dans MovePlate.cs)
        int caseX = movePlate.reference.GetComponent<GameEntity>().GetXBoard(); // pas sûr que ça compile
        int caseY = movePlate.reference.GetComponent<GameEntity>().GetYBoard(); // pas sûr que ça compile
        // Si une skill est en cours (ref à la fonction précédente) alors
        //     Récupérer les entités visées par la skill : une entité plutôt non ? C'est déjà fait
        //
        // 
        //
        // Reset l’objet A (pour qu’il n’y ai plus de skill en cours)
        // Créer l’action qui associé à l’utilisation de ce skill
        // Envoyer l’action à data
        //     Exécuter l’action côté game
        //     Sinon
        // Si la case fait partie de la zone de déplacement du joueur (en gros si le joueur peut s’y déplacer)
        // Créer action pour le déplacement
        //     Envoyer l’action à data
        //     Exécuter l’action côté game
        //     Sinon
        // Ne rien faire et quitter la fonction
    }

    public void ClickOnEndOfTurn() {  // à faire dans le OnMouseUp de MovePlate.cs (la fin du tour c'est après avoir fait une action ou un déplacement
        //Créer action pour fin de tour
        Action action = new ActionEndRound(player, world);
        // Envoyer action à Data
        dataInterface.MakeAction(action);
        // Reset l’objet qui dit que le joueur peut jouer (n’est pas un objet qui s’affiche)
    }

    public void ExecuteAction(Action action)  // à faire dans le if (action) de OnMouseUp de MovePlate.cs
    {
        switch (action)
        {
            case ActionMove _:
                ExecuteMoveAction(action);
                break;
            case ActionRest _:
                ExecuteRestAction(action);
                break;
            case ActionSkill _:
                ExecuteSkillAction(action);
                break;
        }
    }

    public void ExecuteSkillAction(Action action) {
        // Récupérer le player qui correspond à celui mentionné dans l’action
        //     Récupérer la ou les tiles qui sont visées par l’action
        //     Récupérer le ou les entités qui sont sur les tiles récupérées
        // Calculer les dommages reçu pour chaque entités
    }

    public void ExecuteMoveAction(Action action) {
        // Récupérer le player qui correspond à celui mentionné dans l’action
        //     Changer sa position avec les nouvelles qui sont dans l’action
    }
    
    public void ExecuteRestAction(Action action) {
        
    }

    
}
