using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "Tutorial/Ingredient")]
public class Ingredient : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name = "Ingredient";
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;

    public string Id { get => _id; }
    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public GameObject Prefab { get => _prefab; }
}
