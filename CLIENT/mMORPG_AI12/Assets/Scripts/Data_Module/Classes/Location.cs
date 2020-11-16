using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location (int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
