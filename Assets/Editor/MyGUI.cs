/*
 *  This code is executed only in UnityEditor.
 *  It's purpose is redrawing map on:
 *  1) value change
 *  2) GUI Button "Generate" pressed.
*/
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MyGUI : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        // If value changed in ispector and AutoUpdate is on, calls generateMap()
        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate) mapGen.generateMap();
        }

        // If custom redraw buttom is pressed, calls generateMap()
        if (GUILayout.Button("Generate"))
        {
            mapGen.generateMap();
        }
    }
}
