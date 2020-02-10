using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    public Tilemap tilemap;
    public void Update()
    {
        {
            TileBase tile = null;
            tile = tilemap.GetTile(new Vector3Int(0, 0, 0));
        }
    }
}
