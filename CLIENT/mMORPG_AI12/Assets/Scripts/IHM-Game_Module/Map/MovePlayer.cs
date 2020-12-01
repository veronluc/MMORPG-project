using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    // Board positions, not world positions
    int matrixX;
    int matrixY;

    // false: movement, true : attacking;
    public bool action = false;


    public void Start()
    {
        if (action)
        {
            // Change to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (action)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<GamePlayer>().GetXBoard(),
            reference.GetComponent<GamePlayer>().GetYBoard());

        reference.GetComponent<GamePlayer>().SetXBoard(matrixX);
        reference.GetComponent<GamePlayer>().SetYBoard(matrixY);
        reference.GetComponent<GamePlayer>().SetCoords();

        //Update the matrix
        controller.GetComponent<Game>().SetPosition(reference);


        reference.GetComponent<GamePlayer>().DestroyMovePlates();
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
