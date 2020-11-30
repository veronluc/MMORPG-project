using System.Collections;
using System.Collections.Generic;
using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class TilePlain : Tile
    {

        public TilePlain(string name, Location location, string sprite) : base(name, location, sprite) {}
    }
}
