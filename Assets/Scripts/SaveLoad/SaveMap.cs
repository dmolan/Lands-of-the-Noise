using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveMap : MonoBehaviour
{
    public MapGenerator mapGen;

    public void saveCurrentMap()
    {
        string savePath = EditorUtility.SaveFilePanel("Save map as TXT", "", "mapSave" + ".txt", "txt");
        if (savePath.Length != 0)
        {
            float[,] noiseMap = mapGen.GetNoiseMap();
            Pair<int, int> widthHeight = mapGen.getMapWidthHeight();

            string mapData = 
            "SaveMode: " + "Default" + '\r' + '\n' +
            "Seed: " + mapGen.seed + '\r'  + '\n' +
            "Width: " + mapGen.mapWidth + '\r'  + '\n' + 
            "Height: " + mapGen.mapHeight + '\r'  + '\n' + 
            "Octaves: " + mapGen.octaves + '\r'  + '\n' +
            "Persistance: " + mapGen.persistance + '\r'  + '\n' +
            "Lacunarity: " + mapGen.lacunarity + '\r'  + '\n' +
            "NoiseScale: " + mapGen.noiseScale + '\r'  + '\n' +
            "OffsetX: " + mapGen.offset.x + '\r'  + '\n' +
            "OffsetY: " + mapGen.offset.y + '\r'  + '\n';
            
            for (int x = 0; x < widthHeight.First; ++x)
            {
                for (int y = 0; y < widthHeight.Second; ++y)
                {
                    mapData += noiseMap[x, y] + " ";
                }
                mapData += '\r' + '\n';
            }
            System.IO.File.WriteAllText(savePath, mapData);
        }
    }
    public void loadMap()
    {
        string loadPath = EditorUtility.OpenFilePanel("Load a map from TXT", "", "txt");
        if (loadPath.Length != 0)
        {
            string mapData = System.IO.File.ReadAllText(loadPath);  
            string[] strNumbers = mapData.Split();
            
            if (strNumbers[1] == "Default")
            {
                mapGen.seed = int.Parse(strNumbers[4]);
                mapGen.mapWidth = int.Parse(strNumbers[7]);
                mapGen.mapHeight = int.Parse(strNumbers[10]);
                mapGen.octaves = int.Parse(strNumbers[13]);
                mapGen.persistance = float.Parse(strNumbers[16]);
                mapGen.lacunarity = float.Parse(strNumbers[19]);
                mapGen.noiseScale = float.Parse(strNumbers[22]);
                mapGen.offset.x = float.Parse(strNumbers[25]);
                mapGen.offset.y = float.Parse(strNumbers[28]);

                mapGen.GenerateMap();
            }
            // float[,] noiseMap = new float[mapWidth, mapHeight];
            // for (int x = 0; x < mapWidth; ++x)
            // {
            //     for (int y = 0; y < mapHeight; ++y)
            //     {
            //         noiseMap[x,y] = mapData[y * mapHeight + x];
            //     }
            //     mapData += '\n';
            // }
        }

    }
}
