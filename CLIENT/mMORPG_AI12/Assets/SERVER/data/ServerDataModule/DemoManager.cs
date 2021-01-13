using AI12_DataObjects;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class DemoManager
{
    public List<Player> players { get; set; }
    public List<Monster> monsters { get; set; }
    public World world { get; set; }
    public ServerDataImplementation data;

    public DemoManager(ServerDataImplementation data)
    {
        // Init ServerDataImplementation
        this.data = data;
        
        // Create Players
        this.players = new List<Player>();
        players.Add(new Player(PlayerType.Warrior, "William", new Location(1, 1), null));
        players.Add(new Player(PlayerType.Mage, "Mira", new Location(1, 3), null));
        players.Add(new Player(PlayerType.Priest, "Peter", new Location(0, 2), null));

        // Create Monsters
        this.monsters = new List<Monster>();
        monsters.Add(Monster.GetMonsterFromType(MonsterTypes.Goblin, "Crapok",
            new Location(7, 6)));
        monsters.Add(Monster.GetMonsterFromType(MonsterTypes.Sorcerer, "Magistrax",
            new Location(8, 8)));

        // Create world shell
        this.world = new World("CandyLand", 10);
        this.world.players = this.players;
        this.world.monstersList = this.monsters;

        // Create gamestate
        this.world.gameState = WorldManager.GenerateGameState(this.world);
    }

    public void Start()
    {
        this.PrintColorLine("STARTING GAME", ConsoleColor.Green);
        this.PrintGameState();
        this.GameLoop();
    }

    public void GameLoop()
    {
        String inputAction = "";
        while (inputAction != "exit")
        {
            if (this.world.gameState.currentEntityIsMonster())
            {
                this.PlayMonster();
                this.PrintGameState();
            }
            else
            {
                inputAction = this.PlayPlayer();
            }
        }

        this.PrintColorLine("Goodbye !", ConsoleColor.Blue);
    }

    public void PrintGameState()
    {
        this.PrintColorLine("----------\n" +
                            "GameState" +
                            "\n", ConsoleColor.Cyan);
        // Console.WriteLine(this.world.gameState);
        this.world.gameState.Print();
        this.world.gameState.turns.ForEach(delegate(Entity entity)
        {
            Console.WriteLine(entity);
        });
    }

    public void PrintCurrentEntity()
    {
        this.PrintColorLine(this.world.gameState.currentEntity().name + " is playing\n", ConsoleColor.Magenta);
    }

    public void PlayMonster()
    {
        Monster monsterToPlay = (Monster) this.world.gameState.currentEntity();
        this.PrintCurrentEntity();
        this.PrintColorLine("Press Enter to continue...", ConsoleColor.Yellow);
        String command = Console.ReadLine();
        if (command != "")
        {
            this.ConsoleCommand(command);
        }

        this.world.gameState = this.data.MakeMonsterTurn(this.world);
    }

    public String PlayPlayer()
    {
        Entity currentPlayer = this.world.gameState.currentEntity();

        String actionInput = "";
        while (actionInput != "end turn" && actionInput != "exit")
        {
            this.PrintCurrentEntity();
            this.PrintColorLine("Enter an action: [move | attack | end turn | exit]", ConsoleColor.Yellow);
            actionInput = "";
            while (actionInput != "end turn" && actionInput != "exit" && actionInput != "move" &&
                   actionInput != "attack")
            {
                actionInput = Console.ReadLine();
            }

            switch (actionInput)
            {
                case "move":
                    this.PlayerMove();
                    this.PrintGameState();
                    break;
                case "attack":
                    this.PlayerAttack();
                    PrintGameState();
                    break;
                case "end turn":
                    
                    GameState newGameState = new ActionEndRound(currentPlayer, this.world).makeAction();
                    if (newGameState != null)
                        this.world.gameState = newGameState;
                    this.PrintGameState();
                    break;
            }
        }

        return actionInput;
    }

    public void PlayerMove()
    {
        Entity currentPlayer = this.world.gameState.currentEntity();

        try
        {
            Console.WriteLine("Enter X location value: ");
            int X  = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y location value: ");
            int Y  = Int16.Parse(Console.ReadLine());
            GameState newGameState = new ActionMove(currentPlayer, this.world, this.world.gameState.map[X,Y]).makeAction();
            if (newGameState != null)
                this.world.gameState = newGameState;
        }
        catch (Exception e)
        {
            this.PrintColorLine("The entered location is wrong.", ConsoleColor.Red);
        }
    }

    public void PlayerAttack()
    {
        Entity currentPlayer = this.world.gameState.currentEntity();

        try
        {
            this.PrintSkills(currentPlayer);
            int skillIndex = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter X location value: ");
            int X  = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y location value: ");
            int Y  = Int16.Parse(Console.ReadLine());
            GameState newGameState = new ActionSkill(currentPlayer, this.world, this.world.gameState.map[X,Y], currentPlayer.entityClass.skills[skillIndex]).makeAction();
            if (newGameState != null)
                this.world.gameState = newGameState;
        }
        catch (Exception e)
        {
            this.PrintColorLine("The entered attack or location is wrong.", ConsoleColor.Red);
        }
    }

    public void PrintColorLine(String str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str, Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public void PrintColor(String str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(str, Console.ForegroundColor);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void PrintSkills(Entity entity)
    {
        this.PrintColorLine("Choose a skill to use: ", ConsoleColor.Yellow);
        int index = 0;
        entity.entityClass.skills.ForEach(delegate(Skill skill)
        {
            Console.WriteLine(index + ". " + skill);
            index++;
        });
    }

    public void ConsoleCommand(String str)
    {
        switch (str)
        {
            case "killall players":
                this.KillAllPlayers();
                break;
            default:
                this.PrintColorLine("Unknown command", ConsoleColor.Red);
                break;
        }
    }

    public void KillAllPlayers()
    {
        List<Entity> players = this.world.gameState.turns.Where(ent => !ent.isMonster()).ToList();
        players.ForEach(delegate(Entity player)
        {
            this.world.gameState.map[player.location.x, player.location.y].entities.Remove(player);
            this.world.gameState.turns.Remove(player);
        });
    }
}