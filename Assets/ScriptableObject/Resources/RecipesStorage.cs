using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesStorage : MonoBehaviour
{
    private const string PATH_TO_SCRIPTABLEOBJECTS_RECIPES = "CraftingRecipes";


    [SerializeField] List<CraftRecipe> _allCraftresipes;        //список хранения рецептов
    [SerializeField] private CraftRecipe _requiredRecipes;

    public List<CraftRecipe> AllCraftresipes { get => _allCraftresipes; private set => _allCraftresipes = value; }
    public CraftRecipe RequiredRecipes { get => _requiredRecipes; private set => _requiredRecipes = value; }

    // Start is called before the first frame update
    void Start()
    {
        AllCraftresipes = new List<CraftRecipe>();
        //заполнение массива простых ингредиентов
        var recipes = Resources.LoadAll<CraftRecipe>(PATH_TO_SCRIPTABLEOBJECTS_RECIPES);
        AddRecipiesToList(AllCraftresipes, recipes);
    }

    private void AddRecipiesToList(List<CraftRecipe> listTypeOfRecipes, CraftRecipe[] recipes)
    {
        if (listTypeOfRecipes != null)
        {
            foreach (var item in recipes)
            {
                listTypeOfRecipes.Add(item);
            }
        }
    }
    
    //ToDo
    public CraftRecipe GetRequiredRecipies(Ingredient firstIngredient, Ingredient secondIngredient)
    {
        return null;
    }
}
