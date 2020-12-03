using System;

namespace AI12_DataObjects
{

    public class PathNode
    {
        public PathNode up { get; set; }
        public PathNode down { get; set; }
        public PathNode right { get; set; }
        public PathNode left { get; set; }
        int weight { get; set; }
        public Location location { get; set; }
        public int x { get => location.x; }
        public int y { get => location.y; }
        public bool occupied;

        public PathNode(int weight, int x, int y, bool occupied)
        {
            this.weight = weight;
            this.location = new Location(x, y);
            this.occupied = occupied;
        }
    }
}