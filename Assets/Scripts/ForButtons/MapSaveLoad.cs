/*
 *  This code is executed only at the runtime.
 *  Functions used by the buttons in the "File" Canvas: "Save" from Map submenu and "Load" from Map submenu.
*/
// using System.Drawing;
// using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SFB;

public class MapSaveLoad : MonoBehaviour
{
    // For fast addition of spaces by substringing from here
    const string SPACES = "                    ";

    public MapGenerator mapGenerator;

    public Slider sliderPersistance;
    public TMP_InputField inputFieldMapWidth, inputFieldMapHeight, inputFieldMinMapValue, inputFieldMaxMapValue;



    private string convertFloatToStrForFile(float num)
    {
        // Max "num": -123456789.12345678
        // "F8" parameter sets fixed number of digits after floating point 
        // e.g. "321.123456" -> "321.12345600"
        string s = num.ToString("F8");
        s += SPACES.Substring(0, 19 - s.Length);

        return s;
    }

    // Saves Map values to ".txt" file via regenerating it by current parameters
    public void saveMap()
    {
        var extensionList = new [] {
            new ExtensionFilter("Text", "txt"),
        };

        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save Map as TXT", "", "MapValues", extensionList);
        
        if (string.IsNullOrEmpty(saveFilePath) == false)
        {
            // Regenerating Noise Map to save it
            float[,] noiseMap = mapGenerator.getNoiseMap();
            string mapData = "";

            if (mapGenerator.minMapValue != 0f || mapGenerator.maxMapValue != 1f)
            {
                float deltaMinMax = mapGenerator.maxMapValue - mapGenerator.minMapValue;
                for (short x = 0; x < mapGenerator.mapWidth; ++x)
                {
                    for (short y = 0; y < mapGenerator.mapHeight; ++y)
                    {
                        mapData += convertFloatToStrForFile(noiseMap[x, y] * deltaMinMax + mapGenerator.minMapValue) + '\t';
                    }
                    mapData += "\r\n";
                }
            }
            else
            {
                for (short x = 0; x < mapGenerator.mapWidth; ++x)
                {
                    for (short y = 0; y < mapGenerator.mapHeight; ++y)
                    {
                        mapData += convertFloatToStrForFile(noiseMap[x, y]) + '\t';
                    }
                    mapData += "\r\n";
                }
            }
            System.IO.File.WriteAllText(saveFilePath, mapData);
        }
    }

    // Loads Map parametrs from ".txt" file (those, which are given in the problem)
    public void loadMap()
    {
        string loadFilePath = "";
        string[] loadFilesPathes = StandaloneFileBrowser.OpenFilePanel("Load Map from TXT", "", "", false);
        if (loadFilesPathes.Length > 0) loadFilePath = loadFilesPathes[0];

        if (string.IsNullOrEmpty(loadFilePath) == false)
        {
            string mapData = System.IO.File.ReadAllText(loadFilePath);
            string[] arrayOfParametrs = mapData.Split();

            // This is the variable names, which are given in the task
            int sizeX = 0, sizeY = 0, minZ = 0, maxZ = 0;
            float H = 0;

            bool isAllParsed = 
            int.TryParse(arrayOfParametrs[0], out sizeX) == true &&
            int.TryParse(arrayOfParametrs[2], out sizeY) == true &&
            int.TryParse(arrayOfParametrs[4], out minZ) == true &&
            int.TryParse(arrayOfParametrs[6], out maxZ) == true &&
            float.TryParse(arrayOfParametrs[8], out H) == true;

            // If all values are succesfully parsed, set values and UI to new values
            if (isAllParsed)
            {
                mapGenerator.mapWidth = sizeX;
                mapGenerator.mapHeight = sizeY;
                mapGenerator.minMapValue = minZ;
                mapGenerator.maxMapValue = maxZ;
                
                if (H < 0) H = Mathf.Abs(H);
                if (H > 1) H = 1;
                mapGenerator.persistance = H;

                inputFieldMapWidth.text = mapGenerator.mapWidth.ToString();
                inputFieldMapHeight.text = mapGenerator.mapHeight.ToString();
                inputFieldMinMapValue.text = mapGenerator.minMapValue.ToString();
                inputFieldMaxMapValue.text = mapGenerator.maxMapValue.ToString();
                sliderPersistance.value = mapGenerator.persistance;

                mapGenerator.generateMap();
            }
            else
            {
                Debug.Log("Wrong file format!");
            }
        }
    }

    public void saveMapToPNG()
    {
        // Might not be used, but must be assigned in this scope for "MapGenerator.TextureFromColorMap()"
        UnityEngine.Color[] colorMap = new UnityEngine.Color[mapGenerator.mapWidth * mapGenerator.mapHeight];

        var extensionList = new [] {
            new ExtensionFilter("Image", "png"),
        };

        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save Map as PNG", "", "ImageOfMapPNG", extensionList);

        if (string.IsNullOrEmpty(saveFilePath) == false)
        {
            // By default the texture is white
            Texture2D texture = Texture2D.whiteTexture;
            float[,] noiseMap = mapGenerator.getNoiseMap();

            // Fill ColorMap if needed
            if (mapGenerator.drawMode == MapGenerator.DrawMode.ColorMap || mapGenerator.drawMode == MapGenerator.DrawMode.Mesh)
            {
                for (int y = 0; y < mapGenerator.mapHeight; ++y)
                {
                    for (int x = 0; x < mapGenerator.mapWidth; ++x)
                    {
                        float currentHeight = noiseMap[x, y];
                        for (int i = 0; i < mapGenerator.regions.Length; ++i)
                        {
                            if (currentHeight <= mapGenerator.regions[i].height)
                            {
                                colorMap[y*mapGenerator.mapWidth + x] = mapGenerator.regions[i].color;
                                break;
                            }
                        }
                    }
                }
            }

            if (mapGenerator.drawMode == MapGenerator.DrawMode.NoiseMap || mapGenerator.drawMode == MapGenerator.DrawMode.Table)
            {
                texture = TextureGenerator.TextureFromHeightMap(noiseMap);
            }
            else if (mapGenerator.drawMode == MapGenerator.DrawMode.ColorMap || mapGenerator.drawMode == MapGenerator.DrawMode.Mesh)
            {
                texture = TextureGenerator.TextureFromColorMap(colorMap, mapGenerator.mapWidth, mapGenerator.mapHeight);
            }

            byte[] imageData = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(saveFilePath, imageData);

            // Deletes the texture after usage
            Resources.UnloadUnusedAssets();
        }
    }

    public void saveMapToBMP()
    {
        // Might not be used, but must be assigned in this scope for "MapGenerator.TextureFromColorMap()"
        UnityEngine.Color[] colorMap = new UnityEngine.Color[mapGenerator.mapWidth * mapGenerator.mapHeight];

        var extensionList = new [] {
            new ExtensionFilter("Image", "bmp"),
        };

        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save Map as BMP", "", "ImageOfMapBMP", extensionList);

        if (string.IsNullOrEmpty(saveFilePath) == false)
        {
            // By default the texture is white
            Texture2D texture = Texture2D.whiteTexture;
            float[,] noiseMap = mapGenerator.getNoiseMap();

            // Fill ColorMap if needed
            if (mapGenerator.drawMode == MapGenerator.DrawMode.ColorMap || mapGenerator.drawMode == MapGenerator.DrawMode.Mesh)
            {
                for (int y = 0; y < mapGenerator.mapHeight; ++y)
                {
                    for (int x = 0; x < mapGenerator.mapWidth; ++x)
                    {
                        float currentHeight = noiseMap[x, y];
                        for (int i = 0; i < mapGenerator.regions.Length; ++i)
                        {
                            if (currentHeight <= mapGenerator.regions[i].height)
                            {
                                colorMap[y*mapGenerator.mapWidth + x] = mapGenerator.regions[i].color;
                                break;
                            }
                        }
                    }
                }
            }

            if (mapGenerator.drawMode == MapGenerator.DrawMode.NoiseMap || mapGenerator.drawMode == MapGenerator.DrawMode.Table)
            {
                texture = TextureGenerator.TextureFromHeightMap(noiseMap);
            }
            else if (mapGenerator.drawMode == MapGenerator.DrawMode.ColorMap || mapGenerator.drawMode == MapGenerator.DrawMode.Mesh)
            {
                texture = TextureGenerator.TextureFromColorMap(colorMap, mapGenerator.mapWidth, mapGenerator.mapHeight);
            }

            // byte[] imageData = texture.EncodeToPNG();

            // TODO: IMPLEMENT BMP FILE SAVING!
            /*
            Bitmap bmp;
            using (var ms = new MemoryStream(imageData))
            {
                bmp = new Bitmap(ms);
                bmp.Save(saveFilePath);
            }
            */

            // Deletes the texture after usage
            // Resources.UnloadUnusedAssets();
        }
    }
}
