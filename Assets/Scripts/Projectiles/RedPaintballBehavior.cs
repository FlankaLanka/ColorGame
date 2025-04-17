using UnityEngine;

public class RedPaintballBehavior : PaintballBase
{
    [Header("Red Paintball Effect Settings")]
    [SerializeField] private GameObject redExplosionEffectPrefab; // Reference to a red explosion effect prefab

    protected override void Awake()
    {
        colorType = ColorHelper.WorldColors.Red;
        base.Awake();
        // Ensure the color type is set to red
    }

    protected override void DoSomething()
    {
        // Perform a red-specific action, like creating a red explosion effect
        Debug.Log("Red Paintball hit something!");

        // Create the red explosion effect at the paintball's position
        if (redExplosionEffectPrefab != null)
        {
            Instantiate(redExplosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Optionally: Change the color of the collided object to red
        // For example, if the paintball hits a target that can change its color:
        ColorTag targetTag = GetComponent<ColorTag>();
        if (targetTag != null)
        {
            targetTag.colorType = ColorHelper.WorldColors.Red;
            targetTag.GetComponent<SpriteRenderer>().color = ColorHelper.colorsMap[ColorHelper.WorldColors.Red];
        }

        // Destroy the paintball after effect
        Destroy(gameObject);
    }
}
