﻿/*
 *  This code is executed only at the runtime.
 *  Waits for key and mouse input, if there are such, does what shortcuts should do
*/
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControls : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public HowDoesItWorkPages pagesHowWork;
    public HowToUsePages pagesHowUse;
    
    public GameObject plane, mesh;

    public GameObject canvasMenu, canvasApp, canvasPreferences, canvasHowToUse, canvasHowDoesItWork, canvasCredits, canvasFiles;
    public GameObject settingsMenu, mainMenu;

    public Button butRun, butOpt, butExit, butHowUse, butHowWork, butCredits;
    


    void Start()
    {
        mapGenerator.generateMap();

        if (mapGenerator.drawMode == MapGenerator.DrawMode.Mesh)
        {
            plane.SetActive(false); 
            mesh.SetActive(true); 
        }
        else
        {
            plane.SetActive(true);
            mesh.SetActive(false);
        }
    }

    private bool isChangesMade = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Run pause screen
            if (canvasApp.activeSelf)
            {
                canvasMenu.SetActive(true);
                canvasApp.SetActive(false);
                plane.SetActive(false);
                mesh.SetActive(false);
            }
            if (settingsMenu.activeSelf)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
            if (canvasPreferences.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasPreferences.SetActive(false);
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
            if (canvasFiles.activeSelf)
            {
                canvasApp.SetActive(true);
                canvasFiles.SetActive(false);
            }
        }

        // Arrows for tutorial menu and App
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                pagesHowWork.buttonFastBwPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                pagesHowUse.buttonFastBwPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                pagesHowWork.buttonFwPressed();
            }
            if (canvasHowToUse.activeSelf)
            {
                pagesHowUse.buttonFwPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                pagesHowWork.buttonBwPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                pagesHowUse.buttonBwPressed();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canvasHowDoesItWork.activeSelf)
            {
                pagesHowWork.buttonFastFwPressed();
            }
            else if (canvasHowToUse.activeSelf)
            {
                pagesHowUse.buttonFastFwPressed();
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (canvasApp.activeSelf)
            {
                mapGenerator.offset.x += mapGenerator.offsetSpeed;
                isChangesMade = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (canvasApp.activeSelf)
            {
                mapGenerator.offset.x -= mapGenerator.offsetSpeed;
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
