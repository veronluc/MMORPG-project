using AI12_DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldListItemManager : MonoBehaviour
{
    private float smoothTime;
    private Vector2 velocityV2;
    private Vector3 velocityV3;
    private Vector2 mainSizeTarget;
    private Vector3 detailsScale;
    private Boolean isReduced;

    public GameObject details;

    public TextMeshProUGUI worldName;
    public TextMeshProUGUI ownerName;
    public TextMeshProUGUI worldSize;
    public TextMeshProUGUI worldType;
    public TextMeshProUGUI worldTurnTime;
    public Button joinButton;

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
    public void OnClickOnWorldInfo()
    {
        //Debug.Log("CLICK");
        Vector2 sizeGrow = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 289);
        Vector2 sizeShrink = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 80);
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
    /// Set the world info. to this gameObject (to show it on the screen)
    /// </summary>
    /// <param name="world"> the world you want to connect to this item</param>
    /// <param name="worldsManager">the worlds manager useful to get the popup to choose the payer the user want to play with</param>
    public void SetWorldToGameObject(World world, OnlineWorldsManager worldsManager)
    {
        this.worldName.text = world.name;

        this.ownerName.text = world.creator.login;

        this.worldSize.text = world.sizeMap.ToString();

        this.worldType.text = world.gameMode.ToString().ToUpper();

        this.worldTurnTime.text = world.roundTimeSec.ToString() + "s";

        this.joinButton.onClick.AddListener(() => worldsManager.playerChoicePopup.GetComponent<WorldJoinManager>().OpenPopupForCurrentWorld(world));
        
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    public void SetRandomInfoToGameObject(OnlineWorldsManager worldsManager)
    {
        World world = new World(UnityEngine.Random.value.ToString(), 0, GameMode.pvp, true, 2, 30, 10, 42, 5, false, true, true, false, true, true, true, true, null);

        world.id = "TestID";

        this.worldName.text = world.name;

        this.ownerName.text = "OUI";

        this.worldSize.text = world.sizeMap.ToString();

        this.worldType.text = world.gameMode.ToString().ToUpper();

        this.worldTurnTime.text = world.roundTimeSec.ToString() + "s";

        this.joinButton.onClick.AddListener(() => worldsManager.playerChoicePopup.GetComponent<WorldJoinManager>().OpenPopupForCurrentWorld(world));
    }

   
}
