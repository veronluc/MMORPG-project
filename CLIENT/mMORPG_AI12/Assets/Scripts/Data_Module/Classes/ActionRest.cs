using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionRest : Action
    {
        /// <summary>
        /// ActionRest class constructor
        /// </summary>
        /// <param name="entity">Entity making the action</param>
        /// <param name="world">World containing the entity</param>
        public ActionRest(Entity entity, World world) : base(entity, world) { }

        /// <summary>
        /// Determines if the action can be performed
        /// </summary>
        /// <returns>
        /// Returns true if the tile the player is on is a TileShop
        /// </returns>
        public override bool IsLegal()
        {
            // TODO - V2A Always not legal ! (no shop tiles)
            // TODO Implement for V2B
            return false;
        }

        /// <summary>
        /// Rests the entity
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

            // TODO - V2A Always not legal ! (no shop tiles)
            // TODO Implement for V2B
            return null;
        }
    }
}
