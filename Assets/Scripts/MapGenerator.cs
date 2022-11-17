using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColorMap, Mesh};
    public DrawMode drawMode;

    public int seed;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;

    [Range(0, 1)]
    public float persistance = 0.5f;
    public float lacunarity = 2f;
    public Vector2 offset;
    public float offsetSpeed = 0.01f;

    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    [Range(-1, 1)]
    public float waterLevel;

    public bool autoUpdate;

    public TerrainType[] regions;

    

    public float[,] getNoiseMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        
        return noiseMap;
    }

    public void generateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colorMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; ++y)
        {
            for (int x = 0; x < mapWidth; ++x)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; ++i)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colorMap[y*mapWidth + x] = regions[i].color;
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
        else if (drawMode == DrawMode.ColorMap)
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
                for (int i = 0; i < regions.Length; ++i)
                {
                    regions[i].height = (regions[i].defaultHeight + waterLevel);
                }

                for (int i = 0; i < regions.Length-1; ++i)
                {
                    if (regions[regions.Length-1].height == 0) regions[i].height = 1;
                    else regions[i].height *= (1 / (float)regions[regions.Length-1].height);
                    if (regions[i].height > 1) regions[i].height = 1; 
                    if (regions[i].height < 0) regions[i].height = 0; 
                }
                regions[regions.Length-1].height = 1;
            }
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
        else 
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
    }

    public void changePersistance(float newPersistance)
    {
        persistance = newPersistance;
        generateMap();
    }

    public void changeLacunarity(float newLacunarity)
    {
        lacunarity = newLacunarity;
        generateMap();
    }

    public void changeScale(float newNoiseScale)
    {
        noiseScale = newNoiseScale;
        generateMap();
    }

    public void changeOctaves(float newOctaves)
    {
        octaves = (int)newOctaves;
        generateMap();
    }

    public void changeWidth(string newMapWidth)
    {
        if (newMapWidth != "")
        {
            mapWidth = int.Parse(newMapWidth);
            if (mapWidth > 300) mapWidth = 300;
            if (mapWidth < 0) mapWidth = 1;
            generateMap();
        }
    }

    public void changeHeight(string newMapHeight)
    {
        if (newMapHeight != "")
        {
            mapHeight = int.Parse(newMapHeight);
            if (mapHeight > 300) mapHeight = 300;
            if (mapHeight < 0) mapHeight = 1;
            generateMap();
        }
    }

    public void changeMeshHeightMultiplier(string newMeshHeightMultiplier)
    {
        if (newMeshHeightMultiplier != "")
        {
            meshHeightMultiplier = float.Parse(newMeshHeightMultiplier);
            if (meshHeightMultiplier < 0.0001) meshHeightMultiplier = 0.0001f;
            generateMap();
        }
    }

    public void changeOffsetSpeed(float newOffsetSpeed)
    {
        offsetSpeed = newOffsetSpeed;
    }

    public void changeDrawMode(int val)
    {
        if (val == 0) drawMode = DrawMode.NoiseMap;
        else if (val == 1) drawMode = DrawMode.ColorMap;
        else if (val == 2) drawMode = DrawMode.Mesh;
        else drawMode = DrawMode.ColorMap;

        generateMap();
    }

    public TMP_InputField InputFieldSeed;
    public void randomSeed()
    {
        seed = Random.Range(0, (int)1e9 - 1);
        InputFieldSeed.text = seed.ToString();
        // InputFieldSeed.
        generateMap();
    }

    public void changeSeed(string newSeed)
    {
        if (newSeed != "")
        {
            if (newSeed.Length > 9) seed = (int)1e9 - 1;
            else seed = int.Parse(newSeed);

            generateMap();
        }
    }

    public void checkSeed(string seed)
    {
        if (seed.Length > 9) 
        {
            seed = seed.Substring(0, 9);
            InputFieldSeed.text = seed;
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
    public Color color;

    public float defaultHeight;
}
