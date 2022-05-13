using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<Ingredient> OnIngredientAdded;

    [SerializeField] List<Ingredient> _startIngredients = new List<Ingredient>();
    public List<Ingredient> HavesIngredients { get; private set; }
    
    void Awake()
    {
        HavesIngredients = new List<Ingredient>();

        for (int i = 0; i < _startIngredients.Count; i++)
        {
            AddIngredient(_startIngredients[i]);
        }
    }

    public void AddIngredient(Ingredient newIngredient)
    {
        HavesIngredients.Add(newIngredient);

        OnIngredientAdded?.Invoke(newIngredient);
    }
}
