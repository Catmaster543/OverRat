using System.Collections;
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
            if (hit.collider.gameObject.tag == "Person")
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
        switcher.SwitchToSewer();
    }

    public IEnumerator DisableEnemyHpIndicator()
    {
        Debug.Log("Waiting 2s till hiding the indicator.");
        yield return new WaitForSeconds(2);
        Debug.Log("2s passed without interuption, hiding the indicator.");
        enemyHpIndicator.gameObject.SetActive(false);
    }
}
