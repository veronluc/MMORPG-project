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
    public Player Player { get; set; }
    public GameState GameState { get; set; }
    public World World { get; set; }
    public User User { get; set; }
    // GameManager to manage chat messages
    public GameManager GameManager { get; set; }
    private Skill CurrentSkill { get; set; }
    
    private void Awake()
    {
        ihmGameInterface = new IHMGameInterfaceImpl();
        GameManager = new GameManager();
        ihmGameInterface.gameManager = GameManager;
    }

    public void clickOnSkill(string skillName)
    {
        CurrentSkill = Player.entityClass.skills.Where(skill => skill.name == skillName).ToList().First();
        //Afficher sur la carte la distance d’attaque de l’utilisateur
        //Avoir un objet qui enregistre la skill en cours (objet A)

        
    }
    public void ClickOnCase() {
        // Récupérer la case qui a été cliquée
        // Si une skill est en cours (ref à la fonction précédente) alors
        //     Récupérer les entités visées par la skill
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

    public void ClickOnEndOfTurn() {
        //Créer action pour fin de tour
        Action action = new ActionEndRound(Player, World);
        // Envoyer action à Data
        dataInterface.MakeAction(action);
        // Reset l’objet qui dit que le joueur peut jouer (n’est pas un objet qui s’affiche)
    }

    public void ExecuteAction(Action action)
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
