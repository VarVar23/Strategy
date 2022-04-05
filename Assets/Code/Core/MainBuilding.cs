using UnityEngine;

public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
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
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private MeshRenderer _meshRenderer;
    private float _health;

    private void Awake() => _health = _maxHealth;

    public void ProduceUnit()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 0.25f, Random.Range(-5, 5));
        Instantiate(_unitPrefab, randomPosition, Quaternion.identity, _unitsParent);
    }
}
