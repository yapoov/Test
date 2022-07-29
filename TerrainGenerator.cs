using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public Terrain terrain;
    public float frequency;
    public float heightScale;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {

        float[,] heightMap = terrain.terrainData.GetHeights(0, 0, 512, 512);

        for (int y = 0; y < 512; y++)
        {
            for (int x = 0; x < 512; x++)
            {
                heightMap[y, x] = Mathf.PerlinNoise(x / scale, y / scale) * heightScale;
            }
        }

        terrain.terrainData.SetHeights(0, 0, heightMap);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
