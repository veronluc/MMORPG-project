using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionSkill : Action
    {
        public Tile tile { get; set; }
        public Skill skill { get; set; }

        /// <summary>
        /// Action class constructor
        /// </summary>
        /// <param name="entity">Entity making the action</param>
        /// <param name="world">World containing the entity</param>
        /// <param name="tile">Targeted Tile</param>
        /// <param name="skill">Skill to be performed by entity</param>
        public ActionSkill(Entity entity, World world, Tile tile, Skill skill) : base(entity, world)
        {
            this.tile = tile;
            this.skill = skill;
        }

        /// <summary>
        /// Determines if the action can be performed
        /// </summary>
        /// <returns>
        /// Returns true if the skill can be applied (range, manaCost...)
        /// </returns>
        public override bool IsLegal()
        {
            // TODO Implement - Team Data
            return true;
        }

        /// <summary>
        /// Applies the skill to the targeted Tile
        /// </summary>
        /// <returns>
        /// Returns the new GameSate or null if the action is not legal
        /// </returns>
        public override GameState makeAction()
        {
            if (!this.IsLegal())
            {
                return null;
            }

            // TODO Implement - Team Data
            // Apply skill to the targeted Tile
            return null;
        }
    }
}
