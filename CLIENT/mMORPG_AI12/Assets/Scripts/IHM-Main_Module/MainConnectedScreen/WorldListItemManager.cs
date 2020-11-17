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

        this.ownerName.text = world.creator.login;

        this.worldSize.text = world.sizeMap.ToString();

        this.worldType.text = world.gameMode.ToString();

        this.worldTurnTime.text = world.roundTimeSec.ToString() + "s";

        // TO MODIFY (v2) : replace those lines with the user's chosen player (via choose player Popup) when the connection will be implemented
        this.joinButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .JoinWorld(TestCreatePlayer(),world.id));
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
        
        this.joinButton.onClick.AddListener(() => GameObject.FindGameObjectWithTag("IHMMainModule").GetComponent<MainConnectedScreen>()
            .JoinWorld(TestCreatePlayer(),this.worldName.text));
    }

    /// <summary>
    /// Only for test purpose
    /// </summary>
    /// <returns>a player</returns>
    private Player TestCreatePlayer()
    {
        // TO MODIFY (v2) : replace those lines with the user's chosen player (via choose player Popup) when the connection will be implemented
        Player player = new Player();
        player.gold = 0;
        player.xp = 0;
        player.name = "JOUEUR1";
        player.level = 0;
        player.vitalityMax = 100;
        player.vitality = 100;
        player.manaMax = 100;
        player.mana = 100;
        player.strength = 25;
        player.intelligence = 20;
        player.defense = 12;
        player.pM = 8;
        player.location = new Location(0, 0);
        player.entityClass = new EntityClass();
        player.entityClass.name = "GUERRIER";
        player.entityClass.baseVitality = 100;
        player.entityClass.baseMana = 100;
        player.entityClass.baseStrength = 25;
        player.entityClass.baseIntelligence = 2;
        player.entityClass.baseDefense = 12;
        player.entityClass.basePM = 8;
        player.entityClass.exclusive = Entities.player;
        player.entityClass.skills = new List<Skill>();
        Skill skill = new Skill();
        skill.zone = 2;
        skill.damagePoints = 4;
        skill.costMana = 2;
        skill.range = new Range();
        skill.range.shape = shapes.star;
        player.entityClass.skills.Add(skill);
        User user = new User();
        user.login = "Jean Né marre";
        user.password = "Des classes sans constructeur";
        user.firstName = "Créer un player prend";
        user.lastName = "41 lignes...";
        user.birthDate = new DateTime(2020, 11, 16);
        user.imageRef = "/C/vide";
        user.players = new List<Player>();
        user.players.Add(player);
        player.user = user;
        return player;
    }
}
