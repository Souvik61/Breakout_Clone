using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BricksKeeperScript : MonoBehaviour
{
    //Editor assign
    public Grid gridToKeep;

    //Oth

    private List<TileBase> allTilesList;

    private void Awake()
    {
        allTilesList = new List<TileBase>();
    }

    private void OnEnable()
    {
        AllEventsScript.OnCollisionWTile += OnTileDestroyed;

    }

    private void OnDisable()
    {
        AllEventsScript.OnCollisionWTile -= OnTileDestroyed;
    }

    //Set associated tilemap
    public void SetGridToKeep(Grid grid)
    {
        allTilesList.Clear();
     
        gridToKeep = grid;

        if (gridToKeep != null)
        {
            allTilesList = GetAllTiles<TileBase>(gridToKeep.GetComponentInChildren<Tilemap>());
        }
    }

    //Reset keeper
    private void ResetKeeper()
    {
        
    }

    //Get a list of all tiles in an Tilemap.
    public static List<T> GetAllTiles<T>(Tilemap tilemap) where T : TileBase
    {
        List<T> tiles = new List<T>();

        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                T tile = tilemap.GetTile<T>(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    tiles.Add(tile);
                }
            }
        }
        return tiles;
    }

    //On tile deleted
    void OnTileDestroyed(TileBase tile)
    {
        allTilesList.Remove(tile);

        if (allTilesList.Count == 0)
        {
            OnAllTilesDest();
        }
    }
    //On All Tile Destroyed
    void OnAllTilesDest()
    {
        //Invoke all tiles destroyed event
        AllEventsScript.OnAllTilesDestroyed?.Invoke();
    }



}
