﻿/*
 * This code is executed only at the runtime.
 * Every frame checks if canvas scale is right, if not, changes it.
 */

using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    public TableUI tableUI;
    public GameObject table;

    public Canvas canvasMenu, canvasApp, canvasPreferences, 
    canvasHowUse, canvasHowWork, canvasCredits, canvasFiles, 
    canvasStaticPoints, canvasColors;

    // This variable might be changed to better fit the screens
    const float defaultDeltaScale = -0.25f;

    // WARNING! These values might actually be taken from Unity Editor's fields
    public float defMenuScale = 0.65f + defaultDeltaScale;
    public float defAppScale = 0.95f + defaultDeltaScale;
    public float defPrefScale = 1f + defaultDeltaScale;
    public float defHowUseScale = 0.6f + defaultDeltaScale;
    public float defHowWorkScale = 0.6f + defaultDeltaScale;
    public float defCreditsScale = 0.6f + defaultDeltaScale;
    public float defFilesScale = 1f + defaultDeltaScale;
    public float defStaticPointsScale = 1f + defaultDeltaScale;
    public float defColorsScale = 0.8f + defaultDeltaScale;

    public float defTableScale = 0.75f - defaultDeltaScale;

    [HideInInspector] public float menuScale, appScale, prefScale, howUseScale, howWorkScale, creditsScale, filesScale, staticPointsScale, colorsScale;

    public int scaleIndexNow;
    Vector3 tableScaleVector3 = new Vector3();



    void Update()
    {
        if (canvasMenu.scaleFactor != menuScale) canvasMenu.scaleFactor = menuScale;
        if (canvasApp.scaleFactor != appScale) canvasApp.scaleFactor = appScale;
        if (canvasPreferences.scaleFactor != prefScale) canvasPreferences.scaleFactor = prefScale;
        if (canvasHowUse.scaleFactor != howUseScale) canvasHowUse.scaleFactor = howUseScale;
        if (canvasHowWork.scaleFactor != howWorkScale) canvasHowWork.scaleFactor = howWorkScale;
        if (canvasCredits.scaleFactor != creditsScale) canvasCredits.scaleFactor = creditsScale;
        if (canvasFiles.scaleFactor != filesScale) canvasFiles.scaleFactor = filesScale;
        if (canvasStaticPoints.scaleFactor != staticPointsScale) canvasStaticPoints.scaleFactor = staticPointsScale;
        if (canvasColors.scaleFactor != colorsScale) canvasColors.scaleFactor = colorsScale;

        if (table.transform.localScale != tableScaleVector3) table.transform.localScale = tableScaleVector3;
    }

    public void changeCanvasScale(int val)
    {
        scaleIndexNow = val;

        if (val == 0)
        {
            menuScale = defMenuScale * (3/4f);
            appScale = defAppScale * (3/4f);
            prefScale = defPrefScale * (3/4f);
            howUseScale = defHowUseScale * (3/4f);
            howWorkScale = defHowWorkScale * (3/4f);
            creditsScale = defCreditsScale * (3/4f);
            filesScale = defFilesScale * (3/4f);
            staticPointsScale = defStaticPointsScale * (3/4f);
            colorsScale = defColorsScale * (3/4f);

            tableScaleVector3 = new Vector3(defTableScale * (3/4f), defTableScale * (3/4f), 0);
        }
        else if (val == 1)
        {
            menuScale = defMenuScale;
            appScale = defAppScale;
            prefScale = defPrefScale;
            howUseScale = defHowUseScale;
            howWorkScale = defHowWorkScale;
            creditsScale = defCreditsScale;
            filesScale = defFilesScale;
            staticPointsScale = defStaticPointsScale;
            colorsScale = defColorsScale;

            tableScaleVector3 = new Vector3(defTableScale, defTableScale, 0);
        }
        else if (val == 2)
        {
            menuScale = defMenuScale * (5/4f);
            appScale = defAppScale * (5/4f);
            prefScale = defPrefScale * (5/4f);
            howUseScale = defHowUseScale * (5/4f);
            howWorkScale = defHowWorkScale * (5/4f);
            creditsScale = defCreditsScale * (5/4f);
            filesScale = defFilesScale * (5/4f);
            staticPointsScale = defStaticPointsScale * (5/4f);
            colorsScale = defColorsScale * (5/4f);

            // App Scale is too strong for table, so downscaling is needed
            tableScaleVector3 = new Vector3(defTableScale * 0.8f, defTableScale * 0.8f, 0);
        }
        else if (val == 3)
        {
            menuScale = defMenuScale * (3/2f);
            appScale = defAppScale * (3/2f);
            prefScale = defPrefScale * (3/2f);
            howUseScale = defHowUseScale * (3/2f);
            howWorkScale = defHowWorkScale * (3/2f);
            creditsScale = defCreditsScale * (3/2f);
            filesScale = defFilesScale * (3/2f);
            colorsScale = defColorsScale * (3/2f);

            // App Scale is too strong for table, so downscaling is needed
            tableScaleVector3 = new Vector3(defTableScale * 0.75f, defTableScale * 0.75f, 0);
        }
    }
}
