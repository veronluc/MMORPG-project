using AI12_DataObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class WorldManager
{
    /// <summary>
    /// Add a Player instance to a World
    /// </summary>
    /// <param name="world"></param>
    /// <param name="newPlayer"></param>
    public static void AddPlayerToWorld(World world, Player newPlayer)
    {
        // If no players, create the player list with the new Player
        if (world.players == null)
        {
            world.players = new List<Player> { newPlayer };
        } else
        {
            bool exists = false;
            world.players.ForEach(player =>
            {
                // If the player is already in the world, update its information
                if (player.user.id == newPlayer.user.id)
                {
                    player = newPlayer;
                    exists = true;
                }
            });

            // If the player isn't already in the world, add it
            if (!exists)
            {
                world.players.Add(newPlayer);
            }
        }
    }

    public static GameState GenerateGameState(World w)
    {
        GameState g;
        int NB_TILES = w.sizeMap;
        if (w.gameState == null)
        {
            // Generate the tiles
            Tile[,] tiles = new Tile[NB_TILES, NB_TILES];
            for (int i = 0; i < NB_TILES; i++)
            {
                for (int j = 0; j < NB_TILES; j++)
                {
                    tiles[i, j] = new TilePlain("" + i + "," + j, new Location(i, j), "?");
                }
            }
            // Add Players (should contain only the creator player btw) then monsters
            List<Entity> all = new List<Entity>(w.players);
            all.AddRange(w.monstersList);
            g = new GameState(
                0,
                0,
                all,
                tiles
            );
        } else
        {
            // Remove every player except the one of the creator
            g = w.gameState;
            g.turns.RemoveAll(p =>
                typeof(Player).IsInstanceOfType(p) &&
                ((Player) p).user.id == w.creator.id
            );
        }
        return g;
    }

    public static GameState AutoPlayMonster(World world)
    {
        // If the playing entity is not a monster return null
        if (!world.gameState.currentEntity().isMonster())
        {
            return null;
        }

        Monster monster = (Monster) world.gameState.currentEntity();
        Tile target = WorldManager.targetPlayer(world, monster);
        if (target == null)
        {
            Debug.Log("No target, move randomly");
            // Move randomly
            // Skip turn
            world.gameState = new ActionMove(monster, world, world.gameState.map[monster.location.x, monster.location.y + 1]).makeAction();
        } else
        {
            Debug.Log("Target locked, move towards target");
            // Move towards player
            // attack player if possible
            Tile destination = WorldManager.moveTowardTile(world, monster, target);
            if (destination != null)
            {
                world.gameState = new ActionMove(monster, world, destination).makeAction();
            }

            if (monster.entityClass.skills.Count == 0)
            {
                Debug.Log("Entity has no skills : cannot attack");
                return world.gameState;
            }
            
            ActionSkill attack = new ActionSkill(monster, world, target , monster.entityClass.skills[0]);
            if (attack.IsLegal())
            {
                Debug.Log("Attack target");
                world.gameState = attack.makeAction();
            }
        }

        return world.gameState;
    }

    private static Tile targetPlayer(World world, Monster monster)
    {
        int vision = monster.visionLength;
        int startx = 0;
        int endx = world.sizeMap;
        int starty = 0;
        int endy = world.sizeMap;

        // Set vision zone coordinates
        if (monster.location.x - vision > startx)
        {
            startx = monster.location.x - vision;
        }
        if (monster.location.x + vision < endx)
        {
            endx = monster.location.x + vision;
        }
        if (monster.location.y - vision > starty)
        {
            starty = monster.location.y - vision;
        }
        if (monster.location.y + vision < endy)
        {
            endy = monster.location.y + vision;
        }

        // 2 * world.sizeMap est la distance maximale entre deux points, on souhaite assigner +1 pour obtenir la valeur min inatteignable
        int minDistance = 2 * world.sizeMap + 1;
        Tile tile = null;

        for (int x = startx; x < endx; x++)
        {
            for (int y = starty; y < endy; y++)
            {
                Tile tempTile = world.gameState.map[x, y];
                foreach (Entity ent in tempTile.entities)
                {
                    // Entity is a player
                    if (!ent.isMonster())
                    {
                        int tempDist = tempTile.location.distance(monster.location);
                        if (tempDist < minDistance)
                        {
                            minDistance = tempDist;
                            tile = tempTile;
                        }
                    }
                }
            }
        }

        return tile;
    }

    private static Tile moveTowardTile(World world, Entity origin, Tile destination)
    {
        int xdiff = origin.location.x - destination.location.x;
        int ydiff = origin.location.y - destination.location.y;

        // Origin and target same Tile
        if (Math.Abs(xdiff) + Math.Abs(ydiff) == 0)
        {
            return null;
        }

        // Origin adjacent à target
        if (Math.Abs(xdiff) + Math.Abs(ydiff) == 1)
        {
            return null;
        }

        // Horizontal movement (x Axis)
        if (Math.Abs(xdiff) > Math.Abs(ydiff))
        {
            if (xdiff < 0)
            {
                // Move right x+
                if (Math.Abs(xdiff) > origin.PM)
                {
                    return world.gameState.map[origin.location.x + origin.PM, origin.location.y];
                } else
                {
                    if (Math.Abs(ydiff) > 0)
                    {
                        return world.gameState.map[origin.location.x + Math.Abs(xdiff), origin.location.y];
                    } else
                    {
                        return world.gameState.map[origin.location.x + Math.Abs(xdiff) - 1, origin.location.y];
                    }
                }
            }
            else if (xdiff > 0)
            {
                // Move left x-
                if (Math.Abs(xdiff) > origin.PM)
                {
                    return world.gameState.map[origin.location.x - origin.PM, origin.location.y];
                }
                else
                {
                    if (Math.Abs(ydiff) > 0)
                    {
                        return world.gameState.map[origin.location.x - Math.Abs(xdiff), origin.location.y];
                    }
                    else
                    {
                        return world.gameState.map[origin.location.x - Math.Abs(xdiff) + 1, origin.location.y];
                    }
                }
            }
        }
        // Vertical movement (y Axis)
        else if (Math.Abs(xdiff) <= Math.Abs(ydiff))
        {
            if (ydiff < 0)
            {
                // Move up y+
                if (Math.Abs(ydiff) > origin.PM)
                {
                    return world.gameState.map[origin.location.x, origin.location.y + origin.PM];
                }
                else
                {
                    if (Math.Abs(xdiff) > 0)
                    {
                        return world.gameState.map[origin.location.x, origin.location.y + Math.Abs(ydiff)];
                    }
                    else
                    {
                        return world.gameState.map[origin.location.x, origin.location.y + Math.Abs(ydiff) - 1];
                    }
                }
            }
            else if (ydiff > 0)
            {
                // Move down y-
                if (Math.Abs(ydiff) > origin.PM)
                {
                    return world.gameState.map[origin.location.x, origin.location.y - origin.PM];
                }
                else
                {
                    if (Math.Abs(xdiff) > 0)
                    {
                        return world.gameState.map[origin.location.x, origin.location.y + Math.Abs(ydiff)];
                    }
                    else
                    {
                        return world.gameState.map[origin.location.x, origin.location.y + Math.Abs(ydiff) - 1];
                    }
                }
            }
        }
        return null;
    }
}