using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct IngredientAmount
{
    public Ingredient ingredient;
    [Range(1,100)]
    public int amount;
}

[CreateAssetMenu(fileName = "IngredientData", menuName = "Craft Recipe/Recipe")]
public class CraftRecipe : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name = "Recipe";
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<IngredientAmount> needsIngredients;
    [SerializeField] private List<IngredientAmount> result;

    public string Id { get => _id; }
    public string Name { get => _name; }
    public Sprite Icon { get => _icon;}
    public GameObject Prefab { get => _prefab; }
    public List<IngredientAmount> NeedsIngredients { get => needsIngredients; }
    public List<IngredientAmount> Result { get => result; }
}
