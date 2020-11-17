using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EntityClass()
        {

        }

    }
}
