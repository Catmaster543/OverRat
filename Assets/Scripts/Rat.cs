using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public MainSceneFlipper switcher;
    public float damage;
    public float range;
    public float biteCd;
    private Ray ray;

    private float clocker;

    void Start()
    {
        
    }
    void Update()
    {
        clocker += Time.deltaTime;
    }

    public void Bite()
    {
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
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "Person")
            {
                Debug.Log("Hit a person (aka. valid target)");
                Person person = hit.collider.gameObject.GetComponent<Person>();
                person.hp -= damage;
            }
            else
            {
                Debug.Log("Hit something else");
            }
        }
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        switcher.SwitchToSewer();
    }
}
