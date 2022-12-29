/*
 *  By the given Noise Map generates Color Map, calls Texture- and Mesh Generators and
 *  gives results to MapDisplay.
 *  Also manages map parameters changing.
*/
using Boo.Lang.Runtime.DynamicDispatching;
using System;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public AppUI appUI;
    public TableUI tableUI;

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

    public int staique_pointX;
    public int staique_pointY;
    public float staique_point_hight;
    public int staique_point_radius; // radius of statice hill



    void Start()
    {


        appUI.changeDrawMode(2);

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
    public void Genarate_statique_point(float[,] noiseMap, int statice_point_x, int statice_point_y, float hight, int radius)
    {
        float cur_curv_val; //curent valu of parabola
        float cur_map_val;  // curent valu on map befor chages
        float cur_distance; // curent distance to the centr of aver popabola or to the statoce point

        bool is_in_something = (noiseMap[statice_point_x, staique_pointY]>hight); // is true if statice point is in some hill


        for(int y_ind = statice_point_y - radius; y_ind < statice_point_y + radius; y_ind++)
            for (int x_ind = statice_point_x - radius; x_ind < statice_point_x + radius; x_ind++)
            if (x_ind >= 0 && y_ind >= 0 && x_ind<= mapWidth && y_ind<=mapHeight)
            {
                    if (x_ind != statice_point_x || y_ind != statice_point_y) // if is not static point
                    {
                        if(!is_in_something)
                        {
                            cur_curv_val = hight - (hight / (radius * radius)) * ((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y)); // value of parabola a-cx^2
                            cur_map_val = noiseMap[x_ind, y_ind];
                            cur_distance = (float)Math.Sqrt((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y));

                            if (cur_curv_val > cur_map_val) noiseMap[x_ind, y_ind] = cur_curv_val;
                        }else
                        {
                            if(hight!= minMapValue)
                            {
                                cur_curv_val = hight + (hight / (radius * radius)) * ((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y));
                                cur_map_val = noiseMap[x_ind, y_ind];
                                cur_distance = (float)Math.Sqrt((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y));

                                if (cur_curv_val < cur_map_val) noiseMap[x_ind, y_ind] = cur_curv_val;
                            }else
                            {
                                cur_curv_val = hight + ((maxMapValue/1.5f-hight) / (radius * radius)) * ((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y));
                                cur_map_val = noiseMap[x_ind, y_ind];
                                cur_distance = (float)Math.Sqrt((x_ind - statice_point_x) * (x_ind - statice_point_x) + (y_ind - statice_point_y) * (y_ind - statice_point_y));

                                if (cur_curv_val < cur_map_val) noiseMap[x_ind, y_ind] = cur_curv_val;
                            }
                                                      
                        }

                    }
            }

        noiseMap[staique_pointX, staique_pointY] = hight;
    }
    public void generateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(seed, mapWidth, mapHeight, 
        octaves, persistance, lacunarity, noiseScale, offset);

        Genarate_statique_point(noiseMap, staique_pointX, staique_pointY, staique_point_hight, staique_point_radius);

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

    public float defaultHeight;
}
