using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{
    [SerializeField] private int height = 100;
    [SerializeField] private int width = 100;
    [SerializeField] Sprite grassSpriteOriginal;
    
    GameObject tile_go;
    SpriteRenderer tile_sr;

    void Start()
    {
        WorldGeneration();
    }

    void WorldGeneration()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tile_go = new GameObject();

                tile_go.name = "Tile_" + x + "_" + y;
                tile_go.transform.position = new Vector3(x, y, 0);
                tile_go.transform.SetParent(this.transform, true);
                tile_sr = tile_go.AddComponent<SpriteRenderer>();
                tile_sr.sprite = grassSpriteOriginal;
            }
        }
    }
}
