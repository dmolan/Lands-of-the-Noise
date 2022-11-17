using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MapGenerator mapGen;

    public GameObject plane;
    public GameObject mesh;

    public GameObject objectCanvasMenu;
    public GameObject objectCanvasApp;



    public void RunApp()
    {
        objectCanvasMenu.SetActive(false);
        objectCanvasApp.SetActive(true);

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

    public void QuitApp()
    {
        Application.Quit();
    }
}
