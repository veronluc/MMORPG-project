using System.Collections;
using System.Collections.Generic;
using System;

namespace AI12_DataObjects {
    [Serializable()]
    // TODO est-ce que abstrait ?
    public class Action
    {
        public Player player { get; set; }
        public World world { get; set; }

        public Action ()
        {

        }
    }
}
