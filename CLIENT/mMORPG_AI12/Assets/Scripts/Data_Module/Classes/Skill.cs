using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Skill
    {
        public string name;
        public int zone { get; set; }
        public int damagePoints { get; set; }
        public int costMana { get; set; }
        public Range range { get; set; }
        public bool healing { get; set; }

        [Obsolete("Skill should now be initialized with the new constructor")]
        public Skill()
        {
            this.name = "";
            this.zone = 0;
            this.damagePoints = 0;
            this.costMana = 0;
            this.healing = false;
        }

        /// <summary>
        /// Skill class constructor
        /// </summary>
        /// <param name="name">Denomination of the skill</param>
        /// <param name="zone">Maximum authorized distance-to-Tile to cast the Skill</param>
        /// <param name="damagePoints">Damage done by the skill</param>
        /// <param name="costMana">Mana cost of the skill</param>
        /// <param name="healing">True if healing skill, false if damaging skill</param>
        public Skill(string name, int zone, int damagePoints, int costMana, bool healing = false)
        {
            this.name = name;
            this.zone = zone;
            this.damagePoints = damagePoints;
            this.costMana = costMana;
            this.healing = healing;
        }
    }
}
