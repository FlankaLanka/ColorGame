using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorTag : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private ColorHelper.WorldColors _colorType = ColorHelper.WorldColors.White;

    public ColorHelper.WorldColors colorType
    {
        get => _colorType;
        set
        {
            _colorType = value;
            sr.color = ColorHelper.colorsMap[_colorType];
        }
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = ColorHelper.colorsMap[_colorType];
    }
}
