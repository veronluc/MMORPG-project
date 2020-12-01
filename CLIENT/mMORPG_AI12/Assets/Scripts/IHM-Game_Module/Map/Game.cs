using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Reference from Unity IDE
    public GameObject player;
    // public GameObject warriorInstance;

    // Positions and team for each chesspiece
    private GameObject[,] positions = new GameObject[15, 15]; // à modifier dynamiquement
    private GameObject[] players = new GameObject[16]; // à modifier par rapport au nombre de players différents

    // private bool gameOver = false;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _camera.orthographic = true;
    }

    // Start is called before the first frame update
    void Start()
    {

        players = new GameObject[]
        {
            Create("robber", 12, 12)
        };

        for (int i = 0; i < players.Length; i++)
        {
            SetPosition(players[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(player, new Vector3(0, 0, -0.2f), Quaternion.identity);
        GamePlayer gp = obj.GetComponent<GamePlayer>();
        gp.name = name;
        gp.SetXBoard(x);
        gp.SetYBoard(y);
        gp.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        GamePlayer gp = obj.GetComponent<GamePlayer>();

        positions[gp.GetXBoard(), gp.GetYBoard()] = obj;

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

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

}
