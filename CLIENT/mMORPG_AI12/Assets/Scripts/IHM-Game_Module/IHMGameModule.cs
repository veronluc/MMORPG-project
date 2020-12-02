using System;
using System.Collections;
using System.Collections.Generic;
using AI12_DataObjects;
using UnityEngine;
using Action = AI12_DataObjects.Action;

public class IHMGameModule : MonoBehaviour
{
    // Usable for inter-module communication
    public DataInterfaceForIHMGame dataInterface { get; set; }

    // Instanciated interface for the other module(s)
    public IHMGameInterfaceImpl ihmGameInterface { get; set; }
    public Player Player { get; set; }
    public GameState GameState { get; set; }
    public World World { get; set; }
    public User User { get; set; }
    // GameManager to manage chat messages
    public GameManager gameManager { get; set; }
    
    private void Awake()
    {
        ihmGameInterface = new IHMGameInterfaceImpl();
        gameManager = new GameManager();
        ihmGameInterface.gameManager = gameManager;
    }

    public void clickOnSkill(int SkillNumber)
    {
        throw new NotImplementedException();
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
        // Envoyer action à Data
        // Reset l’objet qui dit que le joueur peut jouer (n’est pas un objet qui s’affiche)
    }

    public void ExecuteAction(Action action) {
        // switch(action.getType) { // Ca ne sera surement pas comme ça mais c’est l’idée
        //     case skill : ExecuteSkillAction(action);
        //         break;
        //     case move : ExecuteMoveAction(action);
        //         break;
        //     default : do nothing
        //         break;
        // }
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

    
}
