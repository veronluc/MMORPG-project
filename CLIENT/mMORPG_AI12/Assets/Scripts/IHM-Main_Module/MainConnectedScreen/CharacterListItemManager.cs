using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterListItemManager : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI type;
    public TextMeshProUGUI level;

    public Button chooseItemButton;

    private Player linkedPlayer;

    /// <summary>
    /// Function used to get the player linked to the gameobject item
    /// </summary>
    /// <returns>the player linked to this gameobject (list item)</returns>
    public Player GetPlayer()
    {
        return this.linkedPlayer;
    }

    /// <summary>
    /// Set the player info. to this GameObject (to show it on the screen)
    /// </summary>
    /// <param name="player"></param>
    public void SetPlayerToGameObject(Player player)
    {
        this.linkedPlayer = player;

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

    /// <summary>
    /// Used to change the background of the item
    /// </summary>
    /// <param name="color"> the color to use for the background</param>
    public void SetItemBackgroundColor(Color color)
    {
        this.gameObject.GetComponent<Image>().color = color;
    }

    /// <summary>
    /// Used to activate the interactibility of this item (used when the player have to choose between multiple players when joining a world)
    /// </summary>
    /// <param name="functionToLaunch">The function the item will call when it will be clicked</param>
    public void ActivateChoosableItem(Action<GameObject> functionToLaunch)
    {
        this.chooseItemButton.interactable = true;
        this.chooseItemButton.onClick.AddListener(() => functionToLaunch(this.gameObject));
    }
}
