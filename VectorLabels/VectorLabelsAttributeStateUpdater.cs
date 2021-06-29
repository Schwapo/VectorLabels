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
            previousLabels[child.Name] = ValueResolver
                .GetForString(Property, vectorLabelsAttribute.Labels[child.Name])
                .GetValue();
        }
    }

    public override void OnStateUpdate()
    {
        foreach (var child in Property.Children)
        {
            var label = ValueResolver
                .GetForString(Property, vectorLabelsAttribute.Labels[child.Name])
                .GetValue();

            if (label != previousLabels[child.Name])
            {
                previousLabels[child.Name] = label;
                Property.RefreshSetup();
            }
        }
    }
}
