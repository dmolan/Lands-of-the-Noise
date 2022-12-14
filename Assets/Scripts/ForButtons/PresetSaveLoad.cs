/*
 *  This code is executed only at the runtime.
 *  Functions used by the buttons in the App: "SaveFile" and "LoadFile".
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SFB;

public class PresetSaveLoad : MonoBehaviour
{
    public MapGenerator mapGen;
    public CameraControls cameraControls;
    public AppUI appUI;

    public Slider sliderPersistance, sliderLacunarity, sliderScale, sliderOctaves;
    public TMP_InputField inputFieldMapWidth, inputFieldMapHeight, inputFieldSeed, inputFieldMeshHeightMultiplier;
    public TMP_Dropdown drawMode;

    public TMP_InputField inputFieldDefaultDistanceToMap, inputFieldDefaultAngleOfView, inputFieldRotationSensitivity, 
    inputFieldZoomingSensitivity, inputFieldRotationSmoothTime, inputFieldDistanceLerpTime;



    public void saveCurrentMap()
    {
        var extensionList = new [] {
            new ExtensionFilter("Text", "txt"),
        };
        
        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save Preset as TXT", "", "Preset", extensionList);
        
        if (string.IsNullOrEmpty(saveFilePath) == false)
        {
            // Regenerating Noise Map to save it
            float[,] noiseMap = mapGen.getNoiseMap();

            string mapData = 
            // Map Generator parameters
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
            "MeshHeightMultiplier: " + mapGen.meshHeightMultiplier + '\r' + '\n' +
            
            // Camera parameters
            "CurrentDistanceToMap: " + cameraControls.currentDistanceToMap + '\r' + '\n' + 
            "DefaultDistanceToMap: " + cameraControls.defaultDistanceToMap + '\r' + '\n' + 
            "DeafultAngleOfView: " + cameraControls.deafultAngleOfView + '\r' + '\n' + 
            "RotationSensitivity: " + cameraControls.rotationSensitivity + '\r' + '\n' + 
            "ZoomingSensitivity: " + cameraControls.zoomingSensitivity + '\r' + '\n' + 
            "RotationSmoothTime: " + cameraControls.rotationSmoothTime + '\r' + '\n' + 
            "DistanceLerpTime: " + cameraControls.distanceLerpTime + '\r' + '\n' + 
            "RotationX: " + cameraControls.rotationX + '\r' + '\n' + 
            "RotationY: " + cameraControls.rotationY + '\r' + '\n' + '\n';
            
            System.IO.File.WriteAllText(saveFilePath, mapData);
        }
    }

    public void loadMap()
    {
        string loadFilePath = "";
        string[] loadFilePathes = StandaloneFileBrowser.OpenFilePanel("Load Preset from TXT", "", "", false);
        if (loadFilePathes.Length > 0) loadFilePath = loadFilePathes[0];

        if (string.IsNullOrEmpty(loadFilePath) == false)
        {
            string mapData = System.IO.File.ReadAllText(loadFilePath);
            string[] strNumbers = mapData.Split();

            if (strNumbers[1] == "Default")
            {
                if (strNumbers[4] == "NoiseMap") 
                {
                    appUI.changeDrawMode(0);
                    drawMode.SetValueWithoutNotify(0);
                }
                else if (strNumbers[4] == "ColorMap") 
                {
                    appUI.changeDrawMode(1);
                    drawMode.SetValueWithoutNotify(1);
                }
                else
                {
                    appUI.changeDrawMode(2);
                    drawMode.SetValueWithoutNotify(2);
                }

                // This part parses string into values and makes a variable, which shows if all parses were succesful
                // + 3 every time because there are 1 text and 1 '\n' symbol, so next item for i is i+3
                bool isAllParsed = 
                int.TryParse(strNumbers[7], out mapGen.seed) &&
                int.TryParse(strNumbers[10], out mapGen.mapWidth) && 
                int.TryParse(strNumbers[13], out mapGen.mapHeight) && 
                int.TryParse(strNumbers[16], out mapGen.octaves) && 
                float.TryParse(strNumbers[19], out mapGen.persistance) && 
                float.TryParse(strNumbers[22], out mapGen.lacunarity) && 
                float.TryParse(strNumbers[25], out mapGen.noiseScale) && 
                float.TryParse(strNumbers[28], out mapGen.offset.x) && 
                float.TryParse(strNumbers[31], out mapGen.offset.y) && 
                float.TryParse(strNumbers[34], out mapGen.meshHeightMultiplier) &&

                float.TryParse(strNumbers[37], out cameraControls.currentDistanceToMap) &&
                float.TryParse(strNumbers[40], out cameraControls.defaultDistanceToMap) &&
                float.TryParse(strNumbers[43], out cameraControls.deafultAngleOfView) &&
                float.TryParse(strNumbers[46], out cameraControls.rotationSensitivity) &&
                float.TryParse(strNumbers[49], out cameraControls.zoomingSensitivity) &&
                float.TryParse(strNumbers[52], out cameraControls.rotationSmoothTime) &&
                float.TryParse(strNumbers[55], out cameraControls.distanceLerpTime) &&
                float.TryParse(strNumbers[58], out cameraControls.rotationX) &&
                float.TryParse(strNumbers[61], out cameraControls.rotationY);

                if (isAllParsed)
                {
                    sliderOctaves.value = mapGen.octaves;
                    sliderPersistance.value = mapGen.persistance;
                    sliderLacunarity.value = mapGen.lacunarity;
                    sliderScale.value = mapGen.noiseScale;

                    inputFieldMapWidth.text = mapGen.mapWidth.ToString();
                    inputFieldMapHeight.text = mapGen.mapHeight.ToString();
                    inputFieldSeed.text = mapGen.seed.ToString();
                    inputFieldMeshHeightMultiplier.text = mapGen.meshHeightMultiplier.ToString();

                    inputFieldDefaultDistanceToMap.text = cameraControls.currentDistanceToMap.ToString(); 
                    inputFieldDefaultAngleOfView.text = cameraControls.deafultAngleOfView.ToString();
                    inputFieldRotationSensitivity.text = cameraControls.rotationSensitivity.ToString();
                    inputFieldZoomingSensitivity.text = cameraControls.zoomingSensitivity.ToString();
                    inputFieldRotationSmoothTime.text = cameraControls.rotationSmoothTime.ToString(); 
                    inputFieldDistanceLerpTime.text = cameraControls.distanceLerpTime.ToString();

                    mapGen.generateMap();
                }
                else
                {
                    Debug.Log("Failed to parse data from Preset");
                }
            }
        }
    }
}
