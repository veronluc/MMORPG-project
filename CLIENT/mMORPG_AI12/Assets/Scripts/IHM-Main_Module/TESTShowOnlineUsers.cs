using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TESTShowOnlineUsers : MonoBehaviour
{
	private GameObject prefab; // This is our prefab object that will be exposed in the inspector

	private List<GameObject> userGameObjectList;

    private void Start()
    {
		userGameObjectList = new List<GameObject>();
		prefab = (GameObject)Resources.Load("UserListItem");
		Populate();
    }

    public void Populate()
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
			newObj = (GameObject)Instantiate(prefab, transform);

			//Add this new GameObject in the list to delete it later if needed
			this.userGameObjectList.Add(newObj);

			// Randomize the color of our image
			newObj.GetComponentInChildren<TextMeshProUGUI>().text = "" + Random.value;
		}

	}
}
