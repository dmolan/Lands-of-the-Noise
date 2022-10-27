using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColourMap, Mesh};
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]

    // [@HideInInspector]
    public float persistance = 0.5f;

    // [@HideInInspector]
    public float lacunarity = 2f;

    public int seed;
    public Vector2 offset;

    // [@HideInInspector]
    public float offsetSpeed = 0.01f;

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

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
        else 
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
        }
    }

    public void changePersistance(float newPersistance)
    {
        persistance = newPersistance;
        GenerateMap();
    }

    public void changeLacunarity(float newLacunarity)
    {
        lacunarity = newLacunarity;
        GenerateMap();
    }

    public void changeScale(float newNoiseScale)
    {
        noiseScale = newNoiseScale;
        GenerateMap();
    }

    public void changeOctaves(float newOctaves)
    {
        octaves = (int)newOctaves;
        GenerateMap();
    }

    public void changeWidth(string newMapWidth)
    {
        if (newMapWidth != "")
        {
            mapWidth = int.Parse(newMapWidth);
            if (mapWidth > 300) mapWidth = 300;
            if (mapWidth < 0) mapWidth = 1;
            GenerateMap();
        }
    }

    public void changeHeight(string newMapHeight)
    {
        if (newMapHeight != "")
        {
            mapHeight = int.Parse(newMapHeight);
            if (mapHeight > 300) mapHeight = 300;
            if (mapHeight < 0) mapHeight = 1;
            GenerateMap();
        }
    }

    public void changeMeshHeightMultiplier(string newMeshHeightMultiplier)
    {
        if (newMeshHeightMultiplier != "")
        {
            meshHeightMultiplier = float.Parse(newMeshHeightMultiplier);
            if (meshHeightMultiplier < 0.0001) meshHeightMultiplier = 0.0001f;
            GenerateMap();
        }
    }

    public void changeOffsetSpeed(float newOffsetSpeed)
    {
        offsetSpeed = newOffsetSpeed;
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
