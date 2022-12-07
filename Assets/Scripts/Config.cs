
using UnityEngine;
using TMPro;
using System.IO;

public class Config : MonoBehaviour
{
    public CameraControls cameraControls;
    public LanguagesForText languagesForText;
    public ScaleUI scaleUI;
    public TMP_InputField mouseSensitivity, scrollingSpeed, angleOfView, 
        currentDistance, rotationSmoothTime, distanceLerpTime;

    public TMP_Dropdown language, scale;
    

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

        cameraControls.nextDistance = cameraControls.defaultDistance;
    }

    public void loadData()
    {
        string configData = System.IO.File.ReadAllText(pathToConfig);
        string[] linesConfigData = configData.Split();

        if (linesConfigData[1] == "Ukrainian")
        {
            languagesForText.changeLanguage(0);
            language.value = 0;
        }
        else if (linesConfigData[1] == "English")
        {
            languagesForText.changeLanguage(1);
            language.value = 1;
        }

        scaleUI.changeCanvasScale(int.Parse(linesConfigData[4]));
        scale.value = int.Parse(linesConfigData[4]);

        cameraControls.rotationSensitivity = float.Parse(linesConfigData[7]);
        mouseSensitivity.text = linesConfigData[7];

        cameraControls.zoomingSpeed = float.Parse(linesConfigData[10]);
        scrollingSpeed.text = linesConfigData[10];

        cameraControls.deafultAngleOfView = float.Parse(linesConfigData[13]);
        cameraControls.angleOfView = float.Parse(linesConfigData[13]);
        angleOfView.text = linesConfigData[13];

        cameraControls.defaultDistance = float.Parse(linesConfigData[16]);
        cameraControls.currentDistance = float.Parse(linesConfigData[16]);
        currentDistance.text = linesConfigData[16];

        cameraControls.rotationSmoothTime = float.Parse(linesConfigData[19]);
        rotationSmoothTime.text = linesConfigData[19];

        cameraControls.distanceLerpTime = float.Parse(linesConfigData[22]);
        distanceLerpTime.text = linesConfigData[22];
    }

    public void saveData()
    {
        string data = 
            "Language: " + languagesForText.languageNow.ToString() + '\r' + '\n' + 
            "Scale: " + scaleUI.scaleIndexNow.ToString() + '\r' + '\n' + 
            "MouseSensitivity: " + cameraControls.rotationSensitivity.ToString() + '\r' + '\n' +
            "ScrollingSpeed: " + cameraControls.zoomingSpeed.ToString() + '\r' + '\n' +
            "AngleOfView: " + cameraControls.deafultAngleOfView.ToString() + '\r' + '\n' +
            "CameraDistance: " + cameraControls.defaultDistance.ToString() + '\r' + '\n' +
            "RotationSmoothing: " + cameraControls.rotationSmoothTime.ToString() + '\r' + '\n' +
            "DistanceSmoothing: " + cameraControls.distanceLerpTime.ToString() + '\r' + '\n';
            
        System.IO.File.WriteAllText(pathToConfig, data);
    }
}
