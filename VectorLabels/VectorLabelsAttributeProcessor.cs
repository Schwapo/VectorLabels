#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VectorLabelsAttributeProcessor : OdinAttributeProcessor
{
    private VectorLabelsAttribute vectorLabelsAttribute;

    public override bool CanProcessSelfAttributes(InspectorProperty property)
    {
        vectorLabelsAttribute = property.Parent?.GetAttribute<VectorLabelsAttribute>();
        return vectorLabelsAttribute != null;
    }

    public override void ProcessSelfAttributes(InspectorProperty property, List<Attribute> attributes)
        => ChangeLabel(property.Parent, vectorLabelsAttribute.Labels[property.Name], ref attributes);

    private void ChangeLabel(InspectorProperty property, string value, ref List<Attribute> attributes)
    {
        var label = ValueResolver.GetForString(property, value).GetValue();
        attributes.Add(new LabelTextAttribute(label));
        attributes.Add(new LabelWidthAttribute(LabelWidth(label)));
    }

    private float LabelWidth(string label)
        => EditorStyles.label.CalcSize(new GUIContent(label)).x;
}
#endif
