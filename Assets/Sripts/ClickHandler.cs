using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private IngredientStorage _parentGeneratedIngredient;

    private void Start()
    {
        //получение ссылки на хранителя ингредиентов
        _parentGeneratedIngredient = FindObjectOfType<IngredientStorage>();
    }

    private void OnMouseDown()
    {
        GetPikedIngredient();
    }

    private void GetPikedIngredient()
    {
        GameObject obj = GetComponent<Transform>().gameObject;
        //вызов метода ппо определению имени выбранного объекта
        EventController.onPickedIngredient?.Invoke(obj);
    }
}
