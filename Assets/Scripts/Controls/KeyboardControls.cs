/*
 * This code is executed only at the runtime.
 * Waits for key and mouse input, if there are such, does what shortcuts should do
 */

using UnityEngine;
using UnityEngine.UI;

public class KeyboardControls : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public HowToUsePages howToUsePages;
    public HowDoesItWorkPages howDoesItWorkPages;
    
    public GameObject plane, mesh;

    public GameObject canvasMenu, canvasApp, canvasPreferences, canvasHowToUse, 
    canvasHowDoesItWork, canvasCredits, canvasFiles, canvasStaticPoints, canvasColors;
    public GameObject settingsMenu, mainMenu;

    public Button butRun, butOpt, butExit, butHowUse, butHowWork, butCredits;
    
    private bool isChangesMade = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Run pause screen
            if (canvasPreferences.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasPreferences.SetActive(false);
            }
            else if (canvasFiles.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasFiles.SetActive(false);
            }
            else if (canvasStaticPoints.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasStaticPoints.SetActive(false);
            }
            else if (canvasColors.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasColors.SetActive(false);
            }
            else if (canvasApp.activeSelf)
            {
                canvasMenu.SetActive(true);
                canvasApp.SetActive(false);
            }

            if (settingsMenu.activeSelf)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
            
            if (canvasHowToUse.activeSelf)
            {
                canvasMenu.SetActive(true);
                canvasHowToUse.SetActive(false);
            }
            if (canvasHowDoesItWork.activeSelf)
            {
                canvasMenu.SetActive(true);
                canvasHowDoesItWork.SetActive(false);
            }
            if (canvasCredits.activeSelf)
            {
                canvasMenu.SetActive(true);
                canvasCredits.SetActive(false);
            }
        }

        // Arrows for tutorial menu and App
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                howDoesItWorkPages.buttonFastBackwardPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                howToUsePages.buttonFastBackwardPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                howDoesItWorkPages.buttonForwardPressed();
            }
            if (canvasHowToUse.activeSelf)
            {
                howToUsePages.buttonForwardPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                howDoesItWorkPages.buttonBackwardPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                howToUsePages.buttonBackwardPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                howDoesItWorkPages.buttonFastForwardPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                howToUsePages.buttonFastForwardPressed();
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (canvasApp.activeSelf)
            {
                mapGenerator.offset.x -= mapGenerator.offsetSpeed;
                isChangesMade = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (canvasApp.activeSelf)
            {
                mapGenerator.offset.x += mapGenerator.offsetSpeed;
                isChangesMade = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mapGenerator.offset.y += mapGenerator.offsetSpeed;
            isChangesMade = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            mapGenerator.offset.y -= mapGenerator.offsetSpeed;
            isChangesMade = true;
        }
        if (isChangesMade) 
        {
            mapGenerator.generateMap();

            isChangesMade = false;
        }
    }
}
