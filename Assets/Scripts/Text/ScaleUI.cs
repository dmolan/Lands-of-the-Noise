using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScaleUI
{
    public static Canvas canvasMenu;
    public static Canvas canvasApp;
    public static Canvas canvasPreferences;

    private static float menuScale = 0.5f;
    private static float appScale = 0.5f;
    private static float prefScale = 0.5f;

    public static void changeCanvasScale(int val)
    {
        if (val == 0) 
        {
            canvasMenu.scaleFactor = 0.25f;
            canvasApp.scaleFactor = 0.25f;
            canvasPreferences.scaleFactor = 0.25f;
        }
        else if (val == 1) 
        {
            canvasMenu.scaleFactor = 0.50f;
            canvasApp.scaleFactor = 0.50f;
            canvasPreferences.scaleFactor = 0.50f;
        }
        else if (val == 2) 
        {
            canvasMenu.scaleFactor = 0.75f;
            canvasApp.scaleFactor = 0.75f;
            canvasPreferences.scaleFactor = 0.75f;
        }
        else if (val == 3) 
        {
            canvasMenu.scaleFactor = 1.00f;
            canvasApp.scaleFactor = 1.00f;
            canvasPreferences.scaleFactor = 1.00f;
        }
    }

    public static void setMenuCanvasScale()
    {
        canvasMenu.scaleFactor = menuScale;
    }
    public static void setAppCanvasScale()
    {
        canvasApp.scaleFactor = appScale;
    }
    public static void setPrefCanvasScale()
    {
        canvasPreferences.scaleFactor = prefScale;
    }
}
