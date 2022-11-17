/*  
 *  This code is executed only in UnityEditor.
 *  It's purpose is to draw map on editor start and when DrawMode is changed in editor.
*/
using UnityEngine;

[ExecuteInEditMode]
public class InEditor : MonoBehaviour
{
    public MapGenerator mapGen;
    public GameObject plane;
    public GameObject mesh;

    private MapGenerator.DrawMode prevDrawMode = MapGenerator.DrawMode.NoiseMap;

    void Start()
    {
        mapGen.generateMap();
    }
    
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
}