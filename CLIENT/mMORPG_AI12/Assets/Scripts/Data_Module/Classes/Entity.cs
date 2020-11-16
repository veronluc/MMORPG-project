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
        public string Name { get; set; }
        public int Level { get; set; }
        public int VitalityMax { get; set; }
        public int Vitality { get; set; }
        public int ManaMax { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Defense { get; set; }
        public int PM { get; set; }
        public Location Location { get; set; }
        public EntityClass EntityClass { get; set; }

        public Entity()
        {

        }
    }
}
