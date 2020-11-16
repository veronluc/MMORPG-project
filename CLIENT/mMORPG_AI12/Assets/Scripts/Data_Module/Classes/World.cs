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
        public string Name { get; set; }
        public int SizeMap { get; set; }
        public GameMode Gamemode { get; set; }
        public bool RealDeath { get; set; }
        public int Difficulty { get; set; }
        public int RoundTimeSec { get; set; }
        public int NbMaxPlayer { get; set; }
        public int NbMaxMonsters { get; set; }
        public int NbShops { get; set; }
        public bool HasCity { get; set; }
        public bool HasPlain { get; set; }
        public bool HasSwamp { get; set; }
        public bool HasRiver { get; set; }
        public bool HasForest { get; set; }
        public bool HasRockyPlain { get; set; }
        public bool HasMontain { get; set; }
        public bool HasSea { get; set; }
        public List<Player> Players { get; set; }
        public List<Monster> MonstersList { get; set; }
        public User Creator { get; set; }
        public GameState GameState { get; set; }

        public World(string name, int sizeMap, GameMode gameMode, bool realDeath, int difficulty, int roundTimeSec, int nbMaxPlayer, int nbMaxMonsters, int nbShops, bool hasCity, bool hasPlain, bool hasSwamp, bool hasRiver, bool hasForest, bool hasRockyPlain, bool hasMontain, bool hasSea, List<Player> players, List<Monster> monsters, User creator, GameState gameState)
        {
            Name = name;
            SizeMap = sizeMap;
            Gamemode = gameMode;
            RealDeath = realDeath;
            Difficulty = difficulty;
            RoundTimeSec = roundTimeSec;
            NbMaxPlayer = nbMaxPlayer;
            NbMaxMonsters = nbMaxMonsters;
            NbShops = nbShops;
            HasCity = hasCity;
            HasPlain = hasPlain;
            HasSwamp = hasSwamp;
            HasRiver = hasRiver;
            HasForest = hasForest;
            HasRockyPlain = hasRockyPlain;
            HasMontain = hasMontain;
            HasSea = hasSea;
            Players = players;
            MonstersList = monsters;
            Creator = creator;
            GameState = gameState;
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
