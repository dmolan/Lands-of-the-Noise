/*
 *  This code is executed only at the runtime.
 *  Functions used by the buttons in the MainMenu: "Run" and "Exit".
*/
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public MapGenerator mapGen;

    public GameObject plane;
    public GameObject mesh;

    public GameObject objectCanvasMenu;
    public GameObject objectCanvasApp;

    public Config config;


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
        config.saveData();
        Application.Quit();
    }
}
