using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionEndRound : Action
    {
        public ActionEndRound()
        {

        }

        public ActionEndRound(Player player, World world)
        {
            this.player = player;
            this.world = world;
        }
    }
}
