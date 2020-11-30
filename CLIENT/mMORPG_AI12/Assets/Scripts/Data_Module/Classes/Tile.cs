using System.Collections;
using System.Collections.Generic;
using System;

namespace AI12_DataObjects {
    [Serializable()]
    public abstract class Tile
    {
        public string name { get; set; }
        public Location location { get; set; }
        public string sprite { get; set; }
        public List<Entities> entities { get; set; }

        public Tile(string name, Location location, string sprite)
        {
            this.name = name;
            this.location = location;
            this.sprite = sprite;
            this.entities = new List<Entity>();
        }

        public Tile(string name, Location location, string sprite, List<Entities> entities)
        {
            this.name = name;
            this.location = location;
            this.sprite = sprite;
            this.entities = entities;
        }
    }
}
