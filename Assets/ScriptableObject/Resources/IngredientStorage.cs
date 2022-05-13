using System.Collections.Generic;
using UnityEngine;

public class IngredientStorage : MonoBehaviour
{
    private const string PATH_TO_SCRIPTABLEOBJECTS_SIMPLE_INGREDIENTS = "Ingredients/Simple";
    private const string PATH_TO_SCRIPTABLEOBJECTS_PURIFIED_INGREDIENTS = "Ingredients/Purified";
    private const string ID_INGREDIENTS_IGNORE_FOR_GENERATION = "trash";

    [SerializeField] List<Ingredient> _allSimpleIngridients;        //������ �������� ������� ������������
    [SerializeField] List<Ingredient> _allPurifiedIngridients;      //������ �������� ��������� ������������
    [SerializeField] List<Ingredient> _allGeneratedIngridients;     //������ �������� ��������������� ������������
    [SerializeField] private GameObject _spawnedIngredientsStorage; //������������ ������ ��� �������� ��������������� ������������
    [SerializeField] private Ingredient _currentPickedIngrediend;  //������� ��������� ����������
    public List<Ingredient> AllSpawnedIngridients { get => _allGeneratedIngridients;  private set => _allGeneratedIngridients = value; }
    public Ingredient CurrentPickedIngrediend { get => _currentPickedIngrediend; private set => _currentPickedIngrediend = value; }

    private void Start()
    {
        _allSimpleIngridients = new List<Ingredient>();
        _allPurifiedIngridients = new List<Ingredient>();
        AllSpawnedIngridients = new List<Ingredient>();

        //���������� ������� ������� ������������
        var ingridients = Resources.LoadAll<Ingredient>(PATH_TO_SCRIPTABLEOBJECTS_SIMPLE_INGREDIENTS);
        AddIngredientsToListOfIngredients(_allSimpleIngridients, ingridients);

        //���������� ������� ��������� ������������
        ingridients = Resources.LoadAll<Ingredient>(PATH_TO_SCRIPTABLEOBJECTS_PURIFIED_INGREDIENTS);
        AddIngredientsToListOfIngredients(_allPurifiedIngridients, ingridients);
    }
    /// <summary>
    /// ���������� ������ ������������
    /// </summary>
    /// <param name="listTypeOfIngredients">������ ����� ������������</param>
    /// <param name="ingredients">����������</param>
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
    /// ���������� ������ ��������������� ������������
    /// </summary>
    /// <param name="listTypeOfIngredients">������ ��������������� ������������</param>
    /// <param name="ingredients">��� �����������</param>
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
    /// ����� ������ ����������� ��� ��� ��������� �� �����
    /// </summary>
    /// <returns></returns>
    public GameObject GetIngredient()
    {
        //����������� ���������� �������
        int index = GetRandomIndex();

        //�������� Id �����������, ������������ � ���������.
        if (_allSimpleIngridients[index].Id.Equals(ID_INGREDIENTS_IGNORE_FOR_GENERATION))
        {
            return GetIngredient();
        } 
        else
        {
            //���������� ����������� � ������ ���������������
            AddIngredientsToListOfIngredients(AllSpawnedIngridients, _allSimpleIngridients[index]);
            //������� ����������� �� �������
            return _allSimpleIngridients[index].Prefab;
        }
    }

    /// <summary>
    /// ��������� ���������� �������� � ��������� �� 0 �� ��� ������ ������������
    /// </summary>
    /// <returns></returns>
    private int GetRandomIndex()
    {
        return Mathf.RoundToInt(Random.Range(0, _allSimpleIngridients.Count));
    }

    /// <summary>
    /// ����������� �������� ���������� �����������
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
