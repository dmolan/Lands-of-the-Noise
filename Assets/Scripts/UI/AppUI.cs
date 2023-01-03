/*
 * Contains functions for buttons, sliders and dropdowns in app
 */

using UnityEngine;
using TMPro;
using System;

public class AppUI : MonoBehaviour
{
    // If InputField Max/Min Map value string is longer then this const, it is replaced with shorter substring
    const int INPUT_FIELD_MAP_VALUE_MAX_LENGTH = 6;

    public TableUI tableUI;
    public GameObject plane, mesh, table, meshHeightMultiplier;

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

    public void changePlainProbability(float newProbabilityOfPlain)
    {
        mapGenerator.probabilityOfPlain = newProbabilityOfPlain;
        //probabilityOfPlainWasChanged = true;
        mapGenerator.generateMap();
    }

    public void changeGorgeProbability(float newProbabilityOfGorge)
    {
        mapGenerator.probabilityOfGorge = Math.Abs(newProbabilityOfGorge-1);
        //probabilityOfPlainWasChanged = true;
        mapGenerator.generateMap();
    }

    public void switchPlainProbabilitySliderVisibility(bool flag)
    {
        mapGenerator.isProbabilitySliderTurnedOn = flag;
        mapGenerator.generateMap();
    }

    public void switchGorgeProbabilitySliderVisibility(bool flag)
    {
        mapGenerator.isGorgeSliderTurnedOn = flag;
        mapGenerator.generateMap();
    }

    public void changeMapWidth(string newMapWidth)
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

    public void changeMapHeight(string newMapHeight)
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
        float tmpMinMapValue;
        
        // Check if parsing is succesful, assign value only after success
        if (newMinMapValue != "" && float.TryParse(newMinMapValue, out tmpMinMapValue) == true)
        {
            mapGenerator.minMapValue = tmpMinMapValue;

            // Check if Min value is less then Max value, equalize them otherwise
            if (mapGenerator.minMapValue >= mapGenerator.maxMapValue) 
            {
                mapGenerator.maxMapValue = mapGenerator.minMapValue;
                inputFieldMaxMapValue.text = mapGenerator.minMapValue.ToString();

                mapGenerator.minMapValue -= 1;
                inputFieldMinMapValue.text = mapGenerator.minMapValue.ToString();
            }
            mapGenerator.generateMap();
        }
        else
        {
            // Reassign old value in case of invalid input
            inputFieldMinMapValue.text = mapGenerator.minMapValue.ToString();
        }
    }

    public void checkMinMapValue(string newMinMapValue)
    {   
        if (newMinMapValue.Length > INPUT_FIELD_MAP_VALUE_MAX_LENGTH)
        {
            inputFieldMinMapValue.text = newMinMapValue.Substring(0, INPUT_FIELD_MAP_VALUE_MAX_LENGTH); 
        }
    }

    public void changeMaxMapValue(string newMaxMapValue)
    {
        float tmpMaxMapValue;

        // Check if parsing is succesful, assign value only after success
        if (newMaxMapValue != "" && float.TryParse(newMaxMapValue, out tmpMaxMapValue) == true)
        {
            mapGenerator.maxMapValue = tmpMaxMapValue;

            // Check if Max value is bigger then Min value, equalize them otherwise
            if (mapGenerator.maxMapValue <= mapGenerator.minMapValue) 
            {
                mapGenerator.minMapValue = mapGenerator.maxMapValue;
                inputFieldMinMapValue.text = mapGenerator.maxMapValue.ToString();

                mapGenerator.maxMapValue += 1;
                inputFieldMaxMapValue.text = mapGenerator.maxMapValue.ToString();
            }
            mapGenerator.generateMap();
        }
        else
        {
            // Reassign old value in case of invalid input
            inputFieldMaxMapValue.text = mapGenerator.maxMapValue.ToString();
        }
    }

    public void checkMaxMapValue(string newMaxMapValue)
    {   
        if (newMaxMapValue.Length > INPUT_FIELD_MAP_VALUE_MAX_LENGTH)
        {
            inputFieldMaxMapValue.text = newMaxMapValue.Substring(0, INPUT_FIELD_MAP_VALUE_MAX_LENGTH); 
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
            table.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else if (val == 1) 
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.ColorMap;
            plane.SetActive(true);
            mesh.SetActive(false);
            table.SetActive(false);
            meshHeightMultiplier.SetActive(false);
        }
        else if (val == 2)
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.Mesh;
            plane.SetActive(false);
            mesh.SetActive(true);
            table.SetActive(false);
            meshHeightMultiplier.SetActive(true);
        }
        else
        {
            mapGenerator.drawMode = MapGenerator.DrawMode.Table;
            plane.SetActive(false);
            mesh.SetActive(false);
            table.SetActive(true);
            meshHeightMultiplier.SetActive(false);
        }

        mapGenerator.generateMap();
    }

    public void randomSeed()
    {
        mapGenerator.seed = UnityEngine.Random.Range(0, (int)1e9 - 1);
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

    // For Table UI
    public void changeScrollbarHorizontal(float newValue)
    {
        tableUI.upperLeftX = (int)(newValue * mapGenerator.mapHeight);
        if (tableUI.upperLeftX + tableUI.columnsNow > mapGenerator.mapHeight) tableUI.upperLeftX = mapGenerator.mapHeight - tableUI.columnsNow;
        if (mapGenerator.mapHeight - tableUI.columnsNow < 0) tableUI.upperLeftX = 0;
        tableUI.assignValuesToCells(tableUI.noiseMapNow);
    }
    
    public void changeScrollbarVertical(float newValue)
    {
        tableUI.upperLeftY = (int)(newValue * mapGenerator.mapWidth);
        if (tableUI.upperLeftY + tableUI.rowsNow > mapGenerator.mapWidth) tableUI.upperLeftY = mapGenerator.mapWidth - tableUI.rowsNow;
        if (mapGenerator.mapWidth - tableUI.rowsNow < 0) tableUI.upperLeftY = 0;
        tableUI.assignValuesToCells(tableUI.noiseMapNow);
    }

    
}
