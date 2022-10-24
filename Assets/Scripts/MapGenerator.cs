using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColourMap};
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    [Range(-1, 1)]
    public float waterLevel;

    public bool autoUpdate;

    public TerrainType[] regions;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colourMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; ++y)
        {
            for (int x = 0; x < mapWidth; ++x)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; ++i)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourMap[y*mapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap)
        {
            if (waterLevel > 0)
            {
                for (int i = 0; i < regions.Length; ++i)
                { 
                    regions[i].height = regions[i].defaultHeight + waterLevel;
                    if (regions[i].height > 1) regions[i].height = 1; 
                    if (regions[i].height < 0) regions[i].height = 0;   
                }
            }
            else
            {
                // (if water < 0) 0.6 * (1+waterLevel)
                // 0.2 0.4 0.5 0.6 | 0.67 0.81 0.91 0.985 1

                for (int i = 0; i < regions.Length; ++i)
                {
                    regions[i].height = (regions[i].defaultHeight + waterLevel);
                }

                // for (int i = 0; i < 4+1; ++i)
                // {

                // }

                for (int i = 0; i < regions.Length-1; ++i)
                {
                    if (regions[regions.Length-1].height == 0) regions[i].height = 1;
                    else regions[i].height *= (1 / (float)regions[regions.Length-1].height);
                    if (regions[i].height > 1) regions[i].height = 1; 
                    if (regions[i].height < 0) regions[i].height = 0; 
                }
                regions[regions.Length-1].height = 1;
            }
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
    }

    // Called every time one of public variables is changed
    void OnValidate()
    {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }
}

[System.Serializable]
public struct TerrainType 
{
    public string name;
    //[@HideInInspector]
    public float height;
    public Color colour;

    public float defaultHeight;
}
