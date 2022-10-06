using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, 
    int octaves, float persistance, float lacunarity) 
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (scale <= 0) scale = 0.0001f;

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y = 0; y < mapHeight; ++y)
        {
            for (int x = 0; x < mapHeight; ++x)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeigh = 0;
                for (int i = 0; i < octaves; ++i)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinValue = 2*Mathf.PerlinNoise(sampleX, sampleY)-1;
                    noiseHeigh += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeigh > maxNoiseHeight) maxNoiseHeight = noiseHeigh;
                else if (noiseHeigh < minNoiseHeight) minNoiseHeight = noiseHeigh;

                noiseMap[x, y] = noiseHeigh;
            }
        }

        for (int y = 0; y < mapHeight; ++y)
        {
            for (int x = 0; x < mapHeight; ++x)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        
        return noiseMap;
    }
}
