/*
 *  This code is executed only at the runtime.
 *  Every frame checks if canvas scale is right, if not, changes it.
*/
using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    public Canvas canvasMenu, canvasApp, canvasPreferences, 
    canvasHowUse, canvasHowWork, canvasCredits, canvasFiles;

    // This variable might be changed to better fit the screens
    const float defaultDeltaScale = 0.25f;

    public float defMenuScale = 0.4f + defaultDeltaScale;
    public float defAppScale = 0.7f + defaultDeltaScale;
    public float defPrefScale = 0.55f + defaultDeltaScale;
    public float defHowUseScale = 0.35f + defaultDeltaScale;
    public float defHowWorkScale = 0.35f + defaultDeltaScale;
    public float defCreditsScale = 0.35f + defaultDeltaScale;
    public float defFilesScale = 0.55f + defaultDeltaScale;

    public float menuScale, appScale, prefScale, howUseScale, howWorkScale, creditsScale, filesScale;

    public int scaleIndexNow;



    void Update()
    {
        if (canvasMenu.scaleFactor != menuScale) canvasMenu.scaleFactor = menuScale;
        if (canvasApp.scaleFactor != appScale) canvasApp.scaleFactor = appScale;
        if (canvasPreferences.scaleFactor != prefScale) canvasPreferences.scaleFactor = prefScale;
        if (canvasHowUse.scaleFactor != howUseScale) canvasHowUse.scaleFactor = howUseScale;
        if (canvasHowWork.scaleFactor != howWorkScale) canvasHowWork.scaleFactor = howWorkScale;
        if (canvasCredits.scaleFactor != creditsScale) canvasCredits.scaleFactor = creditsScale;
        if (canvasFiles.scaleFactor != filesScale) canvasFiles.scaleFactor = filesScale;
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
        }
        else if (val == 3)
        {
            menuScale = defMenuScale * (3/2f);
            appScale = defAppScale * (3/2f);
            prefScale = defPrefScale * (3/2f);
            howUseScale = defHowUseScale*(3/2f);
            howWorkScale = defHowWorkScale * (3/2f);
            creditsScale = defCreditsScale * (3/2f);
            filesScale = defFilesScale * (3/2f);
        }
    }
}
