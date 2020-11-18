using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserListItemManager : MonoBehaviour
{
    private float smoothTime;
    private Vector2 velocityV2;
    private Vector3 velocityV3;
    private Vector2 mainSizeTarget;
    private Vector3 detailsScale;
    private Boolean isReduced;

    private GameObject characterListItemPrefab;
    public GameObject details;

    public Image image;
    public TextMeshProUGUI userName;
    public TextMeshProUGUI realName;
    public TextMeshProUGUI birthDate;
    public GameObject characterContainer;

    private void Awake()
    {
        characterListItemPrefab = (GameObject)Resources.Load("CharacterListItem");
    }


    void Start()
    {
        details.SetActive(false);
        details.GetComponent<RectTransform>().localScale = Vector3.zero;
        smoothTime = 0.3F;
        velocityV2 = Vector2.zero;
        velocityV3 = Vector3.zero;
        mainSizeTarget = GetComponent<RectTransform>().sizeDelta;
        detailsScale = details.GetComponent<RectTransform>().localScale;
        isReduced = true;
    }

    void Update()
    {
        GetComponent<RectTransform>().sizeDelta = Vector2.SmoothDamp(GetComponent<RectTransform>().sizeDelta, mainSizeTarget, ref velocityV2, smoothTime);
        details.GetComponent<RectTransform>().localScale = Vector3.SmoothDamp(details.GetComponent<RectTransform>().localScale, detailsScale, ref velocityV3, smoothTime);
    }

    /// <summary>
    /// Expand the User section and show the details
    /// </summary>
    public void OnClickOnUserInfo()
    {
        //Debug.Log("CLICK");
        Vector2 sizeGrow = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 289);
        Vector2 sizeShrink = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 41);
        Vector2 scaleGrow = Vector3.one;
        Vector2 scaleShrink = Vector3.zero;
        if (isReduced)
        {
            //StartCoroutine(ShowHideInformation(sizeGrow, scaleGrow, true));
            mainSizeTarget = sizeGrow;
            details.SetActive(true);
            detailsScale = scaleGrow;
        }
        else
        {
            //StartCoroutine(ShowHideInformation(sizeShrink, scaleShrink, false));
            mainSizeTarget = sizeShrink;
            detailsScale = scaleShrink;
            details.SetActive(false);
        }
        isReduced = !isReduced;
    }
    
    IEnumerator ShowHideInformation(Vector2 size, Vector3 scale, Boolean isActivate)
    {
        mainSizeTarget = size;
        detailsScale = scale;
        if (details.activeSelf == true)
        {
            yield return new WaitUntil(() => details.GetComponent<RectTransform>().localScale.x <= 0.3);
        }
        details.SetActive(isActivate);
    }

    /// <summary>
    /// Set the user info. to this gameObject (to show it on the screen)
    /// </summary>
    /// <param name="user"></param>
    public void SetUserToGameObject(User user)
    {
        
        this.image.color = Color.black;

        this.userName.text = user.login;

        this.realName.text = user.firstName + " " + user.lastName;

        this.birthDate.text = user.birthDate.ToString();

        //CREATE THE LIST OF CHARACTER ITEMS

        GameObject newObj;

        foreach(Player player in user.players)
        {
            // Create new instances of our prefab
            newObj = (GameObject)Instantiate(characterListItemPrefab, characterContainer.transform);

            // Call a method of the new gameObject to give it the player info.
            newObj.GetComponentInChildren<CharacterListItemManager>().SetPlayerToGameObject(player);
        }
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    public void SetRandomInfoToGameObject()
    {
        this.image.color = Color.black;

        this.userName.text = "cocou";

        this.realName.text = "Je suis ton père";

        this.birthDate.text = "22/08/1902";

        //CREATE THE LIST OF CHARACTER ITEMS

        GameObject newObj;

        for (int i=0; i<10; i++)
        {
            // Create new instances of our prefab
            newObj = (GameObject)Instantiate(characterListItemPrefab, characterContainer.transform);

            //Add this new GameObject in the list to delete it later if needed
            //this.userGameObjectList.Add(newObj);
            //NOT NEEDED FOR NOW

            // Call a method to give info to the Character
            newObj.GetComponentInChildren<CharacterListItemManager>().SetRandomInfoToGameObject();
        }
    }
}
