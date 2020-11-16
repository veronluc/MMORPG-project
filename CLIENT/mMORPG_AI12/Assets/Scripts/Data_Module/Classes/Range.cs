using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI12_DataObjects
{
    [Serializable()]
    public enum Shapes
    {
        cross,
        star,
        circle
    }
    [Serializable()]
    public class Range
    {
        public Shapes Shape { get; set; }
        public int Distance { get; set; }

        public Range()
        {

        }
    }
}
