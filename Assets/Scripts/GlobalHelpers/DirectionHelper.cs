using UnityEngine;

public static class DirectionHelper
{
    public static readonly Vector2[] Directions8 = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
        new Vector2(1, 1).normalized,
        new Vector2(-1, 1).normalized,
        new Vector2(1, -1).normalized,
        new Vector2(-1, -1).normalized
    };

    public static Vector2 GetClosestDirection(Vector2 inputDir)
    {
        Vector2 closest = Directions8[0];
        float maxDot = Vector2.Dot(inputDir, closest);

        for (int i = 1; i < Directions8.Length; i++)
        {
            float dot = Vector2.Dot(inputDir, Directions8[i]);
            if (dot > maxDot)
            {
                maxDot = dot;
                closest = Directions8[i];
            }
        }

        return closest;
    }
}
