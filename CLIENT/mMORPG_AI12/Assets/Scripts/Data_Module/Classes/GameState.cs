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

        public GameState(int round, int index, List<Entity> turns, Tile[,] map)
        {
            this.round = round;
            this.index = index;
            this.turns = turns;
            this.map = map;
        }

        public Entity nextPlayerEntity()
        {
            return turns[nextIndex()];
        }

        public int nextIndex()
        {
            return (this.index + 1) % turns.Count;
        }

        public void incrementIndex()
        {
            this.index = nextIndex();
        }
    }
}
