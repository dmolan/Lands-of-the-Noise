﻿/*
 * By the given parameters returns noiseMap (using built-in Perlin Noise)
 */

using UnityEngine;

public static class Noise
{
    public static float[,] generateNoiseMap(int seed, int mapWidth, int mapHeight, int octaves,
    float persistance, float lacunarity, float noiseScale, Vector2 offset) 
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        // prng - Pseudo Random Number Generator
        System.Random prng = new System.Random(seed);
        Vector2[] octavesOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; ++i)
        {
            float offesX = prng.Next(-100000, 100000) + offset.x;
            float offesY = prng.Next(-100000, 100000) + offset.y;
            octavesOffsets[i] = new Vector2 (offesX, offesY);
        }

        if (noiseScale <= 0) noiseScale = 0.0001f;

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; ++y)
        {
            for (int x = 0; x < mapWidth; ++x)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeigh = 0;
                for (int i = 0; i < octaves; ++i)
                {
                    float sampleX = (x - halfWidth) / noiseScale * frequency + octavesOffsets[i].x;
                    float sampleY = (y - halfHeight) / noiseScale * frequency + octavesOffsets[i].y;

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
            for (int x = 0; x < mapWidth; ++x)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        
        return noiseMap;
    }
}
