using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionSkill : Action
    {
        public Skill skill { get; set; }

        public ActionSkill()
        {

        }

        public ActionSkill(Player player, World world, Skill skill)
        {
            this.player = player;
            this.world = world;
            this.skill = skill;
        }
    }
}
