using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnlineUsersManager : MonoBehaviour
{
	private GameObject userListItemPrefab; // This is our prefab object that will be exposed in the inspector
	public GameObject userContainer;

	private List<GameObject> userGameObjectList;

    private void Awake()
    {
		userListItemPrefab = (GameObject)Resources.Load("UserListItem");
		userGameObjectList = new List<GameObject>();
	}

    private void Start()
    {	
		// Populate();
	}

    /// <summary>
    /// Delete the actual user list and add the new one
    /// </summary>
    /// <param name="users"></param>
    public void SetUserList(List<User> users)
    {

		//Destroy all users on the screen
		if (this.userGameObjectList.Count != 0)
		{
			foreach (GameObject obj in this.userGameObjectList)
			{
				Destroy(obj);
			}
		}

		//add the new user list on the screen
		addUsers(users);
	}

	/// <summary>
	/// Add the new list of users to the actual one
	/// </summary>
	/// <param name="users"></param>
	public void addUsers(List<User> users)
    {
		//add the new user list on the screen
		foreach (User user in users)
		{
			addUser(user);
		}
	}

	/// <summary>
	/// Add only one user to the actual list
	/// </summary>
	/// <param name="user"></param>
	public void addUser(User user)
    {
		GameObject newObj;

		// Create new instances of our prefab in the screen container (named 'content')
		newObj = (GameObject)Instantiate(userListItemPrefab, userContainer.transform);

		//Add this new GameObject in the list to delete it later if needed
		this.userGameObjectList.Add(newObj);

		//add the user to the gameObject to show its info. on the screen
		newObj.GetComponent<UserListItemManager>().SetUserToGameObject(user);
	}

	/// <summary>
	/// Only for Test purpose
	/// </summary>
	private void Populate()
	{
		GameObject newObj; // Create GameObject instance

		if (this.userGameObjectList.Count != 0)
        {
			foreach (GameObject obj in this.userGameObjectList){
				Destroy(obj);
            }
        }

		for (int i = 0; i < 15; i++)
		{
			// Create new instances of our prefab until we've created as many as we specified
			newObj = (GameObject)Instantiate(userListItemPrefab, userContainer.transform);

			//Add this new GameObject in the list to delete it later if needed
			this.userGameObjectList.Add(newObj);

			// Randomize the color of our image
			newObj.GetComponentInChildren<UserListItemManager>().SetRandomInfoToGameObject();
		}

	}
}
