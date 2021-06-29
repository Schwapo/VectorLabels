using UnityEngine;

public class VectorLabelsExample : MonoBehaviour
{
    [VectorLabels("X", "Y", "Z", "Time")]
    public Vector4 vec4;

    [VectorLabels("Width", "Height", "Depth")]
    public Vector3 vec3;

    [VectorLabels("$GetXValue", "$GetYValue")]
    public Vector2 vec2;

    public bool niceName;

    private string GetXValue() => niceName ? "Resolved X" : "ResolvedX";
    private string GetYValue() => niceName ? "Resolved Y" : "ResolvedY";
}
