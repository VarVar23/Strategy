using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableObject;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (_eventSystem.IsPointerOverGameObject()) return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0) return;
        
        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectableObject.SetValue(selectable);
    }
}
