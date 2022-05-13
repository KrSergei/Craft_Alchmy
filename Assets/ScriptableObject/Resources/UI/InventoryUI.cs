using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _currentInventory;
    [SerializeField] private RectTransform _ingredientPanel;

    public Action<Ingredient> OnIngredientAdded { get; private set; }

    private void Start()
    {
        _currentInventory.OnIngredientAdded += OnIngredientAdded;
        ReDraw();
    }

    //private void OnIngredientAdded(Ingredient obj) => ReDraw();
    //{
    //    throw new System.NotImplementedException;
    //}

    private void ReDraw()
    {
        for (int i = 0; i < _currentInventory.HavesIngredients.Count; i++)
        {
            var ingredient = _currentInventory.HavesIngredients[i];
            var iconIngredient = new GameObject("Icon");
            iconIngredient.AddComponent<Image>().sprite = ingredient.Icon;
            iconIngredient.transform.SetParent(_ingredientPanel);
        }
    }
}
