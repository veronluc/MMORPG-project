using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    public enum shapes
    {
        cross,
        star,
        circle
    }
    public class Range
    {
        public shapes shape { get; set; }
        public int distance { get; set; }

        public Range()
        {

        }
    }
}
