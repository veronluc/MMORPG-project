using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
