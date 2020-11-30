using System.Collections.Generic;
using UnityEngine;
using AI12_DataObjects;
using UnityEngine.UI;

public class UserWorldsManager : MonoBehaviour
{
    private GameObject userWorldsListItemPrefab;
    public GameObject userWorldsContainer;
    public GameObject worldDetailsContainer;
    public Button createNewWorldButton;
    public Button backButton;

    private List<GameObject> userWorldsGameObjectList;
    // TODO : get the 2 buttons back and create new world (+ add function to create new world with default values)

    private void Awake()
    {
        userWorldsListItemPrefab = (GameObject) Resources.Load("UserWorldListItem");
        userWorldsGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        Populate(); // TODO : delete when connection is done with scripts
    }

    /// <summary>
    /// Delete the actual user worlds list and add a new one
    /// </summary>
    /// <param name="userWorlds">List of worlds that belongs to the user</param>
    public void SetUserWorldsList(List<World> userWorlds)
    {
        // Destroy all worlds on the screen
        if (this.userWorldsGameObjectList.Count != 0)
        {
            foreach (GameObject obj in this.userWorldsGameObjectList)
            {
                Destroy(obj);
            }
        }

        // Add each world of the new worlds list on the screen
        foreach (World world in userWorlds)
        {
            AddUserWorld(world);
        }
    }

    /// <summary>
    /// Add one world to the actual list
    /// </summary>
    /// <param name="world">The world that we want to add in the list displayed</param>
    public void AddUserWorld(World world)
    {
        GameObject newObj;

        // Create new instance of our prefab in the screen container (named 'Content')
        newObj = (GameObject) Instantiate(userWorldsListItemPrefab, userWorldsContainer.transform);

        // Add this new GameObject in the list to delete it later if needed
        this.userWorldsGameObjectList.Add(newObj);

        // Add the world to the gameObject to show its info. on the screen
        newObj.GetComponent<UserWorldItemManager>()
            .SetWorldInfoToGameObject(world, worldDetailsContainer.GetComponent<WorldDetailsManager>());
    }

    /// <summary>
    /// Called when the user clicks on the "NEW WORLD" button
    /// </summary>
    public void OnClickCreateNewWorld()
    {
        worldDetailsContainer.GetComponent<WorldDetailsManager>().CreateNewWorld();
    }

    /// <summary>
    /// Called when the user clicks on the "BACK" button
    /// </summary>
    public void OnClickBackButton()
    {
        // TODO : change screen for manageMyWorldsScreen
    }

    /// <summary>
    /// Only for Test purpose
    /// </summary>
    private void Populate()
    {
        GameObject newObj; // Create GameObject instance

        if (this.userWorldsGameObjectList.Count != 0)
        {
            foreach (GameObject obj in this.userWorldsGameObjectList)
            {
                Destroy(obj);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject) Instantiate(userWorldsListItemPrefab, userWorldsContainer.transform);

            //Add this new GameObject in the list to delete it later if needed
            this.userWorldsGameObjectList.Add(newObj);

            // Randomize the color of our image
            newObj.GetComponentInChildren<UserWorldItemManager>()
                .SetRandomInfoToGameObject(worldDetailsContainer.GetComponent<WorldDetailsManager>());
        }
    }
}