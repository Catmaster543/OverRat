using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI collectTimeText;
    public GameObject[] invSlots = new GameObject[3];

    [Header("Shared References")]
    public Image enemyHpIndicator;
    public int playerDamage = 10;
    public int playerRange = 3;
    public List<GameObject> people;

    [Header("Live References")]
    public GameObject currentRat;

    [Header("Settings")]
    [SerializeField] private float collectTime;

    bool tick = false;

    private int damageUpgradeCost = 10;
    private int rangeUpgradeCost = 10;

    void Update()
    {
        if (tick)
        {
            if (collectTime >= 0)
            {
                collectTime -= Time.deltaTime;
                collectTimeText.text = ((int)collectTime).ToString();
            }
            else
            {
                Destroy(currentRat);
            }
        }
    }

    public void SwitchToMain()
    {
        if (livesLeft > 0)
        {
            sewerUI.SetActive(false);
            GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);
            player.GetComponent<Rat>().switcher = this;
            currentRat = player;
            sewerCam.SetActive(false);
            gameUI.SetActive(true);
            livesLeft--;
            biteTip.SetActive(true);
            tick = true;
        }
    }

    public void SwitchToSewer()
    {
        if (livesLeft <= 0)
        {
            sewerCam.SetActive(true);
            gameOverUI.SetActive(true);
            TextMeshProUGUI gameOverText = gameOverUI.GetComponentInChildren<TextMeshProUGUI>();
            gameOverText.text = "All your rat lives are gone, Game over!";
        }
        else
        {
            sewerCam.SetActive(true);
            sewerUI.SetActive(true);
            gameUI.SetActive(false);
            biteTip.SetActive(false);
            livesText.text = $"Lives left: {livesLeft}";
        }
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

    public void CheckCompletion()
    {
        if (people.Count == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOverUI.SetActive(true);
            TextMeshProUGUI gameOverText = gameOverUI.GetComponentInChildren<TextMeshProUGUI>();
            gameOverText.text = "You've infected everyone, congrats!";
        }
    }

    public void FinishCollecting()
    {
        Destroy(currentRat);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
