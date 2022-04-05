using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SelectableValue", menuName = "Config/SelectableValue", order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public Action<ISelectable> OnSelected;

    public void SetValue(ISelectable selected)
    {
        CurrentValue = selected;
        OnSelected?.Invoke(selected);
    }
}