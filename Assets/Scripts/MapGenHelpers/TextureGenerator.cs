/*
 * Constructs 2D texture by the given parameters
*/
using UnityEngine;

public class TextureGenerator
{
    static Texture2D mapTexture2D;
    static Color[] colorMap;



    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        mapTexture2D = new Texture2D(width, height);
        mapTexture2D.filterMode = FilterMode.Point;
        mapTexture2D.wrapMode = TextureWrapMode.Clamp;
        mapTexture2D.SetPixels(colorMap);
        mapTexture2D.Apply();
        
        return mapTexture2D;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        colorMap = new Color[width * height];
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                colorMap[y*width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
       
        return TextureFromColorMap(colorMap, width, height);
    }
}
