using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFlipper : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private int livesLeft;
    public int playerXp;

    [Header("Scene References")]
    [SerializeField] private GameObject sewerCam;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private GameObject sewerUI;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject biteTip;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI damageUpgradeText;
    [SerializeField] private TextMeshProUGUI rangeUpgradeText;

    [Header("Shared References")]
    public Image enemyHpIndicator;
    public int playerDamage = 10;
    public int playerRange = 3;


    private int damageUpgradeCost = 10;
    private int rangeUpgradeCost = 10;
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

    public void UpdateXpCounter()
    {
        xpText.text = $"{playerXp} xp";
    }

    public void UpgradeDamage()
    {
        if (playerXp >= damageUpgradeCost)
        {
            playerXp -= damageUpgradeCost;
            UpdateXpCounter();
            playerDamage += 10;
            damageUpgradeCost += 10;
            damageUpgradeText.text = $"Upgrade Damage \nCost: {damageUpgradeCost} xp";
        }
    }

    public void UpgradeRange()
    {
        if (playerXp >= rangeUpgradeCost)
        {
            playerXp -= rangeUpgradeCost;
            UpdateXpCounter();
            playerRange += 1;
            rangeUpgradeCost += 10;
            rangeUpgradeText.text = $"Upgrade Range \nCost: {rangeUpgradeCost} xp";
        }
    }
}
