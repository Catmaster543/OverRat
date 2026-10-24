using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Rat : MonoBehaviour
{
    public MainSceneFlipper switcher;
    public float damage;
    public float range;
    public float biteCd;
    private Ray ray;

    private float clocker;
    private bool biteTipActive = true;
    private Image enemyHpIndicator;

    public List<GameObject> collectedIngredients = new();

    public GameStage gameStage;

    public enum GameStage
    {
        PreGame,
        Game
    }

    void Start()
    {
        enemyHpIndicator = switcher.enemyHpIndicator;
        damage = switcher.playerDamage;
        range = switcher.playerRange;
    }
    void Update()
    {
        clocker += Time.deltaTime;
    }

    public void Bite()
    {
        if (biteTipActive)
        {
            switcher.HideBiteTip();
            StopCoroutine(switcher.ShowTipWithDelay());
            biteTipActive = false;
        }
        if (clocker >= biteCd)
        {
            clocker = 0;
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            CheckForCollisions();
        }
    }

    void CheckForCollisions()
    {
        Debug.Log("Shot a ray");
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.gameObject.tag == "Person" && gameStage == GameStage.Game)
            {
                Debug.Log("Hit a person (aka. valid target)");
                Person person = hit.collider.gameObject.GetComponent<Person>();
                enemyHpIndicator.gameObject.SetActive(true);
                Debug.Log("Interrupting all coroutines..");
                StopAllCoroutines();
                person.hp -= damage;
                enemyHpIndicator.rectTransform.sizeDelta = new Vector3(person.hp * 2, enemyHpIndicator.rectTransform.sizeDelta.y);
                Debug.Log("Starting a new coroutine");
                StartCoroutine(DisableEnemyHpIndicator());
            }
            else if (hit.collider.gameObject.tag == "Ingredient" && gameStage == GameStage.PreGame)
            {
                bool found = false;
                Debug.Log("Hit an ingredient");
                for (int i  = 0; i < switcher.invSlots.Length; i++)
                {
                    Slot currentSlot = switcher.invSlots[i].GetComponent<Slot>();
                    Debug.Log($"Current slot is {currentSlot}");
                    if (currentSlot.currentItem == null)
                    {
                        found = true;
                        currentSlot.currentItem = hit.collider.gameObject;
                        currentSlot.UpdateIcon();
                        collectedIngredients.Add(hit.collider.gameObject);
                        hit.collider.gameObject.SetActive(false);
                        switcher.collectedIngredients = collectedIngredients;
                        break;
                    }
                }
                if (!found)
                {
                    Debug.Log("Inventory full, unable to pick up!");
                }
            }
            else
            {
                Debug.Log("Hit something else");
            }
        }
        else
        {
            Debug.Log("Missed, or object is out of range");
        }
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        switcher.collectedIngredients = collectedIngredients;
        //switcher.SwitchToSewer();
    }

    public IEnumerator DisableEnemyHpIndicator()
    {
        Debug.Log("Waiting 2s till hiding the indicator.");
        yield return new WaitForSeconds(2);
        Debug.Log("2s passed without interuption, hiding the indicator.");
        enemyHpIndicator.gameObject.SetActive(false);
    }

    public bool ActivateBiteTip()
    {
        if (biteTipActive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
