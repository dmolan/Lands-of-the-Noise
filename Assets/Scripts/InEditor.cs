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
        mapGen.GenerateMap();
    }
    
    void Update()
    {
        if (mapGen.drawMode != prevDrawMode)
        {
            prevDrawMode = mapGen.drawMode;
            if (mapGen.drawMode == MapGenerator.DrawMode.Mesh)
            {
                mapGen.GenerateMap();
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