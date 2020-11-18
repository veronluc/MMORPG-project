using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeText : MonoBehaviour
{
    private PlayerCaracteristics playerCaracteristics;
    public Text textLife;

    // Start is called before the first frame update
    void Start()
    {
        playerCaracteristics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCaracteristics>();
        textLife.text = playerCaracteristics.life.ToString();
    }
}
