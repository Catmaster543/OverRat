using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject currentItem;
    public Image iconDisplay;

    void Start()
    {
        iconDisplay = GetComponent<Image>();
    }

    public void UpdateIcon()
    {
        if (currentItem != null)
        {
            if (currentItem.GetComponent<Ingredient>().icon != null)
            {
                iconDisplay.sprite = currentItem.GetComponent<Ingredient>().icon;
            }
            else
            {
                Debug.LogError($"Ingredient {currentItem.name} has no icon set!");
            }
        }
        else
        {
            iconDisplay.sprite = null;
        }
    }
}
