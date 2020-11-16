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
        public int zone { get; set; }
        public int damagePoints { get; set; }
        public int costMana { get; set; }
        public Range range { get; set; }

        public Skill()
        {

        }
    }
}
