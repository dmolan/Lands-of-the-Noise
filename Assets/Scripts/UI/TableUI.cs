/*
    TODO: FIX ISSUE WITH SLIDERS WHEN VALUES ARE LESS THEN 8
*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableUI : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public ScaleUI scaleUI;

    public GameObject column0, column1, column2, column3, column4, column5, column6, column7, column8;
    public GameObject table;

    public Scrollbar scrollbarHorizontal, scrollbarVertical;

    // Name is made of "text" + "y" + "x"
    public TMP_Text text01, text02, text03, text04, text05, text06, text07, text08;
    public TMP_Text text10, text11, text12, text13, text14, text15, text16, text17, text18;
    public TMP_Text text20, text21, text22, text23, text24, text25, text26, text27, text28;
    public TMP_Text text30, text31, text32, text33, text34, text35, text36, text37, text38;
    public TMP_Text text40, text41, text42, text43, text44, text45, text46, text47, text48;
    public TMP_Text text50, text51, text52, text53, text54, text55, text56, text57, text58;
    public TMP_Text text60, text61, text62, text63, text64, text65, text66, text67, text68;
    public TMP_Text text70, text71, text72, text73, text74, text75, text76, text77, text78;
    public TMP_Text text80, text81, text82, text83, text84, text85, text86, text87, text88;

    public int upperLeftX = 0, upperLeftY = 0;
    public int columnsNow = 8, rowsNow = 6;
    public float[,] noiseMapNow;



    public void setAmountOfColumns(int amountOfColumns)
    {
        columnsNow = amountOfColumns;
        column1.SetActive(amountOfColumns >= 1);
        column2.SetActive(amountOfColumns >= 2);
        column3.SetActive(amountOfColumns >= 3);
        column4.SetActive(amountOfColumns >= 4);
        column5.SetActive(amountOfColumns >= 5);
        column6.SetActive(amountOfColumns >= 6);
        column7.SetActive(amountOfColumns >= 7);
        column8.SetActive(amountOfColumns >= 8);
    }

    public void assignValuesToCells(float[,] noiseMap)
    {
        noiseMapNow = noiseMap;

        if (mapGenerator.mapHeight + upperLeftY >= 1) text10.text = (upperLeftY+1).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 2) text20.text = (upperLeftY+2).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 3) text30.text = (upperLeftY+3).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 4) text40.text = (upperLeftY+4).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 5) text50.text = (upperLeftY+5).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 6) text60.text = (upperLeftY+6).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 7) text70.text = (upperLeftY+7).ToString();
        if (mapGenerator.mapHeight + upperLeftY >= 8) text80.text = (upperLeftY+8).ToString();

        text01.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 1);
        text02.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 2);
        text03.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 3);
        text04.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 4);
        text05.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 5);
        text06.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 6);
        text07.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 7);
        text08.gameObject.SetActive(mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftX >= 1) text01.text = (upperLeftX+1).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 2) text02.text = (upperLeftX+2).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 3) text03.text = (upperLeftX+3).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 4) text04.text = (upperLeftX+4).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 5) text05.text = (upperLeftX+5).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 6) text06.text = (upperLeftX+6).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 7) text07.text = (upperLeftX+7).ToString();
        if (mapGenerator.mapWidth + upperLeftX >= 8) text08.text = (upperLeftX+8).ToString();

        text10.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1);
        text20.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2);
        text30.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3);
        text40.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4);
        text50.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5);
        text60.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6);
        text70.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7);
        text80.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8);



        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 1) text11.text = (noiseMap[upperLeftY+0, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 2) text12.text = (noiseMap[upperLeftY+0, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 3) text13.text = (noiseMap[upperLeftY+0, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 4) text14.text = (noiseMap[upperLeftY+0, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 5) text15.text = (noiseMap[upperLeftY+0, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 6) text16.text = (noiseMap[upperLeftY+0, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 7) text17.text = (noiseMap[upperLeftY+0, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 8) text18.text = (noiseMap[upperLeftY+0, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text11.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 1);
        text12.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 2);
        text13.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 3);
        text14.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 4);
        text15.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 5);
        text16.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 6);
        text17.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 7);
        text18.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 1 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 1) text21.text = (noiseMap[upperLeftY+1, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 2) text22.text = (noiseMap[upperLeftY+1, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 3) text23.text = (noiseMap[upperLeftY+1, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 4) text24.text = (noiseMap[upperLeftY+1, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 5) text25.text = (noiseMap[upperLeftY+1, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 6) text26.text = (noiseMap[upperLeftY+1, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 7) text27.text = (noiseMap[upperLeftY+1, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 8) text28.text = (noiseMap[upperLeftY+1, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text21.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 1);
        text22.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 2);
        text23.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 3);
        text24.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 4);
        text25.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 5);
        text26.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 6);
        text27.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 7);
        text28.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 2 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 1) text31.text = (noiseMap[upperLeftY+2, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 2) text32.text = (noiseMap[upperLeftY+2, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 3) text33.text = (noiseMap[upperLeftY+2, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 4) text34.text = (noiseMap[upperLeftY+2, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 5) text35.text = (noiseMap[upperLeftY+2, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 6) text36.text = (noiseMap[upperLeftY+2, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 7) text37.text = (noiseMap[upperLeftY+2, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 8) text38.text = (noiseMap[upperLeftY+2, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text31.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 1);
        text32.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 2);
        text33.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 3);
        text34.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 4);
        text35.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 5);
        text36.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 6);
        text37.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 7);
        text38.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 3 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 1) text41.text = (noiseMap[upperLeftY+3, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 2) text42.text = (noiseMap[upperLeftY+3, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 3) text43.text = (noiseMap[upperLeftY+3, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 4) text44.text = (noiseMap[upperLeftY+3, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 5) text45.text = (noiseMap[upperLeftY+3, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 6) text46.text = (noiseMap[upperLeftY+3, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 7) text47.text = (noiseMap[upperLeftY+3, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 8) text48.text = (noiseMap[upperLeftY+3, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text41.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 1);
        text42.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 2);
        text43.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 3);
        text44.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 4);
        text45.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 5);
        text46.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 6);
        text47.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 7);
        text48.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 4 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 1) text51.text = (noiseMap[upperLeftY+4, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 2) text52.text = (noiseMap[upperLeftY+4, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 3) text53.text = (noiseMap[upperLeftY+4, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 4) text54.text = (noiseMap[upperLeftY+4, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 5) text55.text = (noiseMap[upperLeftY+4, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 6) text56.text = (noiseMap[upperLeftY+4, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 7) text57.text = (noiseMap[upperLeftY+4, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 8) text58.text = (noiseMap[upperLeftY+4, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text51.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 1);
        text52.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 2);
        text53.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 3);
        text54.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 4);
        text55.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 5);
        text56.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 6);
        text57.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 7);
        text58.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 5 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 1) text61.text = (noiseMap[upperLeftY+5, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 2) text62.text = (noiseMap[upperLeftY+5, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 3) text63.text = (noiseMap[upperLeftY+5, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 4) text64.text = (noiseMap[upperLeftY+5, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 5) text65.text = (noiseMap[upperLeftY+5, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 6) text66.text = (noiseMap[upperLeftY+5, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 7) text67.text = (noiseMap[upperLeftY+5, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 8) text68.text = (noiseMap[upperLeftY+5, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text61.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 1);
        text62.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 2);
        text63.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 3);
        text64.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 4);
        text65.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 5);
        text66.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 6);
        text67.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 7);
        text68.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 6 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 1) text71.text = (noiseMap[upperLeftY+6, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 2) text72.text = (noiseMap[upperLeftY+6, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 3) text73.text = (noiseMap[upperLeftY+6, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 4) text74.text = (noiseMap[upperLeftY+6, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 5) text75.text = (noiseMap[upperLeftY+6, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 6) text76.text = (noiseMap[upperLeftY+6, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 7) text77.text = (noiseMap[upperLeftY+6, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 8) text78.text = (noiseMap[upperLeftY+6, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text71.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 1);
        text72.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 2);
        text73.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 3);
        text74.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 4);
        text75.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 5);
        text76.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 6);
        text77.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 7);
        text78.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 7 && mapGenerator.mapHeight + upperLeftX >= 8);

        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 1) text81.text = (noiseMap[upperLeftY+7, upperLeftX+0] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 2) text82.text = (noiseMap[upperLeftY+7, upperLeftX+1] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 3) text83.text = (noiseMap[upperLeftY+7, upperLeftX+2] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 4) text84.text = (noiseMap[upperLeftY+7, upperLeftX+3] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 5) text85.text = (noiseMap[upperLeftY+7, upperLeftX+4] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 6) text86.text = (noiseMap[upperLeftY+7, upperLeftX+5] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 7) text87.text = (noiseMap[upperLeftY+7, upperLeftX+6] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();
        if (mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 8) text88.text = (noiseMap[upperLeftY+7, upperLeftX+7] * (mapGenerator.maxMapValue - mapGenerator.minMapValue) + mapGenerator.minMapValue).ToString();

        text81.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 1);
        text82.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 2);
        text83.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 3);
        text84.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 4);
        text85.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 5);
        text86.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 6);
        text87.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 7);
        text88.gameObject.SetActive(mapGenerator.mapWidth + upperLeftY >= 8 && mapGenerator.mapHeight + upperLeftX >= 8);
    }
}
