using System;

namespace AI12_DataObjects
{
    public enum PlayerType
    {
        Warrior,
        Rogue,
        Priest,
        Mage
    }

    [Serializable()]
    public class Player : Entity
    {
        public int gold { get; set; }
        public int xp { get; set; }
        public User user { get; set; }

        public Player(string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass, int gold, int xp, User user) : base(name, level, vitalityMax, vitality, manaMax, mana, strength, intelligence, defense, PM, location, entityClass)
        {
            this.gold = gold;
            this.xp = xp;
            this.user = user;
        }

        public Player(string id, string name, int level, int vitalityMax, int vitality, int manaMax, int mana, int strength, int intelligence, int defense, int PM, Location location, EntityClass entityClass, int gold, int xp, User user) : base(id, name, level, vitalityMax, vitality, manaMax, mana, strength, intelligence, defense, PM, location, entityClass)
        {
            this.gold = gold;
            this.xp = xp;
            this.user = user;
        }

        public override bool isMonster()
        {
            return false;
        }

        public static Player GenerateRandomPlayer()
        {
            Random rand = new Random();

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

            int randomMaxVitality = rand.Next(1, 100);
            int randomVitality = rand.Next(1, randomMaxVitality);
            int randomMaxMana = rand.Next(1, 100);
            int randomMana = rand.Next(1, randomMaxMana);

            EntityClass warrior = new EntityClass(
                "Warrior",
                rand.Next(1,100),

                );

            return new Player(
                new Guid(),
                names[rand.Next(0, names.Length)],
                rand.Next(0, 100),
                randomMaxVitality,
                randomVitality,
                randomMaxMana,
                randomMana,
                rand.Next(1, 100),
                rand.Next(1, 100),
                rand.Next(1, 100),
                3,
                null,
                
                );
        }
    }
}
