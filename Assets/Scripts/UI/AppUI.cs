/*
 *  Contains functions for buttons, sliders and dropdown in app
*/
using UnityEngine;
using TMPro;

public class AppUI : MonoBehaviour
{
    public GameObject plane, mesh, meshHeightMultiplier;

    public MapGenerator mapGenerator;
    public TMP_InputField inputFieldMapWidth, inputFieldMapHeight, inputFieldMeshHeightMultiplier, 
    inputFieldSeed, inputFieldMinMapValue, inputFieldMaxMapValue;



    public void changePersistance(float newPersistance)
    {
        mapGenerator.persistance = newPersistance;
        mapGenerator.generateMap();
    }

    public void changeLacunarity(float newLacunarity)
    {
        mapGenerator.lacunarity = newLacunarity;
        mapGenerator.generateMap();
    }

    public void changeScale(float newNoiseScale)
    {
        mapGenerator.noiseScale = newNoiseScale;
        mapGenerator.generateMap();
    }

    public void changeOctaves(float newOctaves)
    {
        mapGenerator.octaves = (int)newOctaves;
        mapGenerator.generateMap();
    }

    public void changeWidth(string newMapWidth)
    {
        if (newMapWidth != "")
        {  
            if (int.Parse(newMapWidth) > 30000)
            {
                mapGenerator.mapWidth = 30000;
                inputFieldMapWidth.text = "30000";
            }
            else
            {
                mapGenerator.mapWidth = int.Parse(newMapWidth);
            }
            mapGenerator.generateMap();
        }
    }

    public void changeHeight(string newMapHeight)
    {
        if (newMapHeight != "")
        {
            if (int.Parse(newMapHeight) > 30000)
            {
                mapGenerator.mapHeight = 30000;
                inputFieldMapHeight.text = "30000";
            }
            else
            {
                mapGenerator.mapHeight = int.Parse(newMapHeight);
            }
            mapGenerator.generateMap();
        }
    }

    public void changeMinMapValue(string newMinMapValue)
    {
        if (newMinMapValue != "")
        {
            if (int.Parse(newMinMapValue) > 1e9)
            {
                mapGenerator.minMapValue = 1000000000;
                inputFieldMinMapValue.text = "1000000000";
            }
            else
            {
                mapGenerator.minMapValue = int.Parse(newMinMapValue);
            }
        }
    }

    public void changeMaxMapValue(string newMaxMapValue)
    {
        if (newMaxMapValue != "")
        {
            if (int.Parse(newMaxMapValue) > 1e9)
            {
                mapGenerator.maxMapValue = 1000000000;
                inputFieldMaxMapValue.text = "1000000000";
            }
            else
            {
                mapGenerator.maxMapValue = int.Parse(newMaxMapValue);
            }
        }
    }

    public void changeMeshHeightMultiplier(string newMeshHeightMultiplier)
    {
        if (newMeshHeightMultiplier != "")
        {
            mapGenerator.meshHeightMultiplier = float.Parse(newMeshHeightMultiplier);
            if (mapGenerator.meshHeightMultiplier < 0.01) 
            {
                mapGenerator.meshHeightMultiplier = 0.01f;
                inputFieldMeshHeightMultiplier.text = "0.01";
            }
            if (mapGenerator.meshHeightMultiplier > 1000) 
            {
                mapGenerator.meshHeightMultiplier = 1000;
                inputFieldMeshHeightMultiplier.text = "1000";
            }
            mapGenerator.generateMap();
        }
    }

    public void changeOffsetSpeed(float newOffsetSpeed)
    {
        mapGenerator.offsetSpeed = newOffsetSpeed;
    }

    public void changeDrawMode(int val)
    {
        if (val == 0) 
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.NoiseMap;
            plane.SetActive(true);
            mesh.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else if (val == 1) 
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.ColorMap;
            plane.SetActive(true);
            mesh.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else 
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
            plane.SetActive(false);
            mesh.SetActive(true);
            meshHeightMultiplier.SetActive(true);
        }

        mapGenerator.generateMap();
    }

    public void randomSeed()
    {
        mapGenerator.seed = Random.Range(0, (int)1e9 - 1);
        inputFieldSeed.text = mapGenerator.seed.ToString();
        mapGenerator.generateMap();
    }

    public void changeSeed(string newSeed)
    {
        if (newSeed != "")
        {
            if (newSeed.Length > 9) mapGenerator.seed = (int)1e9 - 1;
            else mapGenerator.seed = int.Parse(newSeed);

            mapGenerator.generateMap();
        }
    }

    public void checkSeed(string seed)
    {
        if (seed.Length > 9) 
        {
            seed = seed.Substring(0, 9);
            inputFieldSeed.text = seed;
        }
    }
}
