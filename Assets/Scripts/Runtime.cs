using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runtime : MonoBehaviour
{
    public MapGenerator mapGen;
    public GameObject plane;
    public GameObject mesh;



    // Start is called before the first frame update
    void Start()
    {
        mapGen.GenerateMap();

        if (mapGen.drawMode == MapGenerator.DrawMode.Mesh)
        {
            plane.SetActive(false); // false to hide, true to show
            mesh.SetActive(true); // false to hide, true to show
        }
        else
        {
            plane.SetActive(true); // false to hide, true to show
            mesh.SetActive(false); // false to hide, true to show
        }
    }
}
