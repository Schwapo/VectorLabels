using UnityEngine;

public class VectorLabelsExample : MonoBehaviour
{
    [VectorLabels("X", "Y", "Z", "Time")]
    public Vector4 vec4;

    [VectorLabels("Width", "Height", "Depth")]
    public Vector3 vec3;

    [VectorLabels("@GetXValue()", "@GetYValue()")]
    public Vector2 vec2;

    private static string GetXValue() => "Resolved X";
    private static string GetYValue() => "Resolved Y";
}
