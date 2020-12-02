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
        public string id { get; set; }
        public string name { get; set; }
        public int sizeMap { get; set; }
        public GameMode gameMode { get; set; }
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
        public List<Monster> monstersList { get; set; }
        public User creator { get; set; }
        public GameState gameState { get; set; }

        public World(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, User creator)
        {
            this.name = name;
            this.sizeMap = sizeMap;
            this.gameMode = gameMode;
            this.realDeath = realDeath;
            this.difficulty = difficulty;
            this.roundTimeSec = roundTimeSec;
            this.nbMaxPlayer = nbMaxPlayer;
            this.nbMaxMonsters = nbMaxMonsters;
            this.nbShops = nbShops;
            this.hasCity = hasCity;
            this.hasPlain = hasPlain;
            this.hasSwamp = hasSwamp;
            this.hasRiver = hasRiver;
            this.hasForest = hasForest;
            this.hasRockyPlain = hasRockyPlain;
            this.hasMontain = hasMontain;
            this.hasSea = hasSea;
            this.creator = creator;
            this.players = new List<Player>();
            this.monstersList = new List<Monster>();
        }
    }
}
