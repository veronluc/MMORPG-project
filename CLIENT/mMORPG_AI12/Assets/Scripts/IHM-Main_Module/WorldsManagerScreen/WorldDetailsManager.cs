using System.Collections.Generic;
using AI12_DataObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WorldDetailsManager : MonoBehaviour
{
    private World world; // The new default world created or the world to modify

    // Buttons
    public GameObject loadButton; // Button to load a local world on the server and make the user join it
    public GameObject saveButton; // Button to save modifications on an existing world
    public GameObject createButton; // Button to ask for the creation of a new world
    public GameObject deleteButton; // Button to delete an existing world

    // Dropdown lists
    public TMP_Dropdown sizeInput;
    public TMP_Dropdown gameTypeModeInput;
    public TMP_Dropdown difficultyInput;
    public TMP_Dropdown realDeathInput;

    // Input fields
    public TMP_InputField nameInput;
    public TMP_InputField timeInput;
    public TMP_InputField nbPlayersInput;
    public TMP_InputField nbMonstersInput;
    public TMP_InputField nbShopsInput;

    // Toggles
    public Toggle hasCityToggle;
    public Toggle hasPlainToggle;
    public Toggle hasSwampToggle;
    public Toggle hasRiverToggle;
    public Toggle hasForestToggle;
    public Toggle hasRockyPlainToggle;
    public Toggle hasMountainToggle;
    public Toggle hasSeaToggle;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Active the gameobject and set all the values to display the world information
    /// </summary>
    /// <param name="worldToDisplay">The world that contains information to display on the screen</param>
    public void SetWorldDetails(World worldToDisplay)
    {
        // Active the container that will display the world information
        this.gameObject.SetActive(true);
        bool isNewWorld =
            worldToDisplay.id == null; // world.id is null when the world is just created and not saved yet

        // If this is a creation only create action is available
        if (isNewWorld)
        {
            this.loadButton.SetActive(false);
            this.createButton.SetActive(true);
            this.deleteButton.SetActive(false);
            this.saveButton.SetActive(false);
        }
        // Else if it is an existing world, the user can delete it, load it or save modifications
        else
        {
            this.loadButton.SetActive(true);
            this.createButton.SetActive(false);
            this.deleteButton.SetActive(true);
            this.saveButton.SetActive(true);
        }

        this.world = worldToDisplay; // Save the current world

        // Initiate the current values on the dropdown lists (default or previous ones)
        this.sizeInput.value = worldToDisplay.sizeMap;
        this.gameTypeModeInput.value = worldToDisplay.gameMode == GameMode.pve ? 0 : 1;
        this.difficultyInput.value = worldToDisplay.difficulty;
        this.realDeathInput.value = worldToDisplay.realDeath ? 0 : 1;

        // Initiate the current values on the input fields (default or previous ones)
        this.nameInput.text = worldToDisplay.name;
        this.timeInput.text = worldToDisplay.roundTimeSec.ToString();
        this.nbPlayersInput.text = worldToDisplay.nbMaxPlayer.ToString();
        this.nbMonstersInput.text = worldToDisplay.nbMaxMonsters.ToString();
        this.nbShopsInput.text = worldToDisplay.nbShops.ToString();

        // Initiate the current values on the toggle elements (default or previous ones)
        this.hasCityToggle.isOn = worldToDisplay.hasCity;
        this.hasPlainToggle.isOn = worldToDisplay.hasPlain;
        this.hasSwampToggle.isOn = worldToDisplay.hasSwamp;
        this.hasRiverToggle.isOn = worldToDisplay.hasRiver;
        this.hasForestToggle.isOn = worldToDisplay.hasForest;
        this.hasRockyPlainToggle.isOn = worldToDisplay.hasRockyPlain;
        this.hasMountainToggle.isOn = worldToDisplay.hasMontain;
        this.hasSeaToggle.isOn = worldToDisplay.hasSea;
    }

    // ON CLICKS METHODS --------------------------------------------------------------------------

    /// <summary>
    /// Called when the user clicks on the "DELETE" button
    /// </summary>
    public void OnClickDeleteWorld()
    {
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .DeleteWorld(world);
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Called when the user clicks on the "SAVE" button
    /// </summary>
    public void OnClickSaveWorld()
    {
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .UpdateWorld(world);
    }

    /// <summary>
    /// Called when the user clicks on the "LOAD" button
    /// </summary>
    public void OnClickLoadWorld()
    {
        // TODO : call the character popup and choose a real player from user players list
        Debug.Log("1-" + GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>());
        Debug.Log("2-" + GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>().localUser);
        Debug.Log("3-" + GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>().localUser.user);
        Debug.Log("4-" + GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>().localUser.user.players);
        Debug.Log("5-" + GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>().localUser.user.players.Count);
        Player player = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<IHMMainModule>().localUser.user
            .players[0];
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .LoadWorld(player, world.id);
    }

    /// <summary>
    /// Called when the user clicks on the "CREATE" button
    /// </summary>
    public void OnClickCreateWorld()
    {
        Debug.Log(world);
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .CreateWorld(world.name, world.sizeMap, world.gameMode, world.realDeath, world.difficulty,
                world.roundTimeSec, world.nbMaxPlayer, world.nbMaxMonsters,
                world.nbShops, world.hasCity, world.hasPlain, world.hasSwamp, world.hasRiver, world.hasForest,
                world.hasRockyPlain, world.hasMontain, world.hasSea);
    }

    // SETTERS -----------------------------------------------------------------------------------

    /// <summary>
    /// Set the name of the world
    /// </summary>
    /// <param name="name">The new name of the world</param>
    public void SetName(string name)
    {
        this.world.name = name;
    }

    /// <summary>
    /// Set the size of the world
    /// </summary>
    /// <param name="size">The dropdown list index representing the new size of the world</param>
    public void SetMapSize(int size)
    {
        this.world.sizeMap = size;
    }

    /// <summary>
    /// Set the game mode type for the world (pve or pvp)
    /// </summary>
    /// <param name="type">The dropdown list index representing the new game mode type of the world</param>
    public void SetType(int type)
    {
        this.world.gameMode = type == 0 ? GameMode.pve : GameMode.pvp;
    }

    /// <summary>
    /// Set the difficulty of the world
    /// </summary>
    /// <param name="difficulty">The dropdown list index representing the new difficulty of the world</param>
    public void SetDifficulty(int difficulty)
    {
        this.world.difficulty = difficulty;
    }

    /// <summary>
    /// Set the round time of the world
    /// </summary>
    /// <param name="roundTime">The new round time in seconds</param>
    public void SetRoundTime(string roundTime)
    {
        this.world.roundTimeSec = !roundTime.Equals("") ? int.Parse(roundTime) : 30;
    }

    /// <summary>
    /// Set the permanent death rule for the world
    /// </summary>
    /// <param name="realDeath">The dropdown list index representing if permanent death is activate for the world</param>
    public void SetRealDeath(int realDeath)
    {
        Debug.Log(realDeath);
        // If the index is 0, the user selected a real death rule
        this.world.realDeath = realDeath == 0;
    }

    /// <summary>
    /// Set the maximum number of players for the world
    /// </summary>
    /// <param name="maxPlayers">The new max number of players</param>
    public void SetMaxPlayers(string maxPlayers)
    {
        this.world.nbMaxPlayer = !maxPlayers.Equals("") ? int.Parse(maxPlayers) : 1;
    }

    /// <summary>
    /// Set the maximum number of monsters for the world
    /// </summary>
    /// <param name="maxMonsters">The new max number of monsters</param>
    public void SetMaxMonsters(string maxMonsters)
    {
        this.world.nbMaxMonsters = !maxMonsters.Equals("") ? int.Parse(maxMonsters) : 50;
    }

    /// <summary>
    /// Set the number of shops for the world
    /// </summary>
    /// <param name="nbShops">The new number of shops</param>
    public void SetNbShops(string nbShops)
    {
        this.world.nbShops = !nbShops.Equals("") ? int.Parse(nbShops) : 0;
    }

    /// <summary>
    /// Set the use of city tiles for the map of the world
    /// </summary>
    /// <param name="hasCity">Boolean to indicate if the world's map can contain city tiles</param>
    public void SetHasCity(bool hasCity)
    {
        this.world.hasCity = hasCity;
    }

    /// <summary>
    /// Set the use of plain tiles for the map of the world
    /// </summary>
    /// <param name="hasPlain">Boolean to indicate if the world's map can contain plain tiles</param>
    public void SetHasPlain(bool hasPlain)
    {
        this.world.hasPlain = hasPlain;
    }

    /// <summary>
    /// Set the use of swamp tiles for the map of the world
    /// </summary>
    /// <param name="hasSwamp">Boolean to indicate if the world's map can contain swamp tiles</param>
    public void SetHasSwamp(bool hasSwamp)
    {
        this.world.hasSwamp = hasSwamp;
    }

    /// <summary>
    /// Set the use of river tiles for the map of the world
    /// </summary>
    /// <param name="hasRiver">Boolean to indicate if the world's map can contain river tiles</param>
    public void SetHasRiver(bool hasRiver)
    {
        this.world.hasRiver = hasRiver;
    }

    /// <summary>
    /// Set the use of forest tiles for the map of the world
    /// </summary>
    /// <param name="hasForest">Boolean to indicate if the world's map can contain forest tiles</param>
    public void SetHasForest(bool hasForest)
    {
        this.world.hasForest = hasForest;
    }

    /// <summary>
    /// Set the use of rocky plain tiles for the map of the world
    /// </summary>
    /// <param name="hasRockyPlain">Boolean to indicate if the world's map can contain rocky plain tiles</param>
    public void SetHasRockyPlain(bool hasRockyPlain)
    {
        this.world.hasRockyPlain = hasRockyPlain;
    }

    /// <summary>
    /// Set the use of mountain tiles for the map of the world
    /// </summary>
    /// <param name="hasMountain">Boolean to indicate if the world's map can contain mountain tiles</param>
    public void SetHasMountain(bool hasMountain)
    {
        this.world.hasMontain = hasMountain;
    }

    /// <summary>
    /// Set the use of sea tiles for the map of the world
    /// </summary>
    /// <param name="hasSea">Boolean to indicate if the world's map can contain sea tiles</param>
    public void SetHasSea(bool hasSea)
    {
        this.world.hasSea = hasSea;
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
        List<Skill> skills = new List<Skill>() { skill };
        EntityClass entity = new EntityClass("GUERRIER", 100, 100, 25, 2, 12, 8, Entities.player, skills);
        Player player = new Player(name, 0, 100, 100, 100, 100, 25, 20, 12, 8, new Location(0, 0), entity, 0, 0, null);
        User user = new User("Jean Né marre", "idididid", "Des classes sans constructeur", "Créer un player prend",
            "Créer un player prend", new DateTime(2020, 11, 16), "/C/vide", new List<Player>(), new List<World>());
        user.players.Add(player);
        player.user = user;
        return player;
    }
}