using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    //References to objects in our Unity Scene
    public GameObject controller;
    public GameObject movePlate;

    //Position for this Warrior on the Board
    //The correct position will be set later
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable for keeping track of the player it belongs to "black" or "white"
    private string player;

    //References to all the possible character that this Player could be
    public Sprite warrior, robber;

    public void Activate()
    {
        // reference sprites
        warrior = (Sprite)Resources.Load("Players/warrior", typeof(Sprite));
        robber = (Sprite)Resources.Load("Players/robber", typeof(Sprite));
        //Get the game controller
        controller = GameObject.FindGameObjectWithTag("GameController");

        //Take the instantiated location and adjust transform
        SetCoords();

        //Choose correct sprite based on character's name
        switch (this.name)
        {
            case "warrior": this.GetComponent<SpriteRenderer>().sprite = warrior; player = "black"; break;
            case "robber": this.GetComponent<SpriteRenderer>().sprite = robber; player = "black"; break;
        }
    }

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

    private void OnMouseUp()
    {
        DestroyMovePlates();

        InitiateMovePlates();
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "warrior":
            case "robber":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, -1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<GamePlayer>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

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

        MovePlayer mpScript = mp.GetComponent<MovePlayer>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

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

        MovePlayer mpScript = mp.GetComponent<MovePlayer>();
        mpScript.action = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
