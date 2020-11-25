using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionMove : Action
    {
        public ActionMove()
        {

        }

        public ActionMove(Player player, World world)
        {
            this.player = player;
            this.world = world;
        }
    }
}
