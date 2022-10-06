using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, 
    int octaves, float persistance, float lacunarity, Vector2 offset) 
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octavesOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; ++i)
        {
            float offesX = prng.Next(-100000, 100000) + offset.x;
            float offesY = prng.Next(-100000, 100000) + offset.y;
            octavesOffsets[i] = new Vector2 (offesX, offesY);
        }

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
                    float sampleX = x / scale * frequency + octavesOffsets[i].x;
                    float sampleY = y / scale * frequency + octavesOffsets[i].y;

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
