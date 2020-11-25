using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class GameState
    {
        public int round { get; set; }
        public int index { get; set; }
        public List<Entity> turns { get; set; }
        public Tile[,] map { get; set; }

        public GameState()
        {

        }

        public GameState(int round, int index, List<Entity> turns, Tile[,] map)
        {
            this.round = round;
            this.index = index;
            this.turns = turns;
            this.map = map;
        }
    }
}
