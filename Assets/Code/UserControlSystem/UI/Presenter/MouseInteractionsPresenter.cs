using UnityEngine;
using System.Linq;

public class MouseInteractionsPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectableObject;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0) return;
        
        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();

        _selectableObject.SetValue(selectable);
    }
}
