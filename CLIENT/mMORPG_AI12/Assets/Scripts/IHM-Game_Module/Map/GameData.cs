using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string Size = "7x6"; 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
