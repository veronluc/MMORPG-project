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
    private Boolean reduced;

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
        reduced = true;
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
        if (reduced)
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
        reduced = !reduced;
    }

    IEnumerator ShowHideInformation(Vector2 size, Vector3 scale, Boolean activate)
    {
        mainSizeTarget = size;
        detailsScale = scale;
        if (details.activeSelf == true)
        {
            yield return new WaitUntil(() => details.GetComponent<RectTransform>().localScale.x <= 0.3);
        }
        details.SetActive(activate);
    }

    /// <summary>
    /// Set the world info. to this gameObject (to show it on the screen)
    /// </summary>
    /// <param name="world"></param>
    public void SetWorldToGameObject(World world)
    {
        this.worldName.text = world.name;

        this.ownerName.text = world.creator.name;

        this.worldSize.text = world.sizeMap.ToString();

        this.worldType.text = world.gamemode.ToString();

        this.worldTurnTime.text = world.roundTimeSec.ToString() + "s";

        //this.joinButton.onClick = GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>().JoinWorld(/*idWorld*/)
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    public void SetRandomInfoToGameObject()
    {
        this.worldName.text = "Le nom du monde";

        this.ownerName.text = "MOI";

        this.worldSize.text = "MEDIUM";

        this.worldType.text = "PVE";

        int time = 18;

        this.worldTurnTime.text = time.ToString() + "s";
    }
}
