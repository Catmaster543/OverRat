using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InfColorResolver : MonoBehaviour
{
    
    public Color MatchUpColor(List<Color> coloursSource)
    {
        Color finalColor = new();

        foreach (Color color in coloursSource)
        {
            if (color.r >= finalColor.r)
            {
                finalColor.r += color.r / 2;
            }
            else if (color.r <= finalColor.r)
            {
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
