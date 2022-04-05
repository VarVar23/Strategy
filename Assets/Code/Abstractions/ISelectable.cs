using UnityEngine;

public interface ISelectable 
{
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }
    MeshRenderer MeshRenderer { get; }
    Material MaterialSelected { get; }
    Material MaterialDeselected { get; }
}
