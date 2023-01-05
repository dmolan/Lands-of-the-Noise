/*
 * By the given Noise Map generates Color Map, calls Texture- and Mesh Generators and
 * gives results to MapDisplay.
 * Also manages map parameters changing.
 */

using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public const int STATIC_POINT_RADIUS = 10;

    public AppUI appUI;
    public TableUI tableUI;
    public HowDoesItWorkPages howDoesItWorkPages;
    public HowToUsePages howToUsePages;
    public LanguagesForText languagesForText;
    public Config config;
    public VisualParameters visualParameters;

    public enum DrawMode { NoiseMap, ColorMap, Mesh, Table };
    public DrawMode drawMode;

    public int seed;
    
    public float[,] noiseMap;
    
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

    public bool autoUpdate;

    public TerrainType[] regions;
    public float minMapValue, maxMapValue;

    public float probabilityOfPlain = 0f;
    public bool isPlainProbabilitySliderTurnedOn = false;

    public float probabilityOfGorge = 1f;
    public bool isGorgeProbabilitySliderTurnedOn = false;

    static Color[] colorMap;
    public StaticPoint[] staticPoints = new StaticPoint[0];



    // Starting point of the App
    void Start()
    {
        howToUsePages.setSlide(howToUsePages.currSlide);
        howDoesItWorkPages.setSlide(howDoesItWorkPages.currentSlide);
        
        appUI.changeDrawMode(2);
        languagesForText.changeLanguage(languagesForText.DEFAULT_LANGUAGE);
        config.configStart();
    }

    public void changeNoiseMapToFitStaticPoint(float[,] noiseMap, int staticPointX, int staticPointY, float staticPointHeight, int radius)
    {
        // If some parameters are wrong, don't change "noiseMap[,]"
        if (staticPointX < 0 || staticPointX > mapWidth 
        || staticPointY < 0 || staticPointY > mapHeight 
        || staticPointHeight < 0 && staticPointHeight > 1) return;

        float valueAfterChanges; // Current value of parabola
        float valueBeforeChanges;  // Current value on map before chages
        float currentDistanceToStaticPoint; // Current distance to the static point

        // Is true if static point is in some hill
        bool isPointInHill = (noiseMap[staticPointX, staticPointY] > staticPointHeight); 

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
                            valueAfterChanges = staticPointHeight - (staticPointHeight / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY)); 
                            valueBeforeChanges = noiseMap[x, y];
                            currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                            if (valueAfterChanges > valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                        }
                        else
                        {
                            if (staticPointHeight != minMapValue)
                            {
                                valueAfterChanges = staticPointHeight + (staticPointHeight / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));
                                valueBeforeChanges = noiseMap[x, y];
                                currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                                if (valueAfterChanges < valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                            }
                            else
                            {
                                valueAfterChanges = staticPointHeight + ((maxMapValue / 1.5f - staticPointHeight) / (radius * radius)) * ((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));
                                valueBeforeChanges = noiseMap[x, y];
                                currentDistanceToStaticPoint = (float)Math.Sqrt((x - staticPointX) * (x - staticPointX) + (y - staticPointY) * (y - staticPointY));

                                if (valueAfterChanges < valueBeforeChanges) noiseMap[x, y] = valueAfterChanges;
                            }                            
                        }
                    }
                }
            }
        }

        noiseMap[staticPointX, staticPointY] = staticPointHeight;
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
    
    public void visualiseMap()
    {
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
            tableUI.setupTableUI();
            tableUI.assignValuesToCells(noiseMap);
        }
        Resources.UnloadUnusedAssets();
    }

    public void generateMap()
    {
        noiseMap = Noise.generateNoiseMap(seed, mapWidth, mapHeight, 
        octaves, persistance, lacunarity, noiseScale, offset);

        for (int i = 0; i < staticPoints.Length; ++i)
        {
            changeNoiseMapToFitStaticPoint(noiseMap, staticPoints[i].x, staticPoints[i].y, staticPoints[i].height, STATIC_POINT_RADIUS);
        }

        if (isPlainProbabilitySliderTurnedOn)
        {
            visualParameters.newGeneratePlain(0, 0, mapWidth, mapHeight, noiseMap, probabilityOfPlain);
        }

        if (isGorgeProbabilitySliderTurnedOn)
        {
            visualParameters.generateGorge(0, 0, mapWidth, mapHeight, noiseMap, probabilityOfGorge);
        }
        
        visualiseMap();
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

public struct StaticPoint
{
    public int x, y;
    public float height;

    // public StaticPoint()
    // {
    //     x = 0;
    //     y = 0;
    // }

    // public StaticPoint(int xVal, int yVal, float heightValue)
    // {
    //     x = xVal;
    //     y = yVal;
    //     height = heightValue;
    // }
}