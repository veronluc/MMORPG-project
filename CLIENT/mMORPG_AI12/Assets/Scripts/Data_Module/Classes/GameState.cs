using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AI12_DataObjects
{
    [Serializable()]
    public class GameState
    {
        public int round { get; set; }
        public int index { get; set; }
        public List<Entity> turns { get; set; }
        public Tile[,] map { get; set; }

        public GameState(int round, int index, List<Entity> turns, Tile[,] map)
        {
            this.round = round;
            this.index = index;
            this.turns = turns;
            this.map = map;
        }

        public Entity nextEntity()
        {
            return turns[nextIndex()];
        }

        public Entity currentEntity()
        {
            return turns[this.index];
        }

        public int nextIndex()
        {
            return (this.index + 1) % turns.Count;
        }

        public void incrementIndex()
        {
            this.index = nextIndex();
        }

        public bool currentEntityIsMonster()
        {
            return this.currentEntity().isMonster();
        }

        public bool nextEntityIsMonster()
        {
            return this.nextEntity().isMonster();
        }

		public void Print() {
            for (int y = map.GetUpperBound(1); y >= 0; y--) 
            {
				Printer.Word(y.ToString() + " ");
                for (int x = 0; x <= map.GetUpperBound(0); x++)
                {
                    Tile t = map[x,y];
                    if (t.entities.Count == 0)
                    {
						Printer.Word("- ");
                    } else
                    {
                        if (t.entities[0].isMonster())
                        {
							Printer.Word("x ", ConsoleColor.Red);
                        } else
                        {
                            // first letter of the name
							if (t.entities[0].id == currentEntity().id)
								Printer.Word(t.entities[0].name[0] + " ", ConsoleColor.Green);
							else
								Printer.Word(t.entities[0].name[0] + " ", ConsoleColor.Cyan);
                        }
                    }
                }
				Printer.Line("");
            }
			Printer.Word("  ");
            for (int x = 0; x <= map.GetUpperBound(0); x++)
            {
				Printer.Word(x.ToString() + " ");
            }
			Printer.Line("");
		}

        public override string ToString()
        {
            string str = "";
            string bottom = "  ";
            for (int y = map.GetUpperBound(1); y >= 0; y--) 
            {
                str = str + y.ToString() + " ";
                for (int x = 0; x <= map.GetUpperBound(0); x++)
                {
                    Tile t = map[x,y];
                    if (t.entities.Count == 0)
                    {
                        str = str + "- ";
                    } else
                    {
                        if (t.entities[0].isMonster())
                        {
                            str = str + "x ";
                        } else
                        {
                            // first letter of the name
                            str = str + t.entities[0].name[0] + " ";
                        }
                    }
                }
                str = str + "\n";
            }
            for (int x = 0; x <= map.GetUpperBound(0); x++)
            {
                bottom = bottom + x.ToString() + " ";
            }
            return str + bottom + "\n";
        }
    }
}
