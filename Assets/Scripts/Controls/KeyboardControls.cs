/*
 *  This code is executed only at the runtime.
 *  Waits for key and mouse input, if there are such, calls "generateMap()"
*/
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    public MapGenerator mapGen;
    
    public GameObject plane;
    public GameObject mesh;

    public GameObject canvasMenu;
    public GameObject canvasApp;
    public GameObject canvasPreferences;
    public GameObject canvasHowToUse;
    public GameObject canvasHowDoesItWork;
    public GameObject canvasCredits;



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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mapGen.offset.x += mapGen.offsetSpeed;
            changeMade = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            mapGen.offset.x -= mapGen.offsetSpeed;
            changeMade = true;
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
