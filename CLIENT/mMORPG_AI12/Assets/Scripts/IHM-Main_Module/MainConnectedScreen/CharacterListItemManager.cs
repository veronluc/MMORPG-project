using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterListItemManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI type;
    public TextMeshProUGUI level;

    /// <summary>
    /// Set the player info. to this GameObject (to show it on the screen)
    /// </summary>
    /// <param name="player"></param>
    public void SetPlayerToGameObject(Player player)
    {
        this.playerName.text = player.name;

        this.type.text = player.entityClass.name;

        this.level.text = player.level.ToString();
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    public void SetRandomInfoToGameObject()
    {

        this.playerName.text = "PlayerOne";

        this.type.text = "GUERRIER";

        this.level.text = "LVL100";

    }
}
