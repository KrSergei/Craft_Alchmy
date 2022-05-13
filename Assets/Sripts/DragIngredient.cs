using UnityEngine;

public class DragIngredient : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _zCoord;
    private void OnMouseDown()
    {
        _zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePpoint = Input.mousePosition;
        mousePpoint.z = _zCoord;
        return Camera.main.ScreenToWorldPoint(mousePpoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _offset;
    }
}
