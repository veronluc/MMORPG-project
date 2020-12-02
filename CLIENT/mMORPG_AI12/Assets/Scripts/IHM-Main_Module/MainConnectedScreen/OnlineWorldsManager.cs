using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineWorldsManager : MonoBehaviour
{
	private GameObject worldListItemPrefab; // This is our prefab object that will be exposed in the inspector
	public GameObject worldContainer;

	private List<GameObject> worldGameObjectList;

	public GameObject playerChoicePopup;

	private void Awake()
	{
		worldListItemPrefab = (GameObject)Resources.Load("WorldListItem");
		worldGameObjectList = new List<GameObject>();
	}

	private void Start()
	{
		if (playerChoicePopup == null)
		{
			Debug.LogError("IHMMain Module - WorldListItemManager : This script could not find the playerChoicePopup GameObject");
		}
		//Populate();
	}

	/// <summary>
	/// Delete the actual world list and add the new one
	/// </summary>
	/// <param name="worlds"></param>
	public void SetWorldList(List<World> worlds)
	{

		//Destroy all worlds on the screen
		if (this.worldGameObjectList.Count != 0)
		{
			foreach (GameObject obj in this.worldGameObjectList)
			{
				Destroy(obj);
			}
		}

		//add the new user list on the screen
		AddWorlds(worlds);
	}

	/// <summary>
	/// Add the new list of worlds to the actual one
	/// </summary>
	/// <param name="worlds"></param>
	public void AddWorlds(List<World> worlds)
	{
		//add the new user list on the screen
		foreach (World world in worlds)
		{
			AddWorld(world);
		}
	}

	/// <summary>
	/// Add only one world to the actual list
	/// </summary>
	/// <param name="world"></param>
	public void AddWorld(World world)
	{
		GameObject newObj;

		// Create new instances of our prefab in the screen container (named 'content')
		newObj = (GameObject)Instantiate(worldListItemPrefab, worldContainer.transform);

		//Add this new GameObject in the list to delete it later if needed
		this.worldGameObjectList.Add(newObj);

		//add the user to the gameObject to show its info. on the screen
		newObj.GetComponent<WorldListItemManager>().SetWorldToGameObject(world, this);
	}

	/// <summary>
	/// Only for Test purpose
	/// </summary>
	private void Populate()
	{
		GameObject newObj; // Create GameObject instance

		//Destroy all worlds on the screen
		if (this.worldGameObjectList.Count != 0)
		{
			foreach (GameObject obj in this.worldGameObjectList)
			{
				Destroy(obj);
			}
		}

		for (int i = 0; i < 15; i++)
		{
			// Create new instances of our prefab in the screen container (named 'content')
			newObj = (GameObject)Instantiate(worldListItemPrefab, worldContainer.transform);

			//Add this new GameObject in the list to delete it later if needed
			this.worldGameObjectList.Add(newObj);

			// Randomize the color of our image
			newObj.GetComponentInChildren<WorldListItemManager>().SetRandomInfoToGameObject(this);
		}

	}
}
