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
    public Canvas canvasHowWork;
    public Canvas canvasCredits;

    const float defaultDeltaScale = 0.25f;

    private float defMenuScale = 0.4f + defaultDeltaScale;
    private float defAppScale = 0.7f + defaultDeltaScale;
    private float defPrefScale = 0.55f + defaultDeltaScale;
    private float defHowUseScale = 0.35f + defaultDeltaScale;
    private float defHowWorkScale = 0.35f + defaultDeltaScale;
    private float defCreditsScale = 0.35f + defaultDeltaScale;

    private float menuScale;
    private float appScale;
    private float prefScale;
    private float howUseScale;
    private float howWorkScale;
    private float creditsScale;



    void Start()
    {
        menuScale = defMenuScale;
        appScale = defAppScale;
        prefScale = defPrefScale;
        howUseScale = defHowUseScale;
        howWorkScale = defHowWorkScale;
        creditsScale = defCreditsScale;
    }

    void Update()
    {
        if (canvasMenu.scaleFactor != menuScale) canvasMenu.scaleFactor = menuScale;
        if (canvasApp.scaleFactor != appScale) canvasApp.scaleFactor = appScale;
        if (canvasPreferences.scaleFactor != prefScale) canvasPreferences.scaleFactor = prefScale;
        if (canvasHowUse.scaleFactor != howUseScale) canvasHowUse.scaleFactor = howUseScale;
        if (canvasHowWork.scaleFactor != howWorkScale) canvasHowWork.scaleFactor = howWorkScale;
        if (canvasCredits.scaleFactor != creditsScale) canvasCredits.scaleFactor = creditsScale;
    }

    public void changeCanvasScale(int val)
    {
        if (val == 0)
        {
            menuScale = defMenuScale * (3/4f);
            appScale = defAppScale * (3/4f);
            prefScale = defPrefScale * (3/4f);
            howUseScale = defHowUseScale * (3/4f);
            howWorkScale = defHowWorkScale * (3/4f);
            creditsScale = defCreditsScale * (3/4f);
        }
        else if (val == 1)
        {
            menuScale = defMenuScale;
            appScale = defAppScale;
            prefScale = defPrefScale;
            howUseScale = defHowUseScale;
            howWorkScale = defHowWorkScale;
            creditsScale = defCreditsScale;
        }
        else if (val == 2)
        {
            menuScale = defMenuScale * (5/4f);
            appScale = defAppScale * (5/4f);
            prefScale = defPrefScale * (5/4f);
            howUseScale = defHowUseScale * (5/4f);
            howWorkScale = defHowWorkScale * (5/4f);
            creditsScale = defCreditsScale * (5/4f);
        }
        else if (val == 3)
        {
            menuScale = defMenuScale * (3/2f);
            appScale = defAppScale * (3/2f);
            prefScale = defPrefScale * (3/2f);
            howUseScale = defHowUseScale*(3/2f);
            howWorkScale = defHowWorkScale * (3/2f);
            creditsScale = defCreditsScale * (3/2f);
        }
    }
}
