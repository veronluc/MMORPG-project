using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public abstract class Entity
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
        public int pM { get; set; }
        public Location location { get; set; }
        public EntityClass entityClass { get; set; }

        public Entity()
        {

        }
    }
}
