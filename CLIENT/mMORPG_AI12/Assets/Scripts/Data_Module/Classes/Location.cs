using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }

        public Location (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int distance (Location loc)
        {
            return Math.Abs(this.x - loc.x) + Math.Abs(this.y - loc.y);
        }
    }
}
