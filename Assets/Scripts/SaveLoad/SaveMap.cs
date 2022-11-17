using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveMap : MonoBehaviour
{
    public void saveCurrentMap()
    {
        string savePath = EditorUtility.SaveFilePanel("Save map as TXT", "", "mapSave" + ".txt", "txt");
        if (savePath.Length != 0)
        {
            System.IO.File.WriteAllText(savePath, "Hello hello hey!");
        }
    }
    public void loadMap()
    {
        string pathLoad = EditorUtility.OpenFilePanel("Load a map from TXT", "", "txt");
        if (pathLoad.Length != 0)
        {
            System.IO.File.WriteAllText(pathLoad, "No no no no :)");
        }

    }
}
