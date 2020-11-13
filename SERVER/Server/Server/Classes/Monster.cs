using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    public class Monster: Entity
    {
        public int visionLength { get; set; }
        public int dropGold { get; set; }
        public int dropXp { get; set; }

        public Monster()
        {

        }
    }
}
