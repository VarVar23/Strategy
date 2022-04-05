using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomLeftUIPresenter : MonoBehaviour
{
    [SerializeField] private Image _selectedIcon;
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private TextMeshProUGUI _textHP;
    [SerializeField] private Image _sliderBackground;
    [SerializeField] private Image _sliderFillImage;
    [SerializeField] private SelectableValue _selectedValue;
    private ISelectable _lastSelectable;

    private void Start()
    {
        _selectedValue.OnSelected += OnSelected;
        OnSelected(_selectedValue.CurrentValue);
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_lastSelectable != null) _lastSelectable.MeshRenderer.material = _lastSelectable.MaterialDeselected;

        bool select = selectable != null;

        _selectedIcon.enabled = select;
        _sliderHP.gameObject.SetActive(select);
        _textHP.enabled = select;

        if(select)
        {
            selectable.MeshRenderer.material = selectable.MaterialSelected;
            _selectedIcon.sprite = selectable.Icon;
            _textHP.text = $"{selectable.Health}/{selectable.MaxHealth}";
            _sliderHP.minValue = 0;
            _sliderHP.maxValue = selectable.MaxHealth;
            _sliderHP.value = selectable.Health;
            var color = Color.Lerp(Color.red, Color.green, selectable.Health / selectable.MaxHealth);
            _sliderBackground.color = color * 0.5f;
            _sliderFillImage.color = color;
        }

        _lastSelectable = selectable;
    }
}
