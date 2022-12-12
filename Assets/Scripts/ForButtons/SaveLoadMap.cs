/*
 *  This code is executed only at the runtime.
 *  Functions used by the buttons in the App: "SaveFile" and "LoadFile".
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SFB;

public class SaveLoadMap : MonoBehaviour
{
    public MapGenerator mapGen;
    public AppUI appUI;

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
        var extensionList = new [] {
            new ExtensionFilter("Text", "txt"),
        };

        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save map as TXT", "", "mapSave", extensionList);
        
        if (saveFilePath.Length != 0)
        {
            // Regenerating Noise Map to save it
            float[,] noiseMap = mapGen.getNoiseMap();

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
            
            for (short x = 0; x < mapGen.mapWidth; ++x)
            {
                for (short y = 0; y < mapGen.mapHeight; ++y)
                {
                    mapData += noiseMap[x, y] + " ";
                }
                mapData += "\r\n";
            }
            System.IO.File.WriteAllText(saveFilePath, mapData);
        }
    }

    public void loadMap()
    {
        string loadFilePath = StandaloneFileBrowser.OpenFilePanel("Load a map from TXT", "", "", false)[0];

        if (loadFilePath.Length != 0)
        {
            string mapData = System.IO.File.ReadAllText(loadFilePath);
            string[] strNumbers = mapData.Split();
            
            if (strNumbers[1] == "Default")
            {
                if (strNumbers[4] == "NoiseMap") 
                {
                    appUI.changeDrawMode(0);
                    DrawMode.SetValueWithoutNotify(0);
                }
                else if (strNumbers[4] == "ColorMap") 
                {
                    appUI.changeDrawMode(1);
                    DrawMode.SetValueWithoutNotify(1);
                }
                else
                {
                    appUI.changeDrawMode(2);
                    DrawMode.SetValueWithoutNotify(2);
                }
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

                mapGen.generateMap();
            }
        }
    }
}
