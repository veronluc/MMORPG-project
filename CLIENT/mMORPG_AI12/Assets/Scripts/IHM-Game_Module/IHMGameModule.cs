﻿using System;
using System.Collections.Generic;
using System.Linq;
using AI12_DataObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Action = AI12_DataObjects.Action;

public class IHMGameModule : MonoBehaviour
{
    
    public DataInterfaceForIHMGame dataInterface { get; set; }
    public IHMGameInterfaceImpl ihmGameInterface { get; set; }
    public Player player { get; set; }
    public Player currentPlayer { get; set; }
    public World world { get; set; }
    public User user { get; set; }
    // GameManager to manage chat messages
    public GameManager gameManager { get; set; }

    // Helps to know if a skill is being used
    public Skill currentSkill { get; set; }
    // placement des joueurs sur la map
    public GameEntity gamePlayer { get; set; }
    public MovePlate movePlate { get; set; }

    public GameObject targetedEntity { get; set; }

    //public world
    private void Awake()
    {
        ihmGameInterface = new IHMGameInterfaceImpl();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IHMGame")
        {
            gameManager = gameObject.GetComponent<GameManager>();
            ihmGameInterface.gameManager = gameManager;
            // récupération des attributs et méthodes de GameEntity
            //gamePlayer = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameEntity>();
            // récupération des attributs et méthodes de ihmGameModule
            movePlate = GetComponent<MovePlate>();
        }
    }

    private void Start()
    {
        //A DEGAGER LORS DE L'INTEG
        // Create a User for tests
        user = new User("test1", "te0000st", "DorianTest", "ZielinskiTest", DateTime.Now);
        // Create a GameState for tests
        Tile[,] map = new Tile[25, 25];
        map[0, 0] = new TilePlain("0", null, "grass");
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                Location tempLoc = new Location(i, j);
                map[i, j] = new TilePlain(i + "" + j, tempLoc, "grass");
            }
        }
        // Create a World for tests
        world = new World("testWorld", 25, GameMode.pvp, false, 0, 60, 5, 20, 0, true, true, true, true, true, true, true, true, this.user);
        // Create a Player for 
        Skill skill = new Skill("Attaque", 1, 3, 0, false);
        Skill skill2 = new Skill("Defense", 2, 3, 0, false);
        Skill skill3 = new Skill("Bouclier", 4, 3, 0, false);
        List<Skill> skills = new List<Skill>(); skills.Add(skill);
        skills.Add(skill2);
        skills.Add(skill3);
        EntityClass entityClass = new EntityClass("warrior", 25, 10, 3, 3, 3, 3, Entities.player, skills);
        Location location = new Location(10, 10);
        player = new Player(PlayerType.Warrior, "TestName", location, this.user);
        Player player2 = new Player(PlayerType.Warrior, "TestName2", location, this.user);
        List<Entity> entities = new List<Entity>();
        entities.Add(player);
        entities.Add(player2);
        world.gameState = new GameState(0, 0, entities, map);

        ihmGameInterface.LaunchGame(user, world, player);
    }

    public Player GetNextPlayer()
    {
        //Il faudra check que c'est pas un monstre --> voir avec data
        return (Player)world.gameState.nextEntity();
    }

    public void clickOnSkill(string skillName)  // Il vaudrait mieux faire les actions de cette fonction dans la méthode ViewSkill Distance de GameEntity
    {
        if (currentPlayer.name == player.name)
        {
            currentSkill = player.entityClass.skills.Where(skill => skill.name == skillName).ToList().First();
            //Afficher sur la carte la distance d’attaque de l’utilisateur
            gamePlayer.ViewSkillDistance(currentSkill);  // mettre en parametre le skill et modifier la méthode ViewSkillDistance() ; pas sûr que ça compile
            //Avoir un objet qui enregistre la skill en cours (objet A)   
        }
    }
    
    public void clickOnPlayer()  
    {
        if (currentPlayer.name == player.name)
        {
            gamePlayer.ViewMoveDistance();  
        }
    }
    
    
    public void ClickOnCase() {  // Il vaudrait mieux faire les actions de cette fonction dans la méthode OnMouseUp de MovePlate.cs

        // Récupérer la case qui a été cliquée : c'est ce qui est fait dans la fonction OnMouseUp (exemple dans MovePlate.cs)
        int caseX = movePlate.reference.GetComponent<GameEntity>().GetXBoard(); // pas sûr que ça compile
        int caseY = movePlate.reference.GetComponent<GameEntity>().GetYBoard(); // pas sûr que ça compile
    }

    public void handleEndOfTurn() {  // à faire dans le OnMouseUp de MovePlate.cs (la fin du tour c'est après avoir fait une action ou un déplacement
        Action action = new ActionEndRound(player, world);
        dataInterface.MakeAction(action);
    }

    public void ExecuteAction(Action action)  // à faire dans le if (action) de OnMouseUp de MovePlate.cs
    {
        switch (action)
        {
            case ActionMove _:
                ExecuteMoveAction(action);
                break;
            case ActionRest _:
                ExecuteRestAction(action);
                break;
            case ActionSkill _:
                ExecuteSkillAction(action);
                break;
        }
    }

    public void ExecuteSkillAction(Action action) {
        // Récupérer le player qui correspond à celui mentionné dans l’action
        //     Récupérer la ou les tiles qui sont visées par l’action
        //     Récupérer le ou les entités qui sont sur les tiles récupérées
        // Calculer les dommages reçu pour chaque entités
    }

    public void ExecuteMoveAction(Action action) {
        // Récupérer le player qui correspond à celui mentionné dans l’action
        //     Changer sa position avec les nouvelles qui sont dans l’action
    }
    
    public void ExecuteRestAction(Action action) {
        
    }

    
}
