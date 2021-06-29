# VectorLabels

### Requires [Odin Inspector](https://odininspector.com/)

Lets you change the labels of unitys `Vector2`, `Vector3` and `Vector4` types  
to whatever you like using normal strings or [Odin Inspectors] [ValueResolvers]


### Examples
```CSharp
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
```

![](Example.png)

### Usage
Simply put the downloaded VectorLabels folder in your project
and start using the attribute as in the example file.
You can move the files, but make sure that `VectorLabelsAttribute.cs`
is not in an editor folder or it will be removed during build, causing errors.

[Odin Inspector]: https://odininspector.com/
[Odin Inspectors]: https://odininspector.com/
[ValueResolvers]: https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1
