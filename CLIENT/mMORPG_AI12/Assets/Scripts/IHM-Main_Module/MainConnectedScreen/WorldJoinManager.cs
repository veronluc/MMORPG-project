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
        characterListItemPrefab = (GameObject)Resources.Load("CharacterListItem");
        characterGameObjectList = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        //TODO
        //Récupération du current User pour afficher ses Players
        List<Player> players = new List<Player>();
        players.Add(TestCreatePlayer());
        players.Add(TestCreatePlayer("JOUEUR2"));
        SetPlayerList(players);
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
    /// Function called by the "CONNECT" Butoon on the popup Screen (player choice)
    /// </summary>
	public void ConnectToAWorld()
    {
        //Call a the Function useful to connect to a world
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>().JoinWorld(this.selectedItem.GetComponent<CharacterListItemManager>().GetPlayer(), this.worldIdToJoin);
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

		//Destroy all worlds on the screen
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
			newObj = (GameObject)Instantiate(characterListItemPrefab, characterContainer.transform);

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
    /// Function called when a click is done one one of the Character items
    /// </summary>
    /// <param name="playerItem">The GameObject item to save (in order to use it later when clicking ont he "CONNECT" button)</param>
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
    private Player TestCreatePlayer(string name = "JOUEUR")
    {
        // TO MODIFY (v2) : replace those lines with the user's chosen player (via choose player Popup) when the connection will be implemented
        Player player = new Player();
        player.gold = 0;
        player.xp = 0;
        player.name = name;
        player.level = 0;
        player.vitalityMax = 100;
        player.vitality = 100;
        player.manaMax = 100;
        player.mana = 100;
        player.strength = 25;
        player.intelligence = 20;
        player.defense = 12;
        player.pM = 8;
        player.location = new Location(0, 0);
        player.entityClass = new EntityClass();
        player.entityClass.name = "GUERRIER";
        player.entityClass.baseVitality = 100;
        player.entityClass.baseMana = 100;
        player.entityClass.baseStrength = 25;
        player.entityClass.baseIntelligence = 2;
        player.entityClass.baseDefense = 12;
        player.entityClass.basePM = 8;
        player.entityClass.exclusive = Entities.player;
        player.entityClass.skills = new List<Skill>();
        Skill skill = new Skill();
        skill.zone = 2;
        skill.damagePoints = 4;
        skill.costMana = 2;
        skill.range = new Range();
        skill.range.shape = shapes.star;
        player.entityClass.skills.Add(skill);
        User user = new User();
        user.login = "Jean Né marre";
        user.password = "Des classes sans constructeur";
        user.firstName = "Créer un player prend";
        user.lastName = "41 lignes...";
        user.birthDate = new DateTime(2020, 11, 16);
        user.imageRef = "/C/vide";
        user.players = new List<Player>();
        user.players.Add(player);
        player.user = user;
        return player;
    }
}
