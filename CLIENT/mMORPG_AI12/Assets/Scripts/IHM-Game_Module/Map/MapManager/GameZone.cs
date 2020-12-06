using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using AI12_DataObjects;
using Tile = AI12_DataObjects.Tile;

/// <summary>
/// Cette classe GameZone est liée au GameObject Grid > Tilemap.
/// Elle permet de générer la map en fonction de sa taille spécifiée dans la classe GameData.
/// </summary>
public class GameZone : MonoBehaviour
{
    //Pour dessiner la Tilemap, on va récupérer le GameObject Tilemap, le script TilesHolder qui fournit la Tile à utiliser
    private Tilemap gameZoneTilemap;
    private TilesHolder tilesHolder;

    // variable nous permettant d'avoir accès aux attributs et méthodes de IHM GameModule
    private IHMGameModule ihmGameModule;

    private World world;

    private void Awake()
    {
        gameZoneTilemap = GetComponent<Tilemap>();
        tilesHolder = GetComponent<TilesHolder>();
    }

    /// <summary>
    /// Génération visuelle de la map.
    /// </summary>
    private void Start()
    {
        // récupération des attributs et méthodes de IHMGameModule
        ihmGameModule = GameObject.FindGameObjectWithTag("IHMGameModule").GetComponent<IHMGameModule>();

        // affectation de world à partir de celui présent dans ihmGameModule
        world = ihmGameModule.world;

        //Taille du monde (longueur d'un côté du monde carré (ou largeur ou hauteur, c'est un carré de toute façon)
        int size = world.sizeMap;

        //La var origin va récupérer l'origine de la Tilemap de type Vector3Int, pour savoir où commencer à dessiner la Tilemap.
        Vector3Int origin = gameZoneTilemap.origin;

        //La var cellsize va récupérer la taille de chaque cellule de la Tilemap.
        //Elle est de 128x128/cellule. C'est une des tailles standard proposée lors du téléchargement des icônes sur flaticon.com. 
        //Cette taille a été spécifiée dans le fichier Materials > IHM-Game_Module > Resources > Tiles > IHM_Game_Tileset.png
        //Dans l'inspector, vous retrouverez Sprite Mode > Pixel Per Unit = 128.
        Vector3 cellSize = gameZoneTilemap.cellSize;
        
        //ClearAllTiles() va nettoyer la TileMap au cas où elle a déjà été dessinée.
        gameZoneTilemap.ClearAllTiles();
        
        //La var currentCellPosition va nous servir de pointeur pour dessiner la Tilemap.
        Vector3Int currentCellPosition = origin;
        
        //La var size stocke la longueur/largueur de la Tilemap afin de faire deux boucles for
        // on parcourt d'abord les lignes, puis au sein de chaque ligne, les colonnes (il s'agit des tiles).
        for (int h = 0; h < size; h++)
        {
            for (int w = 0; w < size; w++)
            {
                //On positionne le pointeur au début de la ligne à dessiner
                // La méthode SetTile prend deux paramètres :
                //    1. la position de la cellule que l'on souhaite "colorier" avec le bon sprite
                //    2. le sprite associé à la position dans le world fourni
                //
                // Pour le deuxième paramètre, tileChooser permet de choisir le bon sprite parmi ceux définis dans la classe TilesHolder
                // Ils sont physiquement présents dans le dossier Materials > IHM-Game_Module > Resources > Tiles
                //Debug.Log("height : " + h + "; width : " + w);
                gameZoneTilemap.SetTile(currentCellPosition, tilesHolder.TileChooser(world.gameState.map[h, w].sprite));
                
                //On dessine une par une les Tiles de toute la ligne en avançant sur l'axe x
                currentCellPosition = new Vector3Int(
                    (int)(cellSize.x + currentCellPosition.x),
                    currentCellPosition.y, origin.z);
            }
            //On passe à la ligne suivante (celle du dessus car la Tilemap est dessinée de haut en bas et de gauche à droite)
            currentCellPosition = new Vector3Int(origin.x, (int)(cellSize.y + currentCellPosition.y), origin.z);
        }

        //CompressBounds() va permettre de rendre les limites de la Tilemap plus net
        gameZoneTilemap.CompressBounds();
        
    }
}
