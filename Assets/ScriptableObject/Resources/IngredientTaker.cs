using UnityEngine;

public class IngredientTaker : MonoBehaviour
{
    [SerializeField] private Ingredient _ingredientToAdd;
    [SerializeField] private Inventory _currentInventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInventory.AddIngredient(_ingredientToAdd);
        }
    }
}
