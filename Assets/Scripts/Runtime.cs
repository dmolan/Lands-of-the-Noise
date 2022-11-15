﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runtime : MonoBehaviour
{
    public MapGenerator mapGen;
    
    public GameObject plane;
    public GameObject mesh;

    public GameObject canvasMenu;
    public GameObject canvasApp;



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

    private bool changeMade = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Run pause screen
            canvasMenu.SetActive(true);
            canvasApp.SetActive(false);
            plane.SetActive(false);
            mesh.SetActive(false);
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
            mapGen.GenerateMap();
            changeMade = false;
        }
    }
}
