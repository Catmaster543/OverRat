using UnityEngine;

public class Rat : MonoBehaviour
{
    public MainSceneFlipper switcher;
    public float damage;
    public float range;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void Bite()
    {

    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        switcher.SwitchToSewer();
    }
}
