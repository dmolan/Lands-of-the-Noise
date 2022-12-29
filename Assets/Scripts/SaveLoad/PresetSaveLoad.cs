/*
 * This code is executed only at the runtime.
 * Functions used by the buttons in the "File" Canvas: "Save" from Preset submenu and "Load" from Preset submenu.
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SFB;

public class PresetSaveLoad : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public CameraControls cameraControls;
    public AppUI appUI;

    public Slider sliderPersistance, sliderLacunarity, sliderScale, sliderOffsetSpeed, sliderOctaves;
    public TMP_InputField inputFieldMapWidth, inputFieldMapHeight, inputFieldSeed, inputFieldMeshHeightMultiplier;
    public TMP_Dropdown drawMode;

    public TMP_InputField inputFieldDefaultDistanceToMap, inputFieldDefaultAngleOfView, inputFieldRotationSensitivity, 
    inputFieldZoomingSensitivity, inputFieldRotationSmoothTime, inputFieldDistanceLerpTime;



    // Saves Preset to ".txt" file (most of the MapGenerator and CameraControls classes parameters)
    public void savePreset()
    {
        var extensionList = new [] {
            new ExtensionFilter("Text", "txt"),
        };
        
        string saveFilePath = StandaloneFileBrowser.SaveFilePanel("Save Preset as TXT", "", "Preset", extensionList);
        
        if (string.IsNullOrEmpty(saveFilePath) == false)
        {
            string mapData = 
            // MapGenerator parameters
            "SaveMode: " + "Default" + '\r' + '\n' +
            "DrawMode: " + mapGenerator.drawMode + '\r' + '\n' +
            "Seed: " + mapGenerator.seed + '\r'  + '\n' +
            "Width: " + mapGenerator.mapWidth + '\r'  + '\n' + 
            "Height: " + mapGenerator.mapHeight + '\r'  + '\n' + 
            "Octaves: " + mapGenerator.octaves + '\r'  + '\n' +
            "Persistance: " + mapGenerator.persistance + '\r'  + '\n' +
            "Lacunarity: " + mapGenerator.lacunarity + '\r'  + '\n' +
            "NoiseScale: " + mapGenerator.noiseScale + '\r'  + '\n' +
            "OffsetX: " + mapGenerator.offset.x + '\r'  + '\n' +
            "OffsetY: " + mapGenerator.offset.y + '\r'  + '\n' +
            "OffsetSpeed: " + mapGenerator.offsetSpeed + '\r'  + '\n' +
            "MeshHeightMultiplier: " + mapGenerator.meshHeightMultiplier + '\r' + '\n' +
            
            // CameraControls parameters
            "CurrentDistanceToMap: " + cameraControls.currentDistanceToMap + '\r' + '\n' + 
            "DefaultDistanceToMap: " + cameraControls.defaultDistanceToMap + '\r' + '\n' + 
            "DeafultAngleOfView: " + cameraControls.deafultAngleOfView + '\r' + '\n' + 
            "RotationSensitivity: " + cameraControls.rotationSensitivity + '\r' + '\n' + 
            "ZoomingSensitivity: " + cameraControls.zoomingSensitivity + '\r' + '\n' + 
            "RotationSmoothTime: " + cameraControls.rotationSmoothTime + '\r' + '\n' + 
            "DistanceLerpTime: " + cameraControls.distanceLerpTime + '\r' + '\n' + 
            "RotationX: " + cameraControls.rotationX + '\r' + '\n' + 
            "RotationY: " + cameraControls.rotationY % 360f  + '\r' + '\n' + '\n';
            
            System.IO.File.WriteAllText(saveFilePath, mapData);
        }
    }

    // Loads Preset from ".txt" file (most of the MapGenerator and CameraControls classes parameters)
    public void loadPreset()
    {
        string loadFilePath = "";

        // OpenFilePanel returns array of string, we take only the first element of it if something was choosen
        string[] loadFilePathes = StandaloneFileBrowser.OpenFilePanel("Load Preset from TXT", "", "", false);
        if (loadFilePathes.Length > 0) loadFilePath = loadFilePathes[0];

        if (string.IsNullOrEmpty(loadFilePath) == false)
        {
            string mapData = System.IO.File.ReadAllText(loadFilePath);

            // Splits readed text into array of string by spaces and new line characters, e.g.
            // strNumbers[0] - "SaveMode:"
            // strNumbers[1] - "Default"
            // strNumbers[2] - ""
            // strNumbers[3] - "DrawMode:"
            // strNumbers[4] - "NoiseMap" 
            // strNumbers[5] - ""
            // ...
            string[] splittedMapData = mapData.Split();

            if (splittedMapData[1] == "Default")
            {
                // SetValueWithoutNotify - basically just set desired Dropdown option
                if (splittedMapData[4] == "NoiseMap") 
                {
                    appUI.changeDrawMode(0);
                    drawMode.SetValueWithoutNotify(0);
                }
                else if (splittedMapData[4] == "ColorMap") 
                {
                    appUI.changeDrawMode(1);
                    drawMode.SetValueWithoutNotify(1);
                }
                else
                {
                    appUI.changeDrawMode(2);
                    drawMode.SetValueWithoutNotify(2);
                }

                // These are temporary variables as some of them might not be assigned from parsing, 
                // thus none will be assigned to real values (from MapGenerator and CameraControls classes)
                int newSeed = 0, newMapWidth = 0, newMapHeight = 0, newOctaves = 0;
                float newPersistance = 0, newLacunarity = 0, newNoiseScale = 0, newMeshHeightMultiplier = 0, offsetSpeed = 0;
                Vector2 newOffset = new Vector2();
                Vector2 newRotation = new Vector2();
                float newCurrentDistanceToMap = 0, newDefaultDistanceToMap = 0, newDeafultAngleOfView = 0, newRotationSensitivity = 0, 
                newZoomingSensitivity = 0, newRotationSmoothTime = 0, newDistanceLerpTime = 0;

                // This part parses string into values and makes a variable, which shows if all parses were succesful
                // + 3 every time because there are 1 text and 1 '\n' symbol, so next item for i is i+3
                bool isAllParsed = 
                int.TryParse(splittedMapData[7], out newSeed) &&
                int.TryParse(splittedMapData[10], out newMapWidth) && 
                int.TryParse(splittedMapData[13], out newMapHeight) && 
                int.TryParse(splittedMapData[16], out newOctaves) && 
                float.TryParse(splittedMapData[19], out newPersistance) && 
                float.TryParse(splittedMapData[22], out newLacunarity) && 
                float.TryParse(splittedMapData[25], out newNoiseScale) && 
                float.TryParse(splittedMapData[28], out newOffset.x) && 
                float.TryParse(splittedMapData[31], out newOffset.y) && 
                float.TryParse(splittedMapData[34], out offsetSpeed) && 
                float.TryParse(splittedMapData[37], out newMeshHeightMultiplier) &&

                float.TryParse(splittedMapData[40], out newCurrentDistanceToMap) &&
                float.TryParse(splittedMapData[43], out newDefaultDistanceToMap) &&
                float.TryParse(splittedMapData[46], out newDeafultAngleOfView) &&
                float.TryParse(splittedMapData[49], out newRotationSensitivity) &&
                float.TryParse(splittedMapData[52], out newZoomingSensitivity) &&
                float.TryParse(splittedMapData[55], out newRotationSmoothTime) &&
                float.TryParse(splittedMapData[58], out newDistanceLerpTime) &&
                float.TryParse(splittedMapData[61], out newRotation.x) &&
                float.TryParse(splittedMapData[64], out newRotation.y);

                // If all succesfully parsed, set values and UI to new values
                if (isAllParsed)
                {
                    // Set Map Generator parameters
                    mapGenerator.seed = newSeed;
                    mapGenerator.mapWidth = newMapWidth;
                    mapGenerator.mapHeight = newMapHeight;
                    mapGenerator.octaves = newOctaves;
                    mapGenerator.persistance = newPersistance;
                    mapGenerator.lacunarity = newLacunarity;
                    mapGenerator.noiseScale = newNoiseScale;
                    mapGenerator.offset.x = newOffset.x;
                    mapGenerator.offset.y = newOffset.y;
                    mapGenerator.offsetSpeed = offsetSpeed;
                    mapGenerator.meshHeightMultiplier = newMeshHeightMultiplier;

                    // Set Camera Controls parameters
                    cameraControls.nextDistance = newCurrentDistanceToMap;
                    cameraControls.defaultDistanceToMap = newDefaultDistanceToMap;
                    cameraControls.deafultAngleOfView = newDeafultAngleOfView;
                    cameraControls.rotationSensitivity = newRotationSensitivity;
                    cameraControls.zoomingSensitivity = newZoomingSensitivity;
                    cameraControls.rotationSmoothTime = newRotationSmoothTime;
                    cameraControls.distanceLerpTime = newDistanceLerpTime;
                    cameraControls.rotationX = newRotation.x;
                    cameraControls.rotationY = newRotation.y;

                    // Set UI to new values
                    sliderOctaves.value = mapGenerator.octaves;
                    sliderPersistance.value = mapGenerator.persistance;
                    sliderLacunarity.value = mapGenerator.lacunarity;
                    sliderScale.value = mapGenerator.noiseScale;
                    sliderOffsetSpeed.value = mapGenerator.offsetSpeed;
                    inputFieldMapWidth.text = mapGenerator.mapWidth.ToString();
                    inputFieldMapHeight.text = mapGenerator.mapHeight.ToString();
                    inputFieldSeed.text = mapGenerator.seed.ToString();
                    inputFieldMeshHeightMultiplier.text = mapGenerator.meshHeightMultiplier.ToString();
                    inputFieldDefaultDistanceToMap.text = cameraControls.nextDistance.ToString(); 
                    inputFieldDefaultAngleOfView.text = cameraControls.deafultAngleOfView.ToString();
                    inputFieldRotationSensitivity.text = cameraControls.rotationSensitivity.ToString();
                    inputFieldZoomingSensitivity.text = cameraControls.zoomingSensitivity.ToString();
                    inputFieldRotationSmoothTime.text = cameraControls.rotationSmoothTime.ToString(); 
                    inputFieldDistanceLerpTime.text = cameraControls.distanceLerpTime.ToString();

                    // Regenerate map with new values (new values are already set)
                    mapGenerator.generateMap();
                }
                else
                {
                    Debug.Log("Failed to parse data from Preset");
                }
            }
        }
    }
}
