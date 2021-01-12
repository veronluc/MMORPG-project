using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI12_DataObjects
{
    public enum PlayerType
    {
        Warrior,
        Rogue,
        Priest,
        Mage
    }

    // [Serializable()]
    public class Player : Entity
    {
        public int gold { get; set; }
        public int xp { get; set; }
        public User user { get; set; }
        public PlayerType playerType { get; set; }

        public Player(PlayerType playerType, string name, Location location, User user)
        {
            this.name = name;
            this.location = location;
            this.user = user;
            this.playerType = playerType;
            id = Guid.NewGuid().ToString();
            gold = 0;
            xp = 0;
            level = 1;
            switch (playerType)
            {
                case PlayerType.Warrior:
                    vitality = 5;
                    vitalityMax = 5;
                    strength = 3;
                    intelligence = 0;
                    defense = 4;
                    mana = 4;
                    manaMax = 4;
                    PM = 3;
                    entityClass = new EntityClass(
                        "Warrior", // Name
                        5, // baseVitality
                        4, // baseMana,
                        3, // baseStrength
                        0, // baseIntelligence
                        4, // baseDefense
                        3, // basePM
                        Entities.player,
                        new List<Skill>() {
                                new Skill(
                                    "Hand-to-hand attack",
                                    1, // Zone
                                    1 + 3, // Att Damage (1 + strength)
                                    0, //Mana
                                    false //Healing
                                ),
                                new Skill(
                                    "Heavy attack",
                                    1, // Zone //TODO mettre adjacentes
                                    3 + 3, // Att Damage (3 + strength)
                                    2, //Mana
                                    false //Healing
                                )
                                //TODO Lever bouclier ?
                            }
                        );
                    break;
                case PlayerType.Mage:
                    vitality = 5;
                    vitalityMax = 5;
                    strength = 0;
                    intelligence = 4;
                    defense = 2;
                    mana = 5;
                    manaMax = 5;
                    PM = 2;
                    entityClass = new EntityClass(
                        "Mage", // Name
                        5, // baseVitality
                        5, // baseMana,
                        0, // baseStrength
                        4, // baseIntelligence
                        2, // baseDefense
                        2, // basePM
                        Entities.player,
                        new List<Skill>() {
                                new Skill(
                                    "Remote spell",
                                    3, // Zone
                                    1 + 4, // Att Damage (1 + strength)
                                    0, //Mana
                                    false //Healing
                                ),
                                new Skill(
                                    "Fireball",
                                    3, // Zone //TODO mettre adjacentes
                                    2 + 4, // Att Damage (3 + strength)
                                    2, //Mana
                                    false //Healing
                                ),
                                new Skill(
                                    "Frost",
                                    1, // Zone //TODO mettre adjacentes
                                    2 + 4, // Att Damage (3 + strength)
                                    2, //Mana
                                    false //Healing
                                )
                                //TODO Lever bouclier ?
                            }
                        );
                    break;
                case PlayerType.Priest:
                    vitality = 5;
                    vitalityMax = 5;
                    strength = 1;
                    intelligence = 3;
                    defense = 2;
                    mana = 5;
                    manaMax = 5;
                    PM = 2;
                    entityClass = new EntityClass(
                        "Priest", // Name
                        5, // baseVitality
                        5, // baseMana,
                        1, // baseStrength
                        3, // baseIntelligence
                        2, // baseDefense
                        2, // basePM
                        Entities.player,
                        new List<Skill>() {
                                new Skill(
                                    "Hand-to-hand attack",
                                    1, // Zone
                                    1 + 4, // Att Damage (1 + strength)
                                    0, //Mana
                                    false //Healing
                                ),
                                new Skill(
                                    "Simple care",
                                    1, // Zone //TODO mettre adjacentes
                                    2 + 4, // Att Damage (3 + strength)
                                    2, //Mana
                                    true //Healing
                                ),
                                new Skill(
                                    "Complex care",
                                    1, // Zone //TODO mettre adjacentes
                                    2 + 4, // Att Damage (3 + strength)
                                    3, //Mana
                                    true //Healing
                                )
                                //TODO Lever bouclier ?
                            }
                        );
                    break;
                default:
                    vitality = 5;
                    vitalityMax = 5;
                    strength = 2;
                    intelligence = 1;
                    defense = 4;
                    mana = 4;
                    manaMax = 4;
                    PM = 3;
                    entityClass = new EntityClass(
                        "Rogue", // Name
                        5, // baseVitality
                        4, // baseMana,
                        2, // baseStrength
                        1, // baseIntelligence
                        4, // baseDefense
                        3, // basePM
                        Entities.player,
                        new List<Skill>() {
                                new Skill(
                                    "Hand-to-hand attack",
                                    1, // Zone
                                    1 + 2, // Att Damage (1 + strength)
                                    0, //Mana
                                    false //Healing
                                ),
                                new Skill(
                                    "Knife throw",
                                    2, // Zone //TODO mettre adjacentes
                                    2 + 2, // Att Damage (3 + strength)
                                    2, //Mana
                                    false //Healing
                                )
                                //TODO Lever bouclier ?
                            }
                        );
                    break;
            }
        }

        public override bool isMonster()
        {
            return false;
        }

        public static Player GenerateRandomPlayer(User user)
        {
            System.Random r = new System.Random();

            // List of names
            string[] names = new string[] {
                "Dominique",
                "Marie-Hélène",
                "Valérie",
                "Ahmed",
                "Aziz",
                "Benjamin",
                "Philipe",
                "Manuel",
                "Karine",
                "Jennifer",
                "Benoît",
                "Frédéric",
                "Antoine",
                "Sylvain"
            };

            PlayerType playerType;
            int randomIndex = r.Next(0, 4);
            switch (randomIndex)
            {
                case 0:
                    playerType = PlayerType.Mage;
                    break;
                case 1:
                    playerType = PlayerType.Priest;
                    break;
                case 2:
                    playerType = PlayerType.Rogue;
                    break;
                default:
                    playerType = PlayerType.Warrior;
                    break;
            }
            return new Player(playerType, names[r.Next(0, names.Length)], new Location(0, 0), user);
        }
    }
}