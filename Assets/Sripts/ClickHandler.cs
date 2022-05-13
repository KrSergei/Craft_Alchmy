using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private IngredientStorage _parentGeneratedIngredient;

    private void Start()
    {
        //��������� ������ �� ��������� ������������
        _parentGeneratedIngredient = FindObjectOfType<IngredientStorage>();
    }

    private void OnMouseDown()
    {
        GetPikedIngredient();
    }

    private void GetPikedIngredient()
    {
        GameObject obj = GetComponent<Transform>().gameObject;
        //����� ������ ��� ����������� ����� ���������� �������
        EventController.onPickedIngredient?.Invoke(obj);
    }
}
