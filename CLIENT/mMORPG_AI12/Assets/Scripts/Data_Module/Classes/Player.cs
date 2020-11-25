using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Player : Entity
    {
        public int gold { get; set; }
        public int xp { get; set; }
        public User user { get; set; }

        public Player()
        {

        }

        public Player(string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass, int gold, int xp, User user) : base(name, level, vitalityMax, vitality, manaMax, mana, strength, intelligence, defense, PM, location, entityClass)
        {
            this.gold = gold;
            this.xp = xp;
            this.user = user;
        }
    }
}
