using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public MainSceneFlipper switcher;
    public float damage;
    public float range;
    private Ray ray;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void Bite()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f)); 
        CheckForCollisions();
    }

    void CheckForCollisions()
    {
        Debug.Log("Shot a ray");
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log($"Ray hit {hit.collider.gameObject.name}");
        }
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        switcher.SwitchToSewer();
    }
}
