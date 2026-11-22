using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject currentItem;
    public MainSceneFlipper switcher;
    public Image iconDisplay;
    public Image effectDisplay;

    public Effect effect;

    void Start()
    {
        iconDisplay = GetComponent<Image>();
    }

    public void UpdateIcon(Effect effect = null)
    {
        if (iconDisplay != null)
        {
            if (currentItem != null)
            {
                if (currentItem.GetComponent<Ingredient>().icon != null)
                {
                    iconDisplay.sprite = currentItem.GetComponent<Ingredient>().icon;

                    if (effect != null)
                    {
                        effectDisplay.sprite = effect.effectSprite;
                        effectDisplay.gameObject.SetActive(true);
                        this.effect = effect;
                    }
                    else
                    {
                        effectDisplay.gameObject.SetActive(false);
                    }
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

    public void EffectSlot(Effect effect)
    {
        if (effect != null)
        {
            effectDisplay.sprite = effect.effectSprite;
            effectDisplay.gameObject.SetActive(true);
            this.effect = effect;
        }
        else
        {
            effectDisplay.gameObject.SetActive(false);
        }
    }
}
