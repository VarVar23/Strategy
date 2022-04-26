using UnityEngine;

public class Chomper : MonoBehaviour, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Material MaterialSelected => _materialSelected;
    public Material MaterialDeselected => _materialDeselected;
    public MeshRenderer MeshRenderer => _meshRenderer;


    [SerializeField] private float _maxHealth;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Material _materialSelected;
    [SerializeField] private Material _materialDeselected;
    [SerializeField] private MeshRenderer _meshRenderer;
    private float _health;

    private void Awake() => _health = _maxHealth;
}

