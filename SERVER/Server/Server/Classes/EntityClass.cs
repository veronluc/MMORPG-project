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
        public string Name { get; set; }
        public int BaseVitality { get; set; }
        public int BaseMana { get; set; }
        public int BaseStrength { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseDefense { get; set; }
        public int BasePM { get; set; }
        public Entities Exclusive { get; set; }
        public List<Skill> Skills { get; set; }

        public EntityClass()
        {

        }

    }
}
