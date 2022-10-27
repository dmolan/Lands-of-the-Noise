using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasApp;

    public void RunApp()
    {
        canvasMenu.SetActive(false);
        canvasApp.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
