/*
 *  By the given Noise Map generates Color Map, calls Texture- and Mesh Generators and
 *  gives results to MapDisplay.
 *  Also manages map parameters changing.
*/
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColorMap, Mesh};
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



    void Start()
    {
        // This is needed because for some reason Unity ignores default values assigned to variables
        minMapValue = 0f;
        maxMapValue = 1f;
    }

    public float[,] getNoiseMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(seed, mapWidth, mapHeight, 
        octaves, persistance, lacunarity, noiseScale, offset);
        
        return noiseMap;
    }

    static Color[] colorMap;
    public void generateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(seed, mapWidth, mapHeight, 
        octaves, persistance, lacunarity, noiseScale, offset);

        if (drawMode != DrawMode.NoiseMap)
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

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.NoiseMap)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap)
        {
            // THIS "IF" IS DEPRECATED, WATER LEVEL ISN'T ACCESIBLE IN THE APP
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
            display.DrawMesh
            (
                MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), 
                TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight)
            );
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

    public float defaultHeight;
}
