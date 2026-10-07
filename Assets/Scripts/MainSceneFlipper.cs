using UnityEngine;

public class MainSceneFlipper : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sewerCam;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SwitchToMain()
    {
        player.SetActive(true);
        sewerCam.SetActive(false);
    }

    public void SwitchToSewer()
    {
        sewerCam.SetActive(true);
        player.SetActive(false);
    }
}
