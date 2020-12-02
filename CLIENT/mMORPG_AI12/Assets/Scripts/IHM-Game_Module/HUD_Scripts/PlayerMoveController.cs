using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveController : MonoBehaviour
{

    private PlayerCaracteristics playerCaracteristics;
    public Text textMove;

    // Start is called before the first frame update
    void Start()
    {
        playerCaracteristics = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCaracteristics>();
        textMove.text = playerCaracteristics.move.ToString();
    }
}
