using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using System.Collections.Generic;

[assembly: RegisterStateUpdater(typeof(VectorLabelsAttributeStateUpdater))]

public class VectorLabelsAttributeStateUpdater : AttributeStateUpdater<VectorLabelsAttribute>
{
    private VectorLabelsAttribute vectorLabelsAttribute;
    private Dictionary<string, string> previousLabels;

    protected override void Initialize()
    {
        vectorLabelsAttribute = Property.GetAttribute<VectorLabelsAttribute>();
        previousLabels = new Dictionary<string, string>();

        foreach (var child in Property.Children)
        {
            previousLabels[child.Name] = GetResolvedVectorLabel(Property, child.Name);
        }
    }

    public override void OnStateUpdate()
    {
        foreach (var child in Property.Children)
        {
            var label = GetResolvedVectorLabel(Property, child.Name);

            if (label != previousLabels[child.Name])
            {
                previousLabels[child.Name] = label;
                child.RefreshSetup();
            }
        }
    }

    private string GetResolvedVectorLabel(InspectorProperty property, string label)
        => ValueResolver.GetForString(property, vectorLabelsAttribute.Labels[label]).GetValue();
}
