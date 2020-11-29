using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionRest : Action
    {
        public int PM { get; set; }

        public ActionRest(Player player, World world, int pm)
        {
            this.player = player;
            this.world = world;
            PM = pm;
        }
    }
}
