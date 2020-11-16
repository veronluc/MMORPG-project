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
        public int Zone { get; set; }
        public int DamagePoints { get; set; }
        public int CostMana { get; set; }
        public Range Range { get; set; }

        public Skill()
        {

        }
    }
}
