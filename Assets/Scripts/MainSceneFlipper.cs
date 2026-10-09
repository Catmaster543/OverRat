using UnityEngine;

public class MainSceneFlipper : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject sewerCam;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private int livesLeft;

    public void SwitchToMain()
    {
        if (livesLeft > 0)
        {
            GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);
            player.GetComponent<Rat>().switcher = this;
            sewerCam.SetActive(false);
            livesLeft--;
        }
    }

    public void SwitchToSewer()
    {
        sewerCam.SetActive(true);
    }
}
