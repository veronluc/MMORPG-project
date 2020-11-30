using System;
using System.Collections.Generic;

namespace AI12_DataObjects
{

    [Serializable()]
    public enum Entities
    {
        monster,
        player,
        all
    }

    [Serializable()]
    public class EntityClass
    {
        public string name { get; set; }
        public int baseVitality { get; set; }
        public int baseMana { get; set; }
        public int baseStrength { get; set; }
        public int baseIntelligence { get; set; }
        public int baseDefense { get; set; }
        public int basePM { get; set; }
        public Entities exclusive { get; set; }
        public List<Skill> skills { get; set; }

        public EntityClass (string name, int baseVitality, int baseMana, int baseStrength, int baseIntelligence, int baseDefense, int basePM, Entities exclusive, List<Skill> skills) 
        {
            this.name = name;
            this.baseVitality = baseVitality;
            this.baseMana = baseMana;
            this.baseStrength = baseStrength;
            this.baseIntelligence = baseIntelligence;
            this.baseDefense = baseDefense;
            this.basePM = basePM;
            this.exclusive = exclusive;
            this.skills = skills;
        }
    }
}
