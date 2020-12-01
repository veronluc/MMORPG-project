using System;
using System.Collections.Generic;

namespace AI12_DataObjects
{
    public enum MonsterTypes
    {
        Goblin,
        Sorcerer
    }

    [Serializable()]
    public class Monster : Entity
    {
        public int visionLength { get; set; }
        public int dropGold { get; set; }
        public int dropXp { get; set; }

        public Monster(string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass, int visionLength, int dropGold, int dropXp) : base(name, level, vitalityMax, vitality, manaMax, mana, strength, intelligence, defense, PM, location, entityClass)
        {
            this.visionLength = visionLength;
            this.dropGold = dropGold;
            this.dropXp = dropXp;
        }

        public static Monster GetMonsterFromType(MonsterTypes type, string name, Location location)
        {
            Random r = new Random();
            Monster m;
            switch(type)
            {
                case MonsterTypes.Goblin:
                    m = new Monster(
                        "Goblin " + name,
                        1, // level
                        5, // vitalityMax
                        5, // vitality
                        0, // manaMax
                        0, // mana
                        3, // strength
                        0, // intelligence
                        4, // defense
                        3, // PM
                        location,
                        new EntityClass(
                            "Goblin " + name,
                            5, //baseVitality
                            0, //baseMana
                            3, //baseStrength
                            0, //baseIntelligence
                            4, //baseDefense
                            3, //basePM
                            Entities.monster,
                            new List<Skill>() {
                                new Skill(
                                    "CAC Attack",
                                    1, // Zone
                                    1 + 3, // Att Damage (should be 1 + strength)
                                    0, //Mana
                                    false //Healing
                                )
                            }
                        ),
                        10, // Vision Length
                        r.Next(20), // Gold Drop
                        r.Next(100) // Exp Drop
                    );
                    break;
                case MonsterTypes.Sorcerer:
                    m = new Monster(
                        "Sorcerer " + name,
                        1, // level
                        5, // vitalityMax
                        5, // vitality
                        5, // manaMax
                        5, // mana
                        0, // strength
                        3, // intelligence
                        2, // defense
                        2, // PM
                        location,
                        new EntityClass(
                            "Sorcerer " + name,
                            5, //baseVitality
                            5, //baseMana
                            0, //baseStrength
                            3, //baseIntelligence
                            2, //baseDefense
                            2, //basePM
                            Entities.monster,
                            new List<Skill>() {
                                new Skill(
                                    "Range Attack",
                                    4, // Zone
                                    1 + 3, // Att Damage (should be 1 + intelligence)
                                    0, //Mana
                                    false //Healing
                                )
                            }
                        ),
                        50, // Vision Length
                        r.Next(50), // Gold Drop
                        r.Next(250) // Exp Drop
                    );
                    break;
                default:
                    m = GetMonsterFromType(MonsterTypes.Goblin, name, location);
                    break;
            }
            return m;
        }
    }
}
