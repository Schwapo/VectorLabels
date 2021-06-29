using System;
using System.Collections.Generic;
using System.Diagnostics;

[Conditional("UNITY_EDITOR")]
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class VectorLabelsAttribute : Attribute
{
    public Dictionary<string, string> Labels = new Dictionary<string, string>();

    public VectorLabelsAttribute(string x = "X", string y = "Y", string z = "Z", string w = "W")
        => (Labels["x"], Labels["y"], Labels["z"], Labels["w"]) = (x, y, z, w);
}
