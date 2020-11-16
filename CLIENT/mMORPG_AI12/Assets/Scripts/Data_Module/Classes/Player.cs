using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Player: Entity
    {
        public int Gold { get; set; }
        public int Xp { get; set; }
        public User User { get; set; }

        public Player()
        {

        }
    }
}
