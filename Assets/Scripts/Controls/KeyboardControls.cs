/*
 *  This code is executed only at the runtime.
 *  Waits for key and mouse input, if there are such, calls "generateMap()"
*/
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControls : MonoBehaviour
{
    public MapGenerator mapGen;
    public HowWorkPages pagesHowWork;
    public HowUsePages pagesHowUse;
    
    public GameObject plane;
    public GameObject mesh;

    public GameObject canvasMenu;
    public GameObject canvasApp;
    public GameObject canvasPreferences;
    public GameObject canvasHowToUse;
    public GameObject canvasHowDoesItWork;
    public GameObject canvasCredits;

    public GameObject settingsMenu;
    public GameObject mainMenu;

    public Button butRun, butOpt, butExit, butHowUse, butHowWork, butCredits;
    // private int currButton = -1;



    // private void settCurrButton()
    // {
    //     if (currButton == 0) 
    //     {
    //         canvasMenu.SetActive(false); 
    //         canvasApp.SetActive(true);
    //     }
    //     if (currButton == 1) 
    //     {
    //         mainMenu.SetActive(false); 
    //         settingsMenu.SetActive(true);
    //     }
    // }

    void Start()
    {
        mapGen.generateMap();

        if (mapGen.drawMode == MapGenerator.DrawMode.Mesh)
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

    private bool changeMade = false;
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
        }
        
        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     ++currButton;
        //     settCurrButton();
        // }

        // For tutorial menu arrows
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
                mapGen.offset.x += mapGen.offsetSpeed;
                changeMade = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (canvasApp.activeSelf)
            {
                mapGen.offset.x -= mapGen.offsetSpeed;
                changeMade = true;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mapGen.offset.y += mapGen.offsetSpeed;
            changeMade = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            mapGen.offset.y -= mapGen.offsetSpeed;
            changeMade = true;
        }
        if (changeMade) 
        {
            mapGen.generateMap();
            changeMade = false;
        }
    }
}
