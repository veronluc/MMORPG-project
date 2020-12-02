using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldJoinManager : MonoBehaviour
{
    private GameObject characterListItemPrefab; // This is our prefab object that will be exposed in the inspector
    public GameObject characterContainer;

    private List<GameObject> characterGameObjectList;

    private string worldIdToJoin;

    public TextMeshProUGUI worldName;

    private GameObject selectedItem;

    private void Awake()
    {
        characterListItemPrefab = (GameObject) Resources.Load("CharacterListItem");
        characterGameObjectList = new List<GameObject>();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// When the gameObject is enabled, call this method.
    /// It get the players created by the user and draw a list on the screen
    /// </summary>
    private void OnEnable()
    {
        //Récupération du current User pour afficher ses Players
        List<Player> players = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>()
            .localUser.players;
        //For test purpose
        /**players = new List<Player>();
        players.Add(TestCreatePlayer());
        players.Add(TestCreatePlayer("JOUEUR2"));*/
        if (players != null)
        {
            SetPlayerList(players);
        }
        else
        {
            MessagePopupManager.ShowInfoMessage("You don't have any created players");
            ClosePopup();
        }
    }

    /// <summary>
    /// Close the popup
    /// </summary>
    public void ClosePopup()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Open the popup for a specific world
    /// </summary>
    /// <param name="world"> the world where the id will be saved in this script for the connection</param>
    public void OpenPopupForCurrentWorld(World world)
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }

        this.worldIdToJoin = world.id;
        this.worldName.text = world.name;
    }

    /// <summary>
    /// Function called by the "CONNECT" Button on the popup Screen (player choice)
    /// </summary>
    public void ConnectToAWorld()
    {
        //Call the Function useful to connect to a world
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .JoinWorld(this.selectedItem.GetComponent<CharacterListItemManager>().GetPlayer(), this.worldIdToJoin);
        Debug.Log("ID WORLD : " + this.worldIdToJoin);
        Debug.Log("PLAYER NAME : " + this.selectedItem.GetComponent<CharacterListItemManager>().GetPlayer().name);
        ClosePopup();
    }

    /// <summary>
    /// Delete the actual player list and add the new one
    /// </summary>
    /// <param name="players"></param>
    public void SetPlayerList(List<Player> players)
    {
        //Destroy all players on the screen
        if (this.characterGameObjectList.Count != 0)
        {
            foreach (GameObject obj in this.characterGameObjectList)
            {
                Destroy(obj);
            }
        }

        GameObject newObj;

        //add the new player list on the screen
        foreach (Player player in players)
        {
            // Create new instances of our prefab in the screen container (named 'content')
            newObj = (GameObject) Instantiate(characterListItemPrefab, characterContainer.transform);

            //Add this new GameObject in the list to delete it later if needed
            this.characterGameObjectList.Add(newObj);

            //add the user to the gameObject to show its info. on the screen
            newObj.GetComponent<CharacterListItemManager>().SetPlayerToGameObject(player);

            //Change the default color of the item
            newObj.GetComponent<CharacterListItemManager>().SetItemBackgroundColor(Color.white);

            //Activate the "choosability of the item"
            newObj.GetComponent<CharacterListItemManager>().ActivateChoosableItem(SelectPlayerItem);
        }
    }

    /// <summary>
    /// Function called when a click is performed on one of the Character items
    /// </summary>
    /// <param name="playerItem">The GameObject item to save (in order to use it later when clicking on the "CONNECT" button)</param>
    public void SelectPlayerItem(GameObject playerItem)
    {
        if (this.selectedItem != null)
        {
            this.selectedItem.GetComponent<CharacterListItemManager>().SetItemBackgroundColor(Color.white);
        }

        this.selectedItem = playerItem;
        this.selectedItem.GetComponent<CharacterListItemManager>().SetItemBackgroundColor(Color.green);
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    /// <returns>a player</returns>
    public Player TestCreatePlayer(string name = "JOUEUR")
    {
        // TO MODIFY (v2) : replace those lines with the user's chosen player (via choose player Popup) when the connection will be implemented
        Skill skill = new Skill();
        skill.zone = 2;
        skill.damagePoints = 4;
        skill.costMana = 2;
        skill.range = new Range(shapes.star, 10);
        List<Skill> skills = new List<Skill>() {skill};
        EntityClass entity = new EntityClass("GUERRIER", 100, 100, 25, 2, 12, 8, Entities.player, skills);
        Player player = new Player(name, 0, 100, 100, 100, 100, 25, 20, 12, 8, new Location(0, 0), entity, 0, 0, null);
        User user = new User("Jean Né marre", "idididid", "Des classes sans constructeur", "Créer un player prend",
            "Créer un player prend", new DateTime(2020, 11, 16), "/C/vide", new List<Player>(), new List<World>());
        user.players.Add(player);
        player.user = user;
        return player;
    }
}