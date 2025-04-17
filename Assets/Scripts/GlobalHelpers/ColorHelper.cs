using System.Collections.Generic;
using UnityEngine;

public static class ColorHelper
{
    public enum WorldColors
    {
        White,
        Red,
        Blue,
        Yellow,
        Green,
        Purple,
        Orange,
        Black
    }

    public static readonly Dictionary<WorldColors, Color> colorsMap = new()
    {
        { WorldColors.White, Color.white },
        { WorldColors.Red, Color.red },
        { WorldColors.Blue, Color.blue },
        { WorldColors.Yellow, Color.yellow },
        { WorldColors.Green, Color.green },
        { WorldColors.Purple, new Color(0.6f, 0f, 0.6f) },
        { WorldColors.Orange, new Color(1f, 0.5f, 0f) },
        { WorldColors.Black, Color.black }
    };

    public static bool Matches(WorldColors c1, WorldColors c2)
    {
        return c1 == c2;
    }
}
