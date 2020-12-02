using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaText : MonoBehaviour
{
    private PlayerCaracteristics playerCaracteristics;
    public Text textMana;

    private void Start()
    {
        playerCaracteristics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCaracteristics>();

        textMana.text = playerCaracteristics.mana.ToString();
    }
}
