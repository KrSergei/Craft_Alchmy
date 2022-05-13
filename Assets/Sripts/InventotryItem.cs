using System.Collections.Generic;
using UnityEngine;

public class InventotryItem : MonoBehaviour
{
    [SerializeField] List<Ingredient> _ingredients;
    [SerializeField] Transform _itemsParent;
    [SerializeField] ItemSlot[] _itemsSlots;

    private void OnValidate()
    {
        if (_itemsParent != null)
            _itemsSlots = _itemsParent.GetComponentsInChildren<ItemSlot>();
        ReloadUI();
    }
    private void ReloadUI()
    {
        int i = 0;
        for (; i < _ingredients.Count && i <_itemsSlots.Length; i++)
        {
            _itemsSlots[i].Ingredient = _ingredients[i];
        }
        for (; i < _itemsSlots.Length; i++)
        {
            _itemsSlots[i].Ingredient = null;
        }
    }

    public bool AddItem(Ingredient ingredient)
    {
        if (IsFull()) return false;
        _ingredients.Add(ingredient);
        ReloadUI();
        return true;
    }

    public bool RemoveItem(Ingredient ingredient)
    {
        if (_ingredients.Remove(ingredient))
        {
            ReloadUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return _ingredients.Count >= _itemsSlots.Length;
    }
}
