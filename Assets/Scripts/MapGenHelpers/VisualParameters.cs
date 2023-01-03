/*
 * Methods for changing map "visual" map parameters, such as
 * 1) how much planes are on the map
 * 2) how much gorges are on the map
 */

using UnityEngine;

public class VisualParameters : MonoBehaviour
{
    public void generatePlain(int x, int y, int width, int heigth, float[,] noiseMap, float probabilityOfPlain) // width mod 6 = 0;
    {
        float avarageHeightOnArea = 0f;
        int numberOfPointsOnArea = 0;

        for (int currentX = x; currentX < x + width; currentX++)
        {
            for (int currentY = y; currentY < y + heigth; currentY++)
            {
                numberOfPointsOnArea++;
                avarageHeightOnArea += noiseMap[currentX, currentY];
            }
        }

        if (numberOfPointsOnArea != 0)
        {
            avarageHeightOnArea = avarageHeightOnArea / numberOfPointsOnArea;
        }

        avarageHeightOnArea = avarageHeightOnArea * (probabilityOfPlain);

        for (int currentX = x; currentX < x + width; currentX++)
        {
            for (int currentY = y; currentY < y + heigth; currentY++)
            {
                if (avarageHeightOnArea > noiseMap[currentX, currentY])
                {
                    noiseMap[currentX, currentY] = avarageHeightOnArea;
                }
            }
        }
    }

    public void generateGorge(int x, int y, int width, int heigth, float[,] noiseMap, float gorgeProbability)
    {
        for (int currentX = x; currentX < x + width; currentX++)
        {
            for (int currentY = y; currentY < y + heigth; currentY++)
            {
                noiseMap[currentX, currentY] = Mathf.Pow((noiseMap[currentX, currentY] - 1f)* (1+gorgeProbability), 3) + 1;
            }
        }
    }
}
