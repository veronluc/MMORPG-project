using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string Size = "15x15"; 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
