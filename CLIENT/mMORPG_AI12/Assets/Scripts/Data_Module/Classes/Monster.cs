using System;

namespace AI12_DataObjects
{
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
    }
}
