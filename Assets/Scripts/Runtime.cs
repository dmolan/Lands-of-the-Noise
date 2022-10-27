using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            plane.SetActive(false); 
            mesh.SetActive(true); 
        }
        else
        {
            plane.SetActive(true);
            mesh.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Run pause screen
            SceneManager.LoadScene(0);
        }
    }
}
