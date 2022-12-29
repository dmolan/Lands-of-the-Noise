/*
 * Constructs Mesh Data (triangles, vertices, uvs) for the Map Display from Height Map
 */

using UnityEngine;

public static class MeshGenerator 
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve heightCurve)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        // For centering mesh on the screen
        float topLeftX = (width - 1) / -2f;
        float topLeftZ = (height - 1) / 2f;

        MeshData meshData = new MeshData(width, height);
        
        /*
        Forming triangles: 0,4,3; 4,0,1; 1,5,4; 5,1,2; ...
        0 - 1 - 2     i    i+1    ... |
        | \ | \ |                     |
        3 - 4 - 5     i+w  i+w+1  ... | -> triangles: i,i+w+1,i+w; i+w+1,i,i+1; ...
        | \ | \ |                     |
        6 - 7 - 8     i+2w i+2w+1 ... |

        We also don't need to start forming triangles from 2,5,6,7,8
        */

        int vertexIndex = 0;
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplier, topLeftZ - y);
                meshData.uvs[vertexIndex] = new Vector2(x/(float)width, y/(float)height);

                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex+width+1, vertexIndex+width);
                    meshData.AddTriangle(vertexIndex+width+1, vertexIndex, vertexIndex+1);
                }
                
                ++vertexIndex;
            }
        }

        return meshData;
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    int triangleIndex;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];

        // (meshWidth-1)*(meshHeight-1) - amount of squares, 6 - triangle sides in square        
        triangles = new int[(meshWidth-1)*(meshHeight-1)*6];
        triangleIndex = 0;
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex+1] = b;
        triangles[triangleIndex+2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // This is needed for lighting to work correctly with new mesh
        mesh.RecalculateNormals();

        return mesh;
    }
}
