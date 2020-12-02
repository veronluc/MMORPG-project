using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class ActionEndRound : Action
    {
        /// <summary>
        /// ActionEndRound class constructor
        /// </summary>
        /// <param name="entity">Entity making the action</param>
        /// <param name="world">World containing the entity</param>
        public ActionEndRound (Entity entity, World world) : base(entity, world) { }

        /// <summary>
        /// Determines if the action can be performed
        /// </summary>
        /// <returns>
        /// Always returns true (end of turn can always be performed)
        /// </returns>
        public override bool IsLegal()
        {
            return true;
        }

        /// <summary>
        /// End the entitie's turn
        /// </summary>
        /// <returns>
        /// Returns the new GameSate
        /// </returns>
        public override GameState makeAction()
        {
            if (!this.IsLegal())
            {
                return null;
            }

            // Restore Entity PMs
            entity.PM = entity.entityClass.basePM;

            // Change turn
            this.world.gameState.incrementIndex();
            return this.world.gameState;
        }
    }
}
