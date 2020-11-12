using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TESTShowOnlineUserCharacters : MonoBehaviour
{
	private GameObject prefab; // This is our prefab object that will be exposed in the inspector

	private List<GameObject> characterGameObjectList;

	private void Start()
	{
		characterGameObjectList = new List<GameObject>();
		prefab = (GameObject)Resources.Load("CharacterListItem");
		Populate();
	}

	public void Populate()
	{
		GameObject newObj; // Create GameObject instance

		if (this.characterGameObjectList.Count != 0)
		{
			foreach (GameObject obj in this.characterGameObjectList)
			{
				Destroy(obj);
			}
		}

		for (int i = 0; i < 5; i++)
		{
			// Create new instances of our prefab until we've created as many as we specified
			newObj = (GameObject)Instantiate(prefab, transform);

			//Add this new GameObject in the list to delete it later if needed
			this.characterGameObjectList.Add(newObj);

			// Randomize the color of our image
			newObj.GetComponentInChildren<TextMeshProUGUI>().text = "" + Random.value;
		}

	}
}
