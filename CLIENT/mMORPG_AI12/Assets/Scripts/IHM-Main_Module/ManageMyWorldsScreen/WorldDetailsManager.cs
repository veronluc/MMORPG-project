using AI12_DataObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldDetailsManager : MonoBehaviour
{
    private World world; // The new default world created or the world to modify

    public GameObject saveButton; // Button to save modifications on an existing world
    public GameObject createButton; // Button to ask for the creation of a new world
    public GameObject deleteButton; // Button to delete an existing world

    public TMP_InputField nameInput;
    public GameObject sizeInput;
    public GameObject gameTypeModeInput;
    public GameObject difficultyInput;
    public TMP_InputField timeInput;
    public GameObject realDeathInput;
    public TMP_InputField nbPlayersInput;
    public TMP_InputField nbMonstersInput;
    public TMP_InputField nbShopsInput;

    // TODO : Add gameobjects
    private bool hasCity;
    private bool hasPlain;
    private bool hasSwamp;
    private bool hasRiver;
    private bool hasForest;
    private bool hasRockyPlain;
    private bool hasMountain;
    private bool hasSea;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Ask to display a new default world
    /// </summary>
    /// <param name="defaultWorld">The default world created that has to be displayed</param>
    public void CreateNewWorld(World defaultWorld)
    {
        SetWorldDetails(defaultWorld, true);
    }

    /// <summary>
    /// Ask to display an existing world
    /// </summary>
    /// <param name="worldToModify">The existing world that has to be displayed</param>
    public void ModifyWorld(World worldToModify)
    {
        SetWorldDetails(worldToModify, false);
    }

    /// <summary>
    /// Active the gameobject and set all the values to display the world information
    /// </summary>
    /// <param name="world">The world that contains information to display in the screen</param>
    /// <param name="isNewWorld">Boolean to display appropriate action buttons regarding if it is a world creation or modification</param>
    public void SetWorldDetails(World worldToDisplay, bool isNewWorld)
    {
        // Active the container that will display the world information
        this.gameObject.SetActive(true);

        // If this is a creation only create action is available
        if (isNewWorld)
        {
            this.createButton.SetActive(true);
            this.deleteButton.SetActive(false);
            this.saveButton.SetActive(false);
        }
        // Else if it is an existing world, the user can delete it or save modifications
        else
        {
            this.createButton.SetActive(false);
            this.deleteButton.SetActive(true);
            this.saveButton.SetActive(true);
        }

        this.world = worldToDisplay;
        this.nameInput.text = worldToDisplay.name;
        this.timeInput.text = worldToDisplay.roundTimeSec.ToString();
        this.nbPlayersInput.text = worldToDisplay.nbMaxPlayer.ToString();
        this.nbMonstersInput.text = worldToDisplay.nbMaxMonsters.ToString();
        this.nbShopsInput.text = worldToDisplay.nbShops.ToString();
    }

    /// <summary>
    /// Called when the user clicks on the "DELETE" button
    /// </summary>
    public void OnClickDeleteWorld()
    {
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .DeleteWorld(world);
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
    /// Set the round time of the world
    /// </summary>
    /// <param name="roundTime">The new round time in seconds</param>
    public void SetRoundTime(string roundTime)
    {
        this.world.roundTimeSec = int.Parse(roundTime);
    }

    /// <summary>
    /// Set the maximum number of players for the world
    /// </summary>
    /// <param name="maxPlayers">The new max number of players</param>
    public void SetMaxPlayers(string maxPlayers)
    {
        this.world.nbMaxPlayer = int.Parse(maxPlayers);
    }

    /// <summary>
    /// Set the maximum number of monsters for the world
    /// </summary>
    /// <param name="maxMonsters">The new max number of monsters</param>
    public void SetMaxMonsters(string maxMonsters)
    {
        this.world.nbMaxMonsters = int.Parse(maxMonsters);
    }

    /// <summary>
    /// Set the number of shops for the world
    /// </summary>
    /// <param name="nbShops">The new number of shops</param>
    public void SetNbShops(string nbShops)
    {
        this.world.nbShops = int.Parse(nbShops);
    }
}