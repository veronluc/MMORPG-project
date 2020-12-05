using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Cette classe GameData est liée au GameObject Grid > Tilemap.
/// Elle permet de spécifier la Tile qui sera utilisée pour dessiner la carte.
/// </summary>
public class TilesHolder : MonoBehaviour
{
    private Tile default_tile;
    private Tile grass;
    private Tile city;
    private Tile hostel_low;
    private Tile hostel_high;
    private Tile swamp;
    private Tile river;
    private Tile forest;
    private Tile rocky_plains;
    private Tile mountains;
    private Tile sea;
    private Tile spawn;

    /// <summary>
    /// Chargement des assets des tiles et stockage de ces assets dans les variables définies précédemment.
    /// </summary>
    private void Awake()
    {

        //Chaque var va chercher dans le dossier "Materials > IHM-Game_Module > Resources" le fichier spécifié dans la fonction Resources.Load
        default_tile = (Tile) Resources.Load("Tiles/default_tile", typeof(Tile));
        grass = (Tile)Resources.Load("Tiles/grass", typeof(Tile));
        city = (Tile)Resources.Load("Tiles/city", typeof(Tile));
        hostel_low = (Tile)Resources.Load("Tiles/hostel_low", typeof(Tile));
        hostel_high = (Tile)Resources.Load("Tiles/hostel_high", typeof(Tile));
        swamp = (Tile)Resources.Load("Tiles/swamp", typeof(Tile));
        river = (Tile)Resources.Load("Tiles/river", typeof(Tile));
        forest = (Tile)Resources.Load("Tiles/forest", typeof(Tile));
        rocky_plains = (Tile)Resources.Load("Tiles/rocky_plains", typeof(Tile));
        mountains = (Tile)Resources.Load("Tiles/mountains", typeof(Tile));
        sea = (Tile)Resources.Load("Tiles/sea", typeof(Tile));
        spawn = (Tile)Resources.Load("Tiles/spawn", typeof(Tile));

    }

    /// <summary>
    /// Retourne le tile associé à son nom, fonction utilisée dans GameZone.cs
    /// </summary>
    /// <param name="spriteName">Chaîne de caractères contenant un nom de sprite : "grass", "city"...</param>
    /// <returns>Tile (celui d'Unity, pas de Data)</returns>
    public Tile TileChooser(string spriteName)
    {
        switch (spriteName)
        {
            case "grass": return GetGrassTile();
            case "city": return GetCityTile();
            case "hostel_low": return GetHostelLowTile();
            case "hostel_high": return GetHostelHighTile();
            case "swamp": return GetSwampTile();
            case "river": return GetRiverTile();
            case "forest": return GetForestTile();
            case "rocky_plains": return GetRockyPlainsTile();
            case "mountains": return GetMountainsTile();
            case "sea": return GetSeaTile();
            case "spawn": return GetSpawnTile();
        }
        return GetDefaultTile();
    }
    public Tile GetDefaultTile()
    {
        return default_tile;
    }

    public Tile GetGrassTile()
    {
        return grass;
    }

    public Tile GetCityTile()
    {
        return city;
    }

    public Tile GetHostelLowTile()
    {
        return hostel_low;
    }
    public Tile GetHostelHighTile()
    {
        return hostel_high;
    }
    public Tile GetSwampTile()
    {
        return swamp;
    }
    public Tile GetRiverTile()
    {
        return river;
    }
    public Tile GetForestTile()
    {
        return forest;
    }
    public Tile GetRockyPlainsTile()
    {
        return rocky_plains;
    }
    public Tile GetMountainsTile()
    {
        return mountains;
    }
    public Tile GetSeaTile()
    {
        return sea;
    }
    public Tile GetSpawnTile()
    {
        return spawn;
    }

}
