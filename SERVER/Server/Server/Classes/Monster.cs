using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Monster : Entity
    {
        public int VisionLength { get; set; }
        public int DropGold { get; set; }
        public int DropXp { get; set; }

        public Monster()
        {

        }
    }
}
