/*
 *  This code is executed only at the runtime.
 *  Function used by the button in the MainMenu: "Exit".
*/
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Config config;



    public void quitApp()
    {
        config.saveData();
        Application.Quit();
    }
}
