using Sirenix.OdinInspector.Editor;

[assembly: RegisterStateUpdater(typeof(VectorLabelsAttributeStateUpdater))]

public class VectorLabelsAttributeStateUpdater : AttributeStateUpdater<VectorLabelsAttribute>
{
    protected override void Initialize()
        => Property.Tree.OnPropertyValueChanged += (prop, idx) => Property.RefreshSetup();
}