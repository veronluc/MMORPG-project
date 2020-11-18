using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameText : MonoBehaviour
{

    private PlayerCaracteristics playerCaracteristics;
    public Text textName;

    // Start is called before the first frame update
    void Start()
    {
        playerCaracteristics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCaracteristics>();
        textName.text = playerCaracteristics.playerName;
    }
}
