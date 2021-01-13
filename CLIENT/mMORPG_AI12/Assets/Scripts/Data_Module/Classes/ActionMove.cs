using System;
using UnityEngine;

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
            double distance = entity.location.distance(tile.location);

            // Distance is null
            if (distance == 0)
            {
				Console.WriteLine(entity.name + " cannot move, target location is too far");
                return false;
            }
            
            // Distance is bigger than PMs
            if (distance > entity.PM)
            {
				Console.WriteLine(entity.name + " cannot move, not enough PMs");
                return false;
            }

            // ActionMove is legal
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
            // If ActionMove isn't legal return null
            if (!this.IsLegal())
            {
                return null;
            }

            int distance = entity.location.distance(tile.location);

            // Take out from current tile
            world.gameState
                .map[entity.location.x, entity.location.y]
                .entities
                .Remove(entity);

            // Change entity Location
            entity.location = new Location(tile.location.x, tile.location.y);
            
            // Use entity PMs
            entity.usePMs(distance);
            
            // Put into new tile
            world.gameState
                .map[tile.location.x, tile.location.y]
                .entities
                .Add(entity);

            // Return new gameState
            return world.gameState;
        }
    }
}
