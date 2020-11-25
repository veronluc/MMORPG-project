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
        public Player(int gold, int xp, User user)
        {
            this.gold = gold;
            this.xp = xp;
            this.user = user;
        }

        public int gold { get; set; }
        public int xp { get; set; }
        public User user { get; set; }

    }
}
