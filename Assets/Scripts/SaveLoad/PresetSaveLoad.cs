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

    public Toggle toggleGorge, togglePlain;
    public TMP_InputField inputFieldMaxMapValue, inputFieldMinMapValue;
    public Slider sliderProbabilityOfPlain, sliderProbabilityOfGorge;


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
            "RotationY: " + cameraControls.rotationY % 360f  + '\r' + '\n' + 
            "MaxMapValue: " + mapGenerator.maxMapValue + '\r' + '\n' +
            "MinMapValue: " + mapGenerator.minMapValue + '\r' + '\n' +
            "ProbabilityOfPlain: " + mapGenerator.probabilityOfPlain + '\r' + '\n' +
            "ProbabilityOfGorge: " + mapGenerator.probabilityOfGorge + '\r' + '\n' + 
            "IsPlainTurnedOn: " + togglePlain.isActiveAndEnabled + '\r' + '\n' + 
            "IsGorgeTurnedOn: " + toggleGorge.isActiveAndEnabled + '\r' + '\n' + 
            "PresetColor1r: " + mapGenerator.regions[0].color.r + '\r' + '\n' + 
            "PresetColor1g: " + mapGenerator.regions[0].color.g + '\r' + '\n' + 
            "PresetColor1b: " + mapGenerator.regions[0].color.b + '\r' + '\n' + 

            "PresetColor2r: " + mapGenerator.regions[1].color.r + '\r' + '\n' + 
            "PresetColor2g: " + mapGenerator.regions[1].color.g + '\r' + '\n' + 
            "PresetColor2b: " + mapGenerator.regions[1].color.b + '\r' + '\n' + 

            "PresetColor3r: " + mapGenerator.regions[2].color.r + '\r' + '\n' + 
            "PresetColor3g: " + mapGenerator.regions[2].color.g + '\r' + '\n' + 
            "PresetColor3b: " + mapGenerator.regions[2].color.b + '\r' + '\n' + 

            "PresetColor4r: " + mapGenerator.regions[3].color.r + '\r' + '\n' + 
            "PresetColor4g: " + mapGenerator.regions[3].color.g + '\r' + '\n' + 
            "PresetColor4b: " + mapGenerator.regions[3].color.b + '\r' + '\n' + 

            "PresetColor5r: " + mapGenerator.regions[4].color.r + '\r' + '\n' + 
            "PresetColor5g: " + mapGenerator.regions[4].color.g + '\r' + '\n' + 
            "PresetColor5b: " + mapGenerator.regions[4].color.b + '\r' + '\n' + 

            "PresetColor6r: " + mapGenerator.regions[5].color.r + '\r' + '\n' + 
            "PresetColor6g: " + mapGenerator.regions[5].color.g + '\r' + '\n' + 
            "PresetColor6b: " + mapGenerator.regions[5].color.b + '\r' + '\n' + 

            "PresetColor7r: " + mapGenerator.regions[6].color.r + '\r' + '\n' + 
            "PresetColor7g: " + mapGenerator.regions[6].color.g + '\r' + '\n' + 
            "PresetColor7b: " + mapGenerator.regions[6].color.b + '\r' + '\n' + 

            "PresetColor8r: " + mapGenerator.regions[7].color.r + '\r' + '\n' + 
            "PresetColor8g: " + mapGenerator.regions[7].color.g + '\r' + '\n' + 
            "PresetColor8b: " + mapGenerator.regions[7].color.b + '\r' + '\n' + 
            '\n';
            
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
                float newPersistance = 0, newLacunarity = 0, newNoiseScale = 0, 
                newMeshHeightMultiplier = 0, offsetSpeed = 0, newMaxMapValue = 0, newMinMapValue = 0,
                newPlainProbability = 0, newGorgeProbability = 0;
                float newColor1r = 0, newColor2r = 0, newColor3r = 0, newColor4r = 0, newColor5r = 0, newColor6r = 0, newColor7r = 0, newColor8r = 0;
                float newColor1g = 0, newColor2g = 0, newColor3g = 0, newColor4g = 0, newColor5g = 0, newColor6g = 0, newColor7g = 0, newColor8g = 0;
                float newColor1b = 0, newColor2b = 0, newColor3b = 0, newColor4b = 0, newColor5b = 0, newColor6b = 0, newColor7b = 0, newColor8b = 0;
                bool newIsGorgeTurnedOn = false, newIsPlainTurnedOn = false;
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
                float.TryParse(splittedMapData[64], out newRotation.y) &&

                float.TryParse(splittedMapData[67], out newMaxMapValue) &&
                float.TryParse(splittedMapData[70], out newMinMapValue) &&
                float.TryParse(splittedMapData[73], out newPlainProbability) &&
                float.TryParse(splittedMapData[76], out newGorgeProbability) &&
                bool.TryParse(splittedMapData[79], out newIsPlainTurnedOn) &&
                bool.TryParse(splittedMapData[82], out newIsGorgeTurnedOn) &&
                float.TryParse(splittedMapData[85], out newColor1r) && 
                float.TryParse(splittedMapData[88], out newColor1g) && 
                float.TryParse(splittedMapData[91], out newColor1b) && 

                float.TryParse(splittedMapData[94], out newColor2r) && 
                float.TryParse(splittedMapData[97], out newColor2g) && 
                float.TryParse(splittedMapData[100], out newColor2b) && 

                float.TryParse(splittedMapData[103], out newColor3r) && 
                float.TryParse(splittedMapData[106], out newColor3g) && 
                float.TryParse(splittedMapData[109], out newColor3b) && 

                float.TryParse(splittedMapData[112], out newColor4r) && 
                float.TryParse(splittedMapData[115], out newColor4g) && 
                float.TryParse(splittedMapData[118], out newColor4b) && 

                float.TryParse(splittedMapData[121], out newColor5r) && 
                float.TryParse(splittedMapData[124], out newColor5g) && 
                float.TryParse(splittedMapData[127], out newColor5b) && 

                float.TryParse(splittedMapData[130], out newColor6r) && 
                float.TryParse(splittedMapData[133], out newColor6g) && 
                float.TryParse(splittedMapData[136], out newColor6b) && 

                float.TryParse(splittedMapData[139], out newColor7r) && 
                float.TryParse(splittedMapData[142], out newColor7g) && 
                float.TryParse(splittedMapData[145], out newColor7b) && 

                float.TryParse(splittedMapData[148], out newColor8r) && 
                float.TryParse(splittedMapData[151], out newColor8g) && 
                float.TryParse(splittedMapData[154], out newColor8b)
                ;

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

                    mapGenerator.maxMapValue = newMaxMapValue;
                    mapGenerator.minMapValue = newMinMapValue;
                    mapGenerator.probabilityOfPlain = newPlainProbability;
                    mapGenerator.probabilityOfGorge = newGorgeProbability;
                    mapGenerator.isPlainProbabilitySliderTurnedOn = newIsPlainTurnedOn;
                    mapGenerator.isGorgeProbabilitySliderTurnedOn = newIsGorgeTurnedOn;

                    inputFieldMaxMapValue.text = mapGenerator.maxMapValue.ToString();
                    inputFieldMinMapValue.text = mapGenerator.minMapValue.ToString();
                    sliderProbabilityOfPlain.value = mapGenerator.probabilityOfPlain;
                    sliderProbabilityOfGorge.value = mapGenerator.probabilityOfGorge;
                    togglePlain.isOn = mapGenerator.isPlainProbabilitySliderTurnedOn;
                    toggleGorge.isOn = mapGenerator.isGorgeProbabilitySliderTurnedOn;

                    mapGenerator.regions[0].color.r = newColor1r;
                    mapGenerator.regions[0].color.g = newColor1g;
                    mapGenerator.regions[0].color.b = newColor1b;

                    mapGenerator.regions[1].color.r = newColor2r;
                    mapGenerator.regions[1].color.g = newColor2g;
                    mapGenerator.regions[1].color.b = newColor2b;

                    mapGenerator.regions[2].color.r = newColor3r;
                    mapGenerator.regions[2].color.g = newColor3g;
                    mapGenerator.regions[2].color.b = newColor3b;

                    mapGenerator.regions[3].color.r = newColor4r;
                    mapGenerator.regions[3].color.g = newColor4g;
                    mapGenerator.regions[3].color.b = newColor4b;

                    mapGenerator.regions[4].color.r = newColor5r;
                    mapGenerator.regions[4].color.g = newColor5g;
                    mapGenerator.regions[4].color.b = newColor5b;

                    mapGenerator.regions[5].color.r = newColor6r;
                    mapGenerator.regions[5].color.g = newColor6g;
                    mapGenerator.regions[5].color.b = newColor6b;

                    mapGenerator.regions[6].color.r = newColor7r;
                    mapGenerator.regions[6].color.g = newColor7g;
                    mapGenerator.regions[6].color.b = newColor7b;

                    mapGenerator.regions[7].color.r = newColor8r;
                    mapGenerator.regions[7].color.g = newColor8g;
                    mapGenerator.regions[7].color.b = newColor8b;

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
