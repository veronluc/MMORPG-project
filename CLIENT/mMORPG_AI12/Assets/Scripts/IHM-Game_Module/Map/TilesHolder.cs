using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TilesHolder : MonoBehaviour
{
    private Tile _baseTile; private void Awake()
    {
        _baseTile = (Tile)AssetDatabase.LoadAssetAtPath("Assets/Materials/IHM-Game_Module/Palettes/Overworld/overworld_53.asset", typeof(Tile));
    }
    public Tile GetBaseTile()
    {
        return _baseTile;
    }
}
