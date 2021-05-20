using UnityEngine;

public class VectorLabelsExample : MonoBehaviour
{
    [VectorLabels("X", "Y", "Z", "Time")]
    public Vector4 vec4;

    [VectorLabels("Width", "Height", "Depth")]
    public Vector3 vec3;

    [VectorLabels("Tiling X", "Tiling Y")]
    public Vector2 vec2;
}