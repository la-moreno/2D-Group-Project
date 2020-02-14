using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PathFindingGrid : MonoBehaviour
{
    public Grid m_grid;
    public Tilemap tilemap;
    TileBase[] rails;

    Dictionary<Vector2Int, bool> m_obstacles;

    void Start()
    {
        tilemap = new Tilemap();

        rails = tilemap.GetTilesBlock(tilemap.cellBounds);
    }


    void Update()
    {
        for(int i = 0; i < rails.Length; i++)
        {

        }
    }
}
