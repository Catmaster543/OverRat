using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InfColorResolver : MonoBehaviour
{
    
    public Color MatchUpColor(List<Color> coloursSource)
    {
        Debug.Log($"Matching up colors, colours source has this many items: {coloursSource.Count}");
        Color finalColor = new();

        foreach (Color color in coloursSource)
        {
            Debug.Log($"Current color is {color.r}, the result so far {finalColor.r}");
            if (color.r >= finalColor.r)
            {
                Debug.Log("Current r color was larger");
                finalColor.r += color.r / 2;
            }
            else if (color.r <= finalColor.r)
            {
                Debug.Log("Current r color was smaller");
                finalColor.r -= color.r / 2;
            }
            if (color.g >= finalColor.g)
            {
                finalColor.g += color.g / 2;
            }
            else if (color.g <= finalColor.g)
            {
                finalColor.g -= color.g / 2;
            }
            if (color.b >= finalColor.b)
            {
                finalColor.b += color.b / 2;
            }
            else if (color.b <= finalColor.b)
            {
                finalColor.b -= color.b / 2;
            }
        }

        return finalColor;
    }

    public float MatchUpSmoothness(List<float> smoothnessSource)
    {
        float finalSmoothness = new();

        foreach (float smoothness in smoothnessSource)
        {
            if (smoothness >= finalSmoothness)
            {
                finalSmoothness += smoothness / 2;
            }
            else if (smoothness <= finalSmoothness)
            {
                finalSmoothness -= smoothness / 2;
            }
        }

        return finalSmoothness;
    }
}
