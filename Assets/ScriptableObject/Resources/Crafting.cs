using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] private IngredientStorage _ingredientStorage;
    [SerializeField] private Ingredient _maintIngtredient;
    [SerializeField] private Ingredient _secondIngtredient;
    [SerializeField] private RecipesStorage _recipesStorage;

    private void Start()
    {
        _ingredientStorage = FindObjectOfType<IngredientStorage>();
        _recipesStorage = GetComponent<RecipesStorage>();
    }
    private void OnEnable()
    {
        EventController.onCraftStarted += InitCrafting;
    }

    private void OnDisable()
    {
        EventController.onCraftStarted -= InitCrafting;
    }
    public void InitCrafting(GameObject mainIngredient, GameObject secondIngredient)
    {
        Debug.Log("Init crafting");
        //����������� ������� ���� �����������
        _maintIngtredient = SetIngredientForCraft(mainIngredient);
        //����������� ������� ���� �����������
        _secondIngtredient = SetIngredientForCraft(secondIngredient);
    }

    private Ingredient SetIngredientForCraft(GameObject ingredient)
    {
        //����� ������ ��� ����������� Ingredient �� gameobject
        _ingredientStorage.GetIngredient(ingredient);
        //������� Ingredient
        return _ingredientStorage.CurrentPickedIngrediend;
    }

    private void GetRecipies()
    {
        _recipesStorage.GetRequiredRecipies(_maintIngtredient, _secondIngtredient);
    }
}
