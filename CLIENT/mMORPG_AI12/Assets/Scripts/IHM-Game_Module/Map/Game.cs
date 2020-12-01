using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Reference from Unity IDE
    public GameObject warrior;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(warrior, new Vector3(0, 0, -2), Quaternion.identity);
    }

}
