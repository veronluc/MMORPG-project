using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaracteristics : MonoBehaviour
{
    public int mana;
    public int life;
    public int move;
    public string playerName;

    public void UseSkill(int manaSpent)
    {
        mana -= manaSpent;
        Debug.Log("Mana = " + mana.ToString());
    }
}
