/*
 * By the given Noise Map generates Color Map, calls Texture- and Mesh Generators and
 * gives results to MapDisplay.
 * Also manages map parameters changing.
 */

using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public AppUI appUI;
    public TableUI tableUI;
    public HowDoesItWorkPages howDoesItWorkPages;
    public HowToUsePages howToUsePages;
    public LanguagesForText languagesForText;
    public Config config;

    public enum DrawMode { NoiseMap, ColorMap, Mesh, Table };
    public DrawMode drawMode;

    public int seed;

    public int mapWidth, mapHeight;
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
    public float minMapValue, maxMapValue;

    public int staticPointX, staticPointY; // Coordinates of static point
    public float staticPointHeight; // Height of static point 
    public int staticPointRadius; // Radius of static point's hill

    static Color[] colorMap;



    // Starting point of the App
    void Start()
    {
        howToUsePages.setSlide(howToUsePages.currSlide);
        howDoesItWorkPages.setSlide(howDoesItWorkPages.currentSlide);
        
        appUI.changeDrawMode(2);
        languagesForText.changeLanguage(languagesForText.DEFAULT_LANGUAGE);
        config.configStart();
    }

    public float[,] getNoiseMap()
    {
        float[,] noiseMap = Noise.generateNoiseMap(seed, mapWidth, mapHeight,
        octaves, persistance, lacunarity, noiseScale, offset);

        return noiseMap;
    }

    public void changeNoiseMapToFitStaticPoint(float[,] noiseMap, int staticPointX, int staticPointY, float height, int radius)
    {
        // If some parameters are wrong, don't change "noiseMap[,]"
        if (staticPointX < 0 || staticPointX > mapWidth 
        || staticPointY < 0 || staticPointY > mapHeight 
        || staticPointHeight < 0 && staticPointHeight > 1) return;

        float valueAfterChanges; // Current value of parabola
        float valueBeforeChanges;  // Current value on map before chages
        float currentDistanceToStaticPoint; // Current distance to the static point

        // Is true if static point is in some hill
        bool isPointInHill = (noiseMap[staticPointX, this.staticPointY] > height); 

        for (int y = staticPointY - radius; y < staticPointY + radius; y++)
        {
            for (int x = staticPointX - radius; x < staticPointX + radius; x++)
            {
                if (x >= 0 && y >= 0 && x <= mapWidth && y <= mapHeight)
                {
                    if (x != staticPointX || y != staticPointY) // if is not static point
                    {
                        if (!isPointInHill)
                        {
                            // Value of parabola calculated by formula "a - c * x^2"
                            valueAfterChanges = height - (height / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY)); 
                            valueBeforeChanges = noiseMap[x, y];
                            currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                            if (valueAfterChanges > valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                        }
                        else
                        {
                            if (height != minMapValue)
                            {
                                valueAfterChanges = height + (height / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));
                                valueBeforeChanges = noiseMap[x, y];
                                currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                                if (valueAfterChanges < valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                            }
                            else
                            {
                                valueAfterChanges = height + ((maxMapValue / 1.5f - height) / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));
                                valueBeforeChanges = noiseMap[x, y];
                                currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                                if (valueAfterChanges < valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                            }                            
                        }
                    }
                }
            }
        }

        noiseMap[this.staticPointX, this.staticPointY] = height;
    }

    // Fill array "colorMap" according to "noiseMap[,]" values and "regions[]" parameters
    private void fillColorMap(float[,] noiseMap)
    {
        if (drawMode == DrawMode.ColorMap || drawMode == DrawMode.Mesh)
        {
            colorMap = new Color[mapWidth * mapHeight];
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
        }
    }

    public void generateMap()
    {
        float[,] noiseMap = Noise.generateNoiseMap(seed, mapWidth, mapHeight, 
        octaves, persistance, lacunarity, noiseScale, offset);

        // Here you can assign values of static point by hand
        staticPointX = 49;
        staticPointY = 49;
        staticPointHeight = 0.424242f;
        staticPointRadius = 20;
        changeNoiseMapToFitStaticPoint(noiseMap, staticPointX, staticPointY, staticPointHeight, staticPointRadius);

        fillColorMap(noiseMap);

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
        else if (drawMode == DrawMode.Mesh)
        {
            display.DrawMesh
            (
                MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), 
                TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight)
            );
        }
        else if (drawMode == DrawMode.Table)
        {
            tableUI.scrollbarHorizontal.value = 0;
            tableUI.scrollbarVertical.value = 0;

            tableUI.scrollbarHorizontal.numberOfSteps = 5000;
            tableUI.scrollbarVertical.numberOfSteps = 5000;

            tableUI.assignValuesToCells(noiseMap);
        }
        Resources.UnloadUnusedAssets();
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
    public float height;
    public Color color;
}
