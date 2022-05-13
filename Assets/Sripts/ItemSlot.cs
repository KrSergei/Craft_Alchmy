using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{ 
    [SerializeField] private Image _ingredientImage;
    [SerializeField] private Ingredient _ingredient;
    public Ingredient Ingredient
    {
        get { return _ingredient; }
        set
        {
            _ingredient = value;
            if (_ingredient == null)
                _ingredientImage.enabled = false;
            else
            {
                _ingredientImage.sprite = _ingredient.Icon;
                _ingredientImage.enabled = true;
            }
        }
    }

    private void OnValidate()
    {
        if (_ingredientImage == null) _ingredientImage = GetComponent<Image>();
    }
}
