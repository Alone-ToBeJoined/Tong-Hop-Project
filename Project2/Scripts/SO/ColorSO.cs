using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "SO/ColorSO", order = 1)]
public class ColorSO : ScriptableObject
{
    public List<Material> materials;
    public ColorType brickColor;

    public Material GetMaterial(ColorType colorType)
    {
        return materials[(int)colorType];
    }    
}

public enum ColorType
{
    Blue = 0,
    Green = 1,
    Red = 2,
    Yellow = 3,
    None = 100
}