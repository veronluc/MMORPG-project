using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionMove : Action
    {
        public Tile tile { get; set; }

        /// <summary>
        /// ActionMove class constructor
        /// </summary>
        /// <param name="entity">Entity making the action</param>
        /// <param name="world">World containing the entity</param>
        /// <param name="tile">Targeted Tile</param>
        public ActionMove(Entity entity, World world, Tile tile) : base(entity, world) {
            this.tile = tile;
        }

        /// <summary>
        /// Determines if the action can be performed
        /// </summary>
        /// <returns>
        /// Returns true if the targeted tile is within PM range
        /// </returns>
        public override bool IsLegal()
        {
            // TODO Implement - Team Data
            return true;
        }

        /// <summary>
        /// Moves the entity to the targeted Tile
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
            // Move entity to targeted Tile
            return null;
        }
    }
}
