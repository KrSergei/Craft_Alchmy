using System.Collections.Generic;
using UnityEngine;

public class IngredientStorage : MonoBehaviour
{
    private const string PATH_TO_SCRIPTABLEOBJECTS_SIMPLE_INGREDIENTS = "Ingredients/Simple";
    private const string PATH_TO_SCRIPTABLEOBJECTS_PURIFIED_INGREDIENTS = "Ingredients/Purified";
    private const string ID_INGREDIENTS_IGNORE_FOR_GENERATION = "trash";

    [SerializeField] List<Ingredient> _allSimpleIngridients;        //список хранения простых ингредиентов
    [SerializeField] List<Ingredient> _allPurifiedIngridients;      //список хранения очищенных ингредиентов
    [SerializeField] List<Ingredient> _allGeneratedIngridients;     //список хранения сгенерированных ингредиентов
    [SerializeField] private GameObject _spawnedIngredientsStorage; //родительский объект для хранения сгенерированных ингредиентов
    [SerializeField] private Ingredient _currentPickedIngrediend;  //текущий выбранный ингредиент
    public List<Ingredient> AllSpawnedIngridients { get => _allGeneratedIngridients;  private set => _allGeneratedIngridients = value; }
    public Ingredient CurrentPickedIngrediend { get => _currentPickedIngrediend; private set => _currentPickedIngrediend = value; }

    private void Start()
    {
        _allSimpleIngridients = new List<Ingredient>();
        _allPurifiedIngridients = new List<Ingredient>();
        AllSpawnedIngridients = new List<Ingredient>();

        //заполнение массива простых ингредиентов
        var ingridients = Resources.LoadAll<Ingredient>(PATH_TO_SCRIPTABLEOBJECTS_SIMPLE_INGREDIENTS);
        AddIngredientsToListOfIngredients(_allSimpleIngridients, ingridients);

        //заполнение массива очищенных ингредиентов
        ingridients = Resources.LoadAll<Ingredient>(PATH_TO_SCRIPTABLEOBJECTS_PURIFIED_INGREDIENTS);
        AddIngredientsToListOfIngredients(_allPurifiedIngridients, ingridients);
    }
    /// <summary>
    /// Заполнение списка ингредиентов
    /// </summary>
    /// <param name="listTypeOfIngredients">список типов ингредиентов</param>
    /// <param name="ingredients">ингредиент</param>
    private void AddIngredientsToListOfIngredients(List<Ingredient> listTypeOfIngredients, Ingredient[] ingredients)
    {
        if (listTypeOfIngredients != null)
        {
            foreach (var item in ingredients)
            {
                listTypeOfIngredients.Add(item);
            }
        }
    }

    /// <summary>
    /// Заполнение списка сгенерированных ингредиентов
    /// </summary>
    /// <param name="listTypeOfIngredients">список сгенерированных ингредиентов</param>
    /// <param name="ingredients">тип ингредиента</param>
    private void AddIngredientsToListOfIngredients(List<Ingredient> listTypeOfIngredients, Ingredient ingredients)
    {
        if (listTypeOfIngredients != null)
        {
            AllSpawnedIngridients.Add(ingredients);
        }
    }

    private void OnEnable()
    {
        EventController.onGeneratedIngredient += GetIngredient;
        EventController.onPickedIngredient += GetIngredient;
    }
    private void OnDisable()
    {
        EventController.onGeneratedIngredient -= GetIngredient;
        EventController.onPickedIngredient -= GetIngredient;
    }    

    /// <summary>
    /// Метод выбора ингредиента для его генерации на сцене
    /// </summary>
    /// <returns></returns>
    public GameObject GetIngredient()
    {
        //Определение рандомного индекса
        int index = GetRandomIndex();

        //проверка Id ингредиента, запрещенного к генерации.
        if (_allSimpleIngridients[index].Id.Equals(ID_INGREDIENTS_IGNORE_FOR_GENERATION))
        {
            return GetIngredient();
        } 
        else
        {
            //добавление ингредиента в список сгенерированных
            AddIngredientsToListOfIngredients(AllSpawnedIngridients, _allSimpleIngridients[index]);
            //возврат ингредиента по индексу
            return _allSimpleIngridients[index].Prefab;
        }
    }

    /// <summary>
    /// Получение случайного значения в диапазоне от 0 до дли списка ингредиентов
    /// </summary>
    /// <returns></returns>
    private int GetRandomIndex()
    {
        return Mathf.RoundToInt(Random.Range(0, _allSimpleIngridients.Count));
    }

    /// <summary>
    /// Определение текущего выбранного ингредиента
    /// </summary>
    /// <param name="obj"></param>
    public void GetIngredient(GameObject obj)
    {
        for (int i = 0; i < _spawnedIngredientsStorage.transform.childCount; i++)
        {
            if (_spawnedIngredientsStorage.transform.GetChild(i).gameObject.Equals(obj))
            {
                CurrentPickedIngrediend = AllSpawnedIngridients[i];
            }
        }
    }
}
