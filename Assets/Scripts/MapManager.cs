using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap DarkMap;
    public Tilemap BackgroundMap;

    public Tile DarkTile;

    void Start()
    {
        DarkMap.origin = BackgroundMap.origin;
        DarkMap.size = BackgroundMap.size;

        foreach (Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }
    }
}
