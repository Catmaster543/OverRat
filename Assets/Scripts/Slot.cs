using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject currentItem;
    public MainSceneFlipper switcher;
    public Image iconDisplay;
    public Image effectDisplay;

    void Start()
    {
        iconDisplay = GetComponent<Image>();
    }

    public void UpdateIcon(Effect effect = Effect.None)
    {
        if (iconDisplay != null)
        {
            if (currentItem != null)
            {
                if (currentItem.GetComponent<Ingredient>().icon != null)
                {
                    iconDisplay.sprite = currentItem.GetComponent<Ingredient>().icon;

                    if (effect != Effect.None)
                    {
                        effectDisplay.sprite = switcher.effectSprites[(int)effect];
                        effectDisplay.gameObject.SetActive(true);
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
        if (effect != Effect.None)
        {
            effectDisplay.sprite = switcher.effectSprites[(int)effect];
            effectDisplay.gameObject.SetActive(true);
        }
        else
        {
            effectDisplay.gameObject.SetActive(false);
        }
    }

    public enum Effect
    {
        None,
        Shocked
    }
}
