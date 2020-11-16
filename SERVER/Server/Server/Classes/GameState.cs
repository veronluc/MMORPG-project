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
        public int Round { get; set; }
        public int Index { get; set; }
        public List<Entity> Turns { get; set; }
        public Tile[,] Map { get; set; }

        public GameState()
        {

        }
    }
}
