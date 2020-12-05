using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Défini la création des zones de déplacement lorsqu'on souhaite se déplacer.
/// </summary>
public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    public GameObject reference { get; set; }

    // variable nous permettant d'avoir accès aux attributs et méthodes de ihmGameModule
    private IHMGameModule ihmGameModule;

    // Board positions, not world positions
    int matrixX;
    int matrixY;

    // false: movement, true : attacking;
    public bool action = false;

    /// <summary>
    /// Si le MovePlate se trouve sur la case d'un adversaire qui peut se faire attaquer, elle devient rouge.
    /// </summary>
    public void Start()
    {
        // récupération des attributs et méthodes de ihmGameModule (pour avoir le world, le gameState...
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();
        reference = null;
        if (action)
        {
            // Change to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    /// <summary>
    /// Lorsque l'utilisateur relâche le bouton de la souris, soit le player se positionne à la case qui a été cliquée s'il n'y avait personne, 
    /// soit l'adversaire qui se trouvait sur la case cliquée est éliminé de la map, puis le player se positionne sur la case qui a été cliquée 
    /// (comme aux échecs)
    /// </summary>
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Si c'est une attaque, on récupère la position de la case cliquée et on détruit le GameObject de l'adversaire qui s'y trouvait
        // avant la destruction, on envoie la position de la case cliquée à IHMGameModule dans targetedEntity
        if (action)
        {
            GameObject enemyEntity = controller.GetComponent<GameMovements>().GetPosition(matrixX, matrixY);
            ihmGameModule.targetedEntity = enemyEntity;
            Destroy(enemyEntity);
        }

        //On récupère l'ancienne position du player pour le remettre à null
        controller.GetComponent<GameMovements>().SetPositionEmpty(reference.GetComponent<GameEntity>().GetXBoard(),
            reference.GetComponent<GameEntity>().GetYBoard());

        //On assigne la position de la case cliquée à celui du player pour effectuer son déplacement
        reference.GetComponent<GameEntity>().SetXBoard(matrixX);
        reference.GetComponent<GameEntity>().SetYBoard(matrixY);
        reference.GetComponent<GameEntity>().SetCoords();

        //Update the matrix
        // si c'est un autre joueur de la partie, on appelle cette méthode (SetPosition) 
        //qui ne fait pas bouger la caméra vers l'autre joueur
        if (reference.GetComponent<GameEntity>().user == null)  
        {
            controller.GetComponent<GameMovements>().SetPosition(reference);
        }
        //Sinon, c'est notre joueur qui bouge, il faut donc appeler SetPositionPlayerUser 
        //qui fait la même chose que SetPosition avec la caméra qui se centre au nouvel endroit
        else
        {
            controller.GetComponent<GameMovements>().SetPositionPlayerUser(reference);
        }

        //Une fois le player déplacé, on détruit les MovePlates
        reference.GetComponent<GameEntity>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
