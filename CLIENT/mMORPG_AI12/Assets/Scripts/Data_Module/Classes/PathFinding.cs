using System;

namespace AI12_DataObjects
{
    public class PathFinding
    {
        /*public Dictionary<Location, PathNode> nodes;

        public PathFinding(GameState game)
        {
            nodes = new Dictionary<Location, PathNode>();
            // Initialise all nodes
            for (int x = 0; x <= game.map.getUpperBound(0); x++)
            {
                for (int y = 0; y <= game.map.getUpperBound(1); y++)
                {
                    bool occupied = game.map[x, y].entities.Count > 0;
                    nodes.Add(new Location(x, y), new PathNode(1, x, y), occupied);
                }
            }

            // Intialise links between nodes
            for (int x = 0; x <= game.map.getUpperBound(0); x++)
            {
                for (int y = 0; y <= game.map.getUpperBound(1); y++)
                {
                    // UP
                    if (y + 1 <= game.map.getUpperBound(1))
                    {
                        nodes[new Location(x, y)].up = nodes[new Location(x, y + 1)];
                    }

                    // DOWN
                    if (y - 1 >= 0)
                    {
                        nodes[new Location(x, y)].down = nodes[new Location(x, y - 1)];
                    }


                    // RIGHT
                    if (x + 1 <= game.map.getUpperBound(0))
                    {
                        nodes[new Location(x, y)].right = nodes[new Location(x + 1, y)];
                    }

                    // LEFT
                    if (x - 1 >= 0)
                    {
                        nodes[new Location(x, y)].left = nodes[new Location(x - 1, y)];
                    }
                }
            }
        }*/
    }
}