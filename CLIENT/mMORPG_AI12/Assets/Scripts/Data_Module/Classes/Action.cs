using System;

namespace AI12_DataObjects {
    [Serializable()]
    public abstract class Action
    {
        public Player player { get; set; }
        public World world { get; set; }
    }
}
