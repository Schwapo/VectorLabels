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
    {
        var label = vectorLabelsAttribute.Labels[property.Name];
        var resolvedLabel = ValueResolver.GetForString(property.Parent, label).GetValue();
        var labelWidth = EditorStyles.label.CalcSize(new GUIContent(resolvedLabel)).x + 3f;

        attributes.Add(new LabelTextAttribute(resolvedLabel));
        attributes.Add(new LabelWidthAttribute(labelWidth));
    }
}
#endif
