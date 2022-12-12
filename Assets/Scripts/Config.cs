
using UnityEngine;
using TMPro;
using System.IO;

public class Config : MonoBehaviour
{
    public CameraControls cameraControls;
    public LanguagesForText languagesForText;
    public ScaleUI scaleUI;
    
    public TMP_InputField inputFieldRotationSensitivity, inputFieldZoomingSensitivity, 
    inputFieldRotationSmoothTime, inputFieldDistanceLerpTime, inputFieldAngleOfView, inputFieldCurrentDistance;

    public TMP_Dropdown dropdownLanguage, dropdownScale;

    string pathToProjectFolder;
    string pathToConfig;



    void Start()
    {
        // Set default scale
        scaleUI.menuScale = scaleUI.defMenuScale;
        scaleUI.appScale = scaleUI.defAppScale;
        scaleUI.prefScale = scaleUI.defPrefScale;
        scaleUI.howUseScale = scaleUI.defHowUseScale;
        scaleUI.howWorkScale = scaleUI.defHowWorkScale;
        scaleUI.creditsScale = scaleUI.defCreditsScale;
        scaleUI.changeCanvasScale(1);

        // Find path to file
        pathToProjectFolder = Path.GetDirectoryName(Application.dataPath);
        pathToConfig = Path.Combine(pathToProjectFolder, "config.txt");

        // Open or create "config.txt"
        if (System.IO.File.Exists(pathToConfig)) loadData();
        else saveData();

        // Setup the Camera
        cameraControls.rotationY = 0;
        cameraControls.rotationX = cameraControls.deafultAngleOfView;

        // Set beginning rotation of camera
        cameraControls.currentRotation = new Vector3(cameraControls.rotationX, cameraControls.rotationY);

        cameraControls.nextDistance = cameraControls.defaultDistanceToMap;
    }

    public void loadData()
    {
        string configData = System.IO.File.ReadAllText(pathToConfig);
        string[] linesConfigData = configData.Split();

        if (linesConfigData[1] == "Ukrainian")
        {
            languagesForText.changeLanguage(0);
            dropdownLanguage.value = 0;
        }
        else if (linesConfigData[1] == "English")
        {
            languagesForText.changeLanguage(1);
            dropdownLanguage.value = 1;
        }

        scaleUI.changeCanvasScale(int.Parse(linesConfigData[4]));
        dropdownScale.value = int.Parse(linesConfigData[4]);

        cameraControls.rotationSensitivity = float.Parse(linesConfigData[7]);
        inputFieldRotationSensitivity.text = linesConfigData[7];

        cameraControls.zoomingSensitivity = float.Parse(linesConfigData[10]);
        inputFieldZoomingSensitivity.text = linesConfigData[10];

        cameraControls.deafultAngleOfView = float.Parse(linesConfigData[13]);
        inputFieldAngleOfView.text = linesConfigData[13];

        cameraControls.defaultDistanceToMap = float.Parse(linesConfigData[16]);
        cameraControls.currentDistanceToMap = float.Parse(linesConfigData[16]);
        inputFieldCurrentDistance.text = linesConfigData[16];

        cameraControls.rotationSmoothTime = float.Parse(linesConfigData[19]);
        inputFieldRotationSmoothTime.text = linesConfigData[19];

        cameraControls.distanceLerpTime = float.Parse(linesConfigData[22]);
        inputFieldDistanceLerpTime.text = linesConfigData[22];
    }

    public void saveData()
    {
        string data = 
            "Language: " + languagesForText.languageNow.ToString() + '\r' + '\n' + 
            "Scale: " + scaleUI.scaleIndexNow.ToString() + '\r' + '\n' + 
            "MouseSensitivity: " + cameraControls.rotationSensitivity.ToString() + '\r' + '\n' +
            "ScrollingSpeed: " + cameraControls.zoomingSensitivity.ToString() + '\r' + '\n' +
            "AngleOfView: " + cameraControls.deafultAngleOfView.ToString() + '\r' + '\n' +
            "CameraDistance: " + cameraControls.defaultDistanceToMap.ToString() + '\r' + '\n' +
            "RotationSmoothing: " + cameraControls.rotationSmoothTime.ToString() + '\r' + '\n' +
            "DistanceSmoothing: " + cameraControls.distanceLerpTime.ToString() + '\r' + '\n';
            
        System.IO.File.WriteAllText(pathToConfig, data);
    }
}
