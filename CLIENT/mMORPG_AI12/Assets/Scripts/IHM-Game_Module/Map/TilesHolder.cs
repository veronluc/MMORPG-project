#if UNITY_EDITOR
    using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilesHolder : MonoBehaviour
{
    private Tile _baseTile; private void Awake()
    {
#if UNITY_EDITOR
        _baseTile = (Tile)AssetDatabase.LoadAssetAtPath("Assets/Materials/IHM-Game_Module/Palettes/Overworld/overworld_53.asset", typeof(Tile));
#endif
    }
    public Tile GetBaseTile()
    {
        return _baseTile;
    }
}
