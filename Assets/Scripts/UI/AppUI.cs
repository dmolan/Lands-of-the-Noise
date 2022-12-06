/*
 * Contains functions for buttons, sliders and dropdown in app
*/
using UnityEngine;
using TMPro;

public class AppUI : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Mesh;
    public GameObject meshHeightMultiplier;

    public MapGenerator mapGen;



    public void changePersistance(float newPersistance)
    {
        mapGen.persistance = newPersistance;
        mapGen.generateMap();
    }

    public void changeLacunarity(float newLacunarity)
    {
        mapGen.lacunarity = newLacunarity;
        mapGen.generateMap();
    }

    public void changeScale(float newNoiseScale)
    {
        mapGen.noiseScale = newNoiseScale;
        mapGen.generateMap();
    }

    public void changeOctaves(float newOctaves)
    {
        mapGen.octaves = (int)newOctaves;
        mapGen.generateMap();
    }

    public void changeWidth(string newMapWidth)
    {
        if (newMapWidth != "")
        {
            mapGen.mapWidth = int.Parse(newMapWidth);
            if (mapGen.mapWidth > 300) mapGen.mapWidth = 300;
            if (mapGen.mapWidth < 0) mapGen.mapWidth = 1;
            mapGen.generateMap();
        }
    }

    public void changeHeight(string newMapHeight)
    {
        if (newMapHeight != "")
        {
            mapGen.mapHeight = int.Parse(newMapHeight);
            if (mapGen.mapHeight > 300) mapGen.mapHeight = 300;
            if (mapGen.mapHeight < 0) mapGen.mapHeight = 1;
            mapGen.generateMap();
        }
    }

    public void changeMeshHeightMultiplier(string newMeshHeightMultiplier)
    {
        if (newMeshHeightMultiplier != "")
        {
            mapGen.meshHeightMultiplier = float.Parse(newMeshHeightMultiplier);
            if (mapGen.meshHeightMultiplier < 0.0001) mapGen.meshHeightMultiplier = 0.0001f;
            mapGen.generateMap();
        }
    }

    public void changeOffsetSpeed(float newOffsetSpeed)
    {
        mapGen.offsetSpeed = newOffsetSpeed;
    }

    public void changeDrawMode(int val)
    {
        if (val == 0) 
        {
            mapGen.drawMode = MapGenerator.DrawMode.NoiseMap;
            Plane.SetActive(true);
            Mesh.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else if (val == 1) 
        {
            mapGen.drawMode = MapGenerator.DrawMode.ColorMap;
            Plane.SetActive(true);
            Mesh.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else 
        {
            mapGen.drawMode = MapGenerator.DrawMode.Mesh;
            Plane.SetActive(false);
            Mesh.SetActive(true);
            meshHeightMultiplier.SetActive(true);
        }

        mapGen.generateMap();
    }

    public TMP_InputField InputFieldSeed;
    public void randomSeed()
    {
        mapGen.seed = Random.Range(0, (int)1e9 - 1);
        InputFieldSeed.text = mapGen.seed.ToString();
        mapGen.generateMap();
    }

    public void changeSeed(string newSeed)
    {
        if (newSeed != "")
        {
            if (newSeed.Length > 9) mapGen.seed = (int)1e9 - 1;
            else mapGen.seed = int.Parse(newSeed);

            mapGen.generateMap();
        }
    }

    public void checkSeed(string seed)
    {
        if (seed.Length > 9) 
        {
            seed = seed.Substring(0, 9);
            InputFieldSeed.text = seed;
        }
    }
}
