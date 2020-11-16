using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AI12_DataObjects
{
    [Serializable()]
    public enum GameMode
    {
        pvp,
        pve
    }

    [Serializable()]
    public class World
    {
        public string name { get; set; }
        public int sizeMap { get; set; }
        public GameMode gamemode { get; set; }
        public bool realDeath { get; set; }
        public int difficulty { get; set; }
        public int roundTimeSec { get; set; }
        public int nbMaxPlayer { get; set; }
        public int nbMaxMonsters { get; set; }
        public int nbShops { get; set; }
        public bool hasCity { get; set; }
        public bool hasPlain { get; set; }
        public bool hasSwamp { get; set; }
        public bool hasRiver { get; set; }
        public bool hasForest { get; set; }
        public bool hasRockyPlain { get; set; }
        public bool hasMontain { get; set; }
        public bool hasSea { get; set; }
        public List<Player> players { get; set; }
        public List<Monster> monsters { get; set; }
        public Player creator { get; set; }
        public GameState gameState { get; set; }

        public World()
        {

        }

        public void Print()
        {
            Debug.Log("name : " + name);
            Debug.Log("sizeMap : " + sizeMap);
            Debug.Log("gamemode : " + gamemode);
            Debug.Log("realDeath : " + realDeath);
            Debug.Log("difficulty : " + difficulty);
            Debug.Log("roundTimeSec : " + roundTimeSec);
            Debug.Log("nbMaxPlayer : " + nbMaxPlayer);
            Debug.Log("nbMaxMonsters : " + nbMaxMonsters);
            Debug.Log("nbShops : " + nbShops);
            Debug.Log("hasCity : " + hasCity);
            Debug.Log("hasPlain : " + hasPlain);
            Debug.Log("hasSwamp : " + hasSwamp);
            Debug.Log("hasRiver : " + hasRiver);
            Debug.Log("hasForest : " + hasForest);
            Debug.Log("hasRockyPlain : " + hasRockyPlain);
            Debug.Log("hasMontain : " + hasMontain);
            Debug.Log("hasSea : " + hasSea);
            Debug.Log("players : " + players);
            Debug.Log("monsters : " + monsters);
            Debug.Log("creator : " + creator);
            Debug.Log("gameState : " + gameState);
        }
    }
}
