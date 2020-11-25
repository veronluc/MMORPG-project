using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public enum shapes
    {
        cross,
        star,
        circle
    }
    [Serializable()]
    public class Range
    {
        public shapes shape { get; set; }
        public int distance { get; set; }

        public Range()
        {

        }

        public Range(shapes shape, int distance)
        {
            this.shape = shape;
            this.distance = distance;
        }
    }
}
