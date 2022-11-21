/*
 *  This code is executed only in UnityEditor.
 *  It's purpose is redrawing map on:
 *  1) value change
 *  2) GUI Button "Generate" pressed.
*/
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if(DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.generateMap();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            mapGen.generateMap();
        }
    }
}
