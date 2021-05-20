#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEditor;

public class VectorLabelsAttributeProcessor : OdinAttributeProcessor
{
    public override bool CanProcessSelfAttributes(InspectorProperty property)
        => property.Parent?.Attributes.HasAttribute<VectorLabelsAttribute>() ?? false;

    public override void ProcessSelfAttributes(InspectorProperty property, List<Attribute> attributes)
    {
        var attribute = property.Parent.GetAttribute<VectorLabelsAttribute>();
        ChangeLabel(property.Parent, attribute.labels[property.Name], ref attributes);
    }

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