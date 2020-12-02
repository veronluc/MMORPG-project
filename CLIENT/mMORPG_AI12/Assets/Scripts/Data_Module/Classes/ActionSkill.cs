using System;
using UnityEngine;
using System.Collections.Generic;

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
            double distance = entity.location.distance(tile.location);

            // Distance is bigger than authorized distance
            if (distance > skill.zone)
            {
                Debug.Log("ActionSkill : Distance is bigger than authorized distance");
                return false;
            }

            // ManaCost is bigger than current mana
            if (skill.costMana > entity.mana)
            {
                Debug.Log("ActionSkill : ManaCost is bigger than current mana");
                return false;
            }

            // ActionSkill is legal
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

            // Deplete entity mana
            entity.mana = entity.mana - skill.costMana;

            // Update entity on Tile
            world.gameState.map[entity.location.x, entity.location.y].entities.Remove(entity);
            world.gameState.map[entity.location.x, entity.location.y].entities.Add(entity);

            // Apply skill on Tile (and contained entities)
            List<Entity> targets = world.gameState.map[tile.location.x, tile.location.y].entities;
            targets.ForEach(delegate (Entity target)
            {
                if (skill.healing)
                {
                    this.healEntity(entity, target, skill);
                } else
                {
                    this.damageEntity(entity, target, skill);
                }
            });
            world.gameState.map[tile.location.x, tile.location.y].entities = targets;

            return world.gameState;
        }

        private void damageEntity(Entity brawler, Entity target, Skill skill)
        {
            target.damageEntity(skill.damagePoints + brawler.getAttackBase());
        }

        private void healEntity(Entity healer, Entity target, Skill skill)
        {
            target.healEntity(skill.damagePoints + healer.getAttackBase());
        }
    }
}
