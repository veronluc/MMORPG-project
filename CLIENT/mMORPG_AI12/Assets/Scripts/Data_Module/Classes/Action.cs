using System;

namespace AI12_DataObjects {
    [Serializable()]
    public abstract class Action
    {
        public Entity entity { get; set; }
        public World world { get; set; }

        /// <summary>
        /// Action class constructor
        /// </summary>
        /// <param name="entity">Entity making the action</param>
        /// <param name="world">World containing the entity</param>
        public Action (Entity entity, World world)
        {
            this.entity = entity;
            this.world = world;
        }

        /// <summary>
        /// Determines if the action can be performed
        /// </summary>
        /// <returns>
        /// Returns true if the action is legal, false otherwise.
        /// </returns>
        public abstract bool IsLegal();

        /// <summary>
        /// Performs the Action
        /// </summary>
        /// <returns>
        /// Returns the new GameSate or null if the action is not legal
        /// </returns>
        public abstract GameState makeAction();
    }
}
