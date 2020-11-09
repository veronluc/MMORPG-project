using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    public class GameState
    {
        public int round { get; set; }
        public int index { get; set; }
        public List<Entity> turns { get; set; }
        public Tile[,] map { get; set; }

        public GameState()
        {

        }
    }
}
