using System.Collections.Generic;
using AI12_DataObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserWorldItemManager : MonoBehaviour
{
    private List<string> sizeLabels = new List<string>() {"SMALL", "MEDIUM", "LARGE"};
    public TextMeshProUGUI worldName;
    public TextMeshProUGUI worldSize;
    public TextMeshProUGUI worldType;
    public Button detailsButton;

    void Start()
    {
    }

    /// <summary>
    /// Set some world info. to this gameObject (to show it on the screen)
    /// </summary>
    /// <param name="world">The world that will be displayed in this gameObject</param>
    public void SetWorldInfoToGameObject(World world, WorldDetailsManager worldDetailsManager)
    {
        this.worldName.text = world.name;

        this.worldSize.text = sizeLabels[world.sizeMap]; // Retrieve the label corresponding to the index number given

        this.worldType.text = world.gameMode.ToString().ToUpper();

        this.detailsButton.onClick.AddListener(() =>
            worldDetailsManager.SetWorldDetails(world));
    }

    /// <summary>
    /// Only for Test purpose
    /// </summary>
    public void SetRandomInfoToGameObject(WorldDetailsManager worldDetailsManager)
    {
        World world = new World(UnityEngine.Random.value.ToString(), 0, GameMode.pvp, true, 2, 30, 10, 42, 5, false,
            true, true, false, true, true, true, true, null);
        world.id = "TestID";

        this.worldName.text = world.name;

        this.worldSize.text = sizeLabels[world.sizeMap];

        this.worldType.text = world.gameMode.ToString().ToUpper();

        this.detailsButton.onClick.AddListener(() =>
            worldDetailsManager.SetWorldDetails(world));
    }
}