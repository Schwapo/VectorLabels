using Sirenix.OdinInspector.Editor;

[assembly: RegisterStateUpdater(typeof(VectorLabelsAttributeStateUpdater))]

public class VectorLabelsAttributeStateUpdater : AttributeStateUpdater<VectorLabelsAttribute>
{
    protected override void Initialize()
    {
        Property.Tree.OnPropertyValueChanged += (property, selectionIndex) => Property.RefreshSetup();
    }
}
