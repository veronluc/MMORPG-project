using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Monster : Entity
    {
        public int visionLength { get; set; }
        public int dropGold { get; set; }
        public int dropXp { get; set; }

        //TODO trouver une solution
        /*
        public Monster(string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass, int visionLength, int dropGold, int dropXp)
        {
            this.name = name;
            this.level = level;
            this.vitalityMax = vitalityMax;
            this.vitality = vitality;
            this.manaMax = manaMax;
            this.mana = mana;
            this.strength = strength;
            this.intelligence = intelligence;
            this.defense = defense;
            this.PM = PM;
            this.location = location;
            this.entityClass = entityClass;
            this.visionLength = visionLength;
            this.dropGold = dropGold;
            this.dropXp = dropXp;
        }
        */
    }
}
