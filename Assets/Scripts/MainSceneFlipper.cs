using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFlipper : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private int livesLeft;

    [Header("Scene References")]
    [SerializeField] private GameObject sewerCam;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject sewerUI;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject biteTip;

    [Header("Shared References")]
    public Image enemyHpIndicator;

    public void SwitchToMain()
    {
        if (livesLeft > 0)
        {
            sewerUI.SetActive(false);
            GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);
            player.GetComponent<Rat>().switcher = this;
            sewerCam.SetActive(false);
            gameUI.SetActive(true);
            livesLeft--;
            biteTip.SetActive(true);
        }
    }

    public void SwitchToSewer()
    {
        sewerCam.SetActive(true);
        sewerUI.SetActive(true);
        gameUI.SetActive(false);
        biteTip.SetActive(false);
        livesText.text = $"Lives left: {livesLeft}";
    }

    public void HideBiteTip()
    {
        biteTip.SetActive(false);
    }
}
