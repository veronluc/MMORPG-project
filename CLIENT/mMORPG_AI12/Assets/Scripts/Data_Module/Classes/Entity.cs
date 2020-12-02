using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Entity
    {
        public string name { get; set; }
        public int level { get; set; }
        public int vitalityMax { get; set; }
        public int vitality { get; set; }
        public int manaMax { get; set; }
        public int mana { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int defense { get; set; }
        public int PM { get; set; }
        public Location location { get; set; }
        public EntityClass entityClass { get; set; }

        public Entity(string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass)
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
        }
    }
}
