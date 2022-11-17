using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class SaveMap : MonoBehaviour
{
    public MapGenerator mapGen;
    public Slider sliderPersistance;
    public Slider sliderLacunarity;
    public Slider sliderScale;
    public Slider sliderOctaves;
    public TMP_InputField InputFieldWidth;
    public TMP_InputField InputFieldHeight;
    public TMP_InputField InputFieldSeed;
    public TMP_InputField InputFieldMultiplier;
    public TMP_Dropdown DrawMode;



    public void saveCurrentMap()
    {
        string savePath = EditorUtility.SaveFilePanel("Save map as TXT", "", "mapSave" + ".txt", "txt");
        if (savePath.Length != 0)
        {
            float[,] noiseMap = mapGen.GetNoiseMap();
            Pair<int, int> widthHeight = mapGen.getMapWidthHeight();

            string mapData = 
            "SaveMode: " + "Default" + '\r' + '\n' +
            "DrawMode: " + mapGen.drawMode + '\r' + '\n' +
            "Seed: " + mapGen.seed + '\r'  + '\n' +
            "Width: " + mapGen.mapWidth + '\r'  + '\n' + 
            "Height: " + mapGen.mapHeight + '\r'  + '\n' + 
            "Octaves: " + mapGen.octaves + '\r'  + '\n' +
            "Persistance: " + mapGen.persistance + '\r'  + '\n' +
            "Lacunarity: " + mapGen.lacunarity + '\r'  + '\n' +
            "NoiseScale: " + mapGen.noiseScale + '\r'  + '\n' +
            "OffsetX: " + mapGen.offset.x + '\r'  + '\n' +
            "OffsetY: " + mapGen.offset.y + '\r'  + '\n' +
            "MeshHeightMultiplier: " + mapGen.meshHeightMultiplier + '\r' + '\n';
            
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
                if (strNumbers[4] == "NoiseMap") mapGen.drawMode = MapGenerator.DrawMode.NoiseMap;
                else if (strNumbers[4] == "ColourMap") mapGen.drawMode = MapGenerator.DrawMode.ColourMap;
                else if (strNumbers[4] == "Mesh") mapGen.drawMode = MapGenerator.DrawMode.Mesh;
                mapGen.seed = int.Parse(strNumbers[7]);
                mapGen.mapWidth = int.Parse(strNumbers[10]);
                mapGen.mapHeight = int.Parse(strNumbers[13]);
                mapGen.octaves = int.Parse(strNumbers[16]);
                mapGen.persistance = float.Parse(strNumbers[19]);
                mapGen.lacunarity = float.Parse(strNumbers[22]);
                mapGen.noiseScale = float.Parse(strNumbers[25]);
                mapGen.offset.x = float.Parse(strNumbers[28]);
                mapGen.offset.y = float.Parse(strNumbers[31]);

                sliderOctaves.value = mapGen.octaves;
                sliderPersistance.value = mapGen.persistance;
                sliderLacunarity.value = mapGen.lacunarity;
                sliderScale.value = mapGen.noiseScale;

                InputFieldWidth.text = mapGen.mapWidth.ToString();
                InputFieldHeight.text = mapGen.mapHeight.ToString();
                InputFieldSeed.text = mapGen.seed.ToString();
                InputFieldMultiplier.text = mapGen.meshHeightMultiplier.ToString();

                mapGen.GenerateMap();
            }
        }

    }
}
