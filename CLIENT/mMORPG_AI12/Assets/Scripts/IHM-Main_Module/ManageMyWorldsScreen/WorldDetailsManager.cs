using AI12_DataObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldDetailsManager : MonoBehaviour
{
    private string name;
    public TMP_InputField nameInput;
    private int size;
    public GameObject sizeInput;
    private GameMode gameTypeMode;
    public GameObject gameTypeModeInput;
    private int difficulty;
    public GameObject difficultyInput;
    private int roundTimeSec;
    public GameObject timeInput;
    private bool realDeath;
    public GameObject realDeathInput;
    private int nbMaxPlayers;
    public GameObject nbPlayersInput;
    private int nbMaxMonsters;
    public GameObject nbMonstersInput;
    private int nbShops;
    public GameObject nbShopsInput;

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
        this.name = "";
        this.size = 0;
        this.gameTypeMode = GameMode.pvp;
        this.difficulty = 0;
        this.roundTimeSec = 0;
        this.realDeath = false;
        this.nbMaxPlayers = 0;
        this.nbMaxMonsters = 0;
        this.nbShops = 0;
        this.hasCity = false;
        this.hasPlain = false;
        this.hasSwamp = false;
        this.hasRiver = false;
        this.hasForest = false;
        this.hasRockyPlain = false;
        this.hasMountain = false;
        this.hasSea = false;
    }

    /// <summary>
    /// Display a new default world
    /// </summary>
    public void CreateNewWorld()
    {
        // TODO : add new gameobject in UserWorldsManager
        // TODO : create default world values
        // TODO : call setWorldDetails with the default world created
    }

    /// <summary>
    /// Active the gameobject and set all the values to display the world information
    /// </summary>
    /// <param name="world">The world that contains information to display in the screen</param>
    public void SetWorldDetails(World world)
    {
        // Active the container that will display the world information
        this.gameObject.SetActive(true);
        SetName(world.name);
    }

    /// <summary>
    /// Set the name of the world and the name input value to display
    /// </summary>
    /// <param name="name">The new name of the world</param>
    public void SetName(string name)
    {
        this.name = name;
        this.nameInput.text = name;
    }

    /// <summary>
    /// Handle the change of the name input value
    /// </summary>
    /// <param name="name">New entered name to save</param>
    public void HandleChangeName(string name)
    {
        this.name = name;
    }

    /// <summary>
    /// Called when the user clicks on the "DELETE" button
    /// </summary>
    public void OnClickDeleteWorld()
    {
        // TODO
    }


    /// <summary>
    /// Called when the user clicks on the "CREATE" button
    /// </summary>
    public void OnClickSaveWorld()
    {
        GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<ManageMyWorldsScreen>()
            .CreateWorld(name, size, gameTypeMode, realDeath, difficulty, roundTimeSec, nbMaxPlayers, nbMaxMonsters,
                nbShops, hasCity, hasPlain, hasSwamp, hasRiver, hasForest, hasRockyPlain, hasMountain, hasSea);
    }
    
}