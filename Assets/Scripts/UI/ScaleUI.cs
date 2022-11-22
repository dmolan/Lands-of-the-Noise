/*
 *  This code is executed only at the runtime.
 *  Every frame checks if canvas scale is right, if not, changes it.
*/
using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasApp;
    public Canvas canvasPreferences;
    public Canvas canvasHowUse;

    private float defMenuScale = 0.4f;
    private float defAppScale = 0.7f;
    private float defPrefScale = 0.45f;
    private float defHowUseScale = 0.45f;

    private float menuScale;
    private float appScale;
    private float prefScale;
    private float howUseScale;




    void Start()
    {
        menuScale = defMenuScale;
        appScale = defAppScale;
        prefScale = defPrefScale;
        howUseScale = defHowUseScale;
    }

    void Update()
    {
        if (canvasMenu.scaleFactor != menuScale) canvasMenu.scaleFactor = menuScale;
        if (canvasApp.scaleFactor != appScale) canvasApp.scaleFactor = appScale;
        if (canvasPreferences.scaleFactor != prefScale) canvasPreferences.scaleFactor = prefScale;
        if (canvasHowUse.scaleFactor != howUseScale) canvasHowUse.scaleFactor = howUseScale;
    }

    public void changeCanvasScale(int val)
    {
        if (val == 0)
        {
            menuScale = defMenuScale * (3/4f);
            appScale = defAppScale * (3/4f);
            prefScale = defPrefScale * (3/4f);
            howUseScale = defHowUseScale * (3/4f);
        }
        else if (val == 1)
        {
            menuScale = defMenuScale;
            appScale = defAppScale;
            prefScale = defPrefScale;
            howUseScale = defHowUseScale;
        }
        else if (val == 2)
        {
            menuScale = defMenuScale * (5/4f);
            appScale = defAppScale * (5/4f);
            prefScale = defPrefScale * (5/4f);
            howUseScale = defHowUseScale * (5/4f);
        }
        else if (val == 3)
        {
            menuScale = defMenuScale * (3/2f);
            appScale = defAppScale * (3/2f);
            prefScale = defPrefScale * (3/2f);
            howUseScale = defHowUseScale*(3/2f);
        }
    }
}
