/*
 * UI for static points 
 */

using UnityEngine;
using System;
using TMPro;

public class StaticPointsUI : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public TMP_InputField staticPointX, staticPointY, staticPointHeight;

    public void clearAllStaticPoints()
    {
        mapGenerator.staticPoints = new StaticPoint[0];
        mapGenerator.generateMap();
    }

    public void addNewStaticPoint()
    {
        if (staticPointX.text != "" && staticPointY.text != "" && staticPointHeight.text != "")
        {
            float resultOfHeightParse = 0;
            int resultOfXParse = 0;
            int resultOfYParse = 0;

            bool isAllParsed = 
            float.TryParse(staticPointHeight.text, out resultOfHeightParse) &&
            int.TryParse(staticPointX.text, out resultOfXParse) &&
            int.TryParse(staticPointY.text, out resultOfYParse);

            if (!isAllParsed) return;

            Array.Resize(ref mapGenerator.staticPoints, mapGenerator.staticPoints.Length + 1);
            mapGenerator.staticPoints[mapGenerator.staticPoints.Length-1].x = int.Parse(staticPointX.text);
            mapGenerator.staticPoints[mapGenerator.staticPoints.Length-1].y = int.Parse(staticPointY.text);

            if (resultOfHeightParse > mapGenerator.maxMapValue) mapGenerator.staticPoints[mapGenerator.staticPoints.Length-1].height = mapGenerator.maxMapValue;
            else if (resultOfHeightParse < mapGenerator.minMapValue) mapGenerator.staticPoints[mapGenerator.staticPoints.Length-1].height = mapGenerator.minMapValue;
            else mapGenerator.staticPoints[mapGenerator.staticPoints.Length-1].height = resultOfHeightParse;

            mapGenerator.generateMap();
        }
    }

    public void removeLastStaticPoint()
    {
        if (mapGenerator.staticPoints.Length > 0)
        {
            Array.Resize(ref mapGenerator.staticPoints, mapGenerator.staticPoints.Length - 1);
        }
        mapGenerator.generateMap();
    }
}
