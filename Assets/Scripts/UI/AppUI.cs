/*
 * Contains functions for buttons, sliders and dropdowns in app
 */

using UnityEngine;
using UnityEngine.UI;
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
    
    public FlexibleColorPicker fcp1, fcp2, fcp3, fcp4, fcp5, fcp6, fcp7, fcp8;
    public Button button1, button2, button3, button4, button5, button6, button7, button8;



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
        mapGenerator.isPlainProbabilitySliderTurnedOn = flag;
        mapGenerator.generateMap();
    }

    public void switchGorgeProbabilitySliderVisibility(bool flag)
    {
        mapGenerator.isGorgeProbabilitySliderTurnedOn = flag;
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

    public void changeMinMapValueWithoutGenerate()
    {
        inputFieldMinMapValue.text = mapGenerator.minMapValue.ToString();
    }
     public void changeMapWidthWithoutGenerate()
    {
        inputFieldMapWidth.text = mapGenerator.mapWidth.ToString();
    }
    public void changeMapHeightWithoutGenerate()
    {
        inputFieldMapHeight.text = mapGenerator.mapHeight.ToString();
    }
    public void changeMaxMapValueWithoutGenerate()
    {
        inputFieldMaxMapValue.text = mapGenerator.maxMapValue.ToString();
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

    public void turnOffOtherColorPickers(int value)
    {
        fcp1.gameObject.SetActive(value == 1);
        fcp2.gameObject.SetActive(value == 2);
        fcp3.gameObject.SetActive(value == 3);
        fcp4.gameObject.SetActive(value == 4);
        fcp5.gameObject.SetActive(value == 5);
        fcp6.gameObject.SetActive(value == 6);
        fcp7.gameObject.SetActive(value == 7);
        fcp8.gameObject.SetActive(value == 8);
    }

    public void switchFlexibleColorPicker1()
    {
        fcp1.gameObject.SetActive(fcp1.isActiveAndEnabled);
        turnOffOtherColorPickers(1);
    }

    public void switchFlexibleColorPicker2()
    {
        fcp2.gameObject.SetActive(fcp2.isActiveAndEnabled);
        turnOffOtherColorPickers(2);

    }

    public void switchFlexibleColorPicker3()
    {
        fcp3.gameObject.SetActive(fcp3.isActiveAndEnabled);
        turnOffOtherColorPickers(3);
    }

    public void switchFlexibleColorPicker4()
    {
        fcp4.gameObject.SetActive(fcp4.isActiveAndEnabled);
        turnOffOtherColorPickers(4);
    }

    public void switchFlexibleColorPicker5()
    {
        fcp5.gameObject.SetActive(fcp5.isActiveAndEnabled);
        turnOffOtherColorPickers(5);
    }

    public void switchFlexibleColorPicker6()
    {
        fcp6.gameObject.SetActive(fcp6.isActiveAndEnabled);
        turnOffOtherColorPickers(6);
    }

    public void switchFlexibleColorPicker7()
    {
        fcp7.gameObject.SetActive(fcp7.isActiveAndEnabled);
        turnOffOtherColorPickers(7);
    }

    public void switchFlexibleColorPicker8()
    {
        fcp8.gameObject.SetActive(fcp8.isActiveAndEnabled);
        turnOffOtherColorPickers(8);
    }

    public void setColorsOfButtons()
    {
        button1.image.color = mapGenerator.regions[0].color;
        button2.image.color = mapGenerator.regions[1].color;
        button3.image.color = mapGenerator.regions[2].color;
        button4.image.color = mapGenerator.regions[3].color;
        button5.image.color = mapGenerator.regions[4].color;
        button6.image.color = mapGenerator.regions[5].color;
        button7.image.color = mapGenerator.regions[6].color;
        button8.image.color = mapGenerator.regions[7].color;
    }

    public void onExit()
    {
        mapGenerator.regions[0].color = button1.image.color;
        mapGenerator.regions[1].color = button2.image.color;
        mapGenerator.regions[2].color = button3.image.color;
        mapGenerator.regions[3].color = button4.image.color;
        mapGenerator.regions[4].color = button5.image.color;
        mapGenerator.regions[5].color = button6.image.color;
        mapGenerator.regions[6].color = button7.image.color;
        mapGenerator.regions[7].color = button8.image.color;

        turnOffOtherColorPickers(-1);
    }
}
