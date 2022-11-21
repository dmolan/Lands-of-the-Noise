/*  
 *  This code is executed only in UnityEditor.
 *  It's purpose is to draw map when
 *  1) editor starts;
 *  2) DrawMode is changed in editor.
*/
using UnityEngine;

[ExecuteInEditMode]
public class MapRedraw : MonoBehaviour
{
    public MapGenerator mapGen;
    // public GameObject plane;
    // public GameObject mesh;
    // private MapGenerator.DrawMode prevDrawMode = MapGenerator.DrawMode.NoiseMap;



    void Start()
    {
        mapGen.generateMap();
    }
    
    // This part is removed for optimistaion reasons
    /*
    void Update()
    {
        if (mapGen.drawMode != prevDrawMode)
        {
            prevDrawMode = mapGen.drawMode;
            if (mapGen.drawMode == MapGenerator.DrawMode.Mesh)
            {
                mapGen.generateMap();
                plane.SetActive(false);
                mesh.SetActive(true);
            }
            else
            {
                plane.SetActive(true); 
                mesh.SetActive(false); 
            }
        }
    }
    */
}
