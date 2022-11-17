using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasApp;
    public Canvas canvasPreferences;

    private float defMenuScale = 0.6f;
    private float defAppScale = 0.9f;
    private float defPrefScale = 0.65f;

    private float menuScale;
    private float appScale;
    private float prefScale;



    void Start()
    {
        menuScale = defMenuScale;
        appScale = defAppScale;
        prefScale = defPrefScale;
    }

    void Update()
    {
        if (canvasMenu.scaleFactor != menuScale) canvasMenu.scaleFactor = menuScale;
        if (canvasApp.scaleFactor != appScale) canvasApp.scaleFactor = appScale;
        if (canvasPreferences.scaleFactor != prefScale) canvasPreferences.scaleFactor = prefScale;
    }

    public void changeCanvasScale(int val)
    {
        if (val == 0) 
        {
            menuScale = defMenuScale*(3/4f);
            appScale = defAppScale*(3/4f);
            prefScale = defPrefScale*(3/4f);
        }
        else if (val == 1) 
        {
            menuScale = defMenuScale;
            appScale = defAppScale;
            prefScale = defPrefScale;
        }
        else if (val == 2) 
        {
            menuScale = defMenuScale*(5/4f);
            appScale = defAppScale*(5/4f);
            prefScale = defPrefScale*(5/4f);
        }
        else if (val == 3) 
        {
            menuScale = defMenuScale*(3/2f);
            appScale = defAppScale*(3/2f);
            prefScale = defPrefScale*(3/2f);
        }
    }
}
