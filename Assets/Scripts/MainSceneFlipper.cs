using System.Collections;
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
    [SerializeField] private PreGameManager preGameManager;
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
    [SerializeField] private Animator uniAnimator;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject killBox;
    [SerializeField] private GameObject sacrificalRatsGroup;
    [SerializeField] Animator[] sacrificalRatsAnimator;
    public GameObject lab;

    public GameObject[] invSlots = new GameObject[3];

    [Header("Shared References")]
    public Image enemyHpIndicator;
    public int playerDamage = 10;
    public int playerRange = 3;
    public List<GameObject> people;
    public RandomIngredientsSpawner ingredientsSpawner;
    public GameObject infoObj;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI objectiveText;

    [Header("Live References")]
    public GameObject currentRat;


    public List<GameObject> collectedIngredients = new();

    public Rat.GameStage gameStage;

    private int damageUpgradeCost = 10;
    private int rangeUpgradeCost = 10;

    public List<GameObject> spawnedIngredients = new();

    void Start()
    {
        uniAnimator.Play("FadeOut");
    }

    void Update()
    {
        
    }

    public IEnumerator SwitchToMain(bool showTip = false)
    {
        biteTip.GetComponent<TextMeshProUGUI>().text = "Click to bite";
        if (livesLeft > 0)
        {
            sacrificalRatsAnimator[livesLeft - 1].SetTrigger("Cross");
            yield return new WaitForSeconds(1.7f);
            FadeIn();
            yield return new WaitForSeconds(0.9f);
            sacrificalRatsGroup.SetActive(false);
            xpText.gameObject.SetActive(true);
            sewerUI.SetActive(false);
            GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
            player.GetComponent<Rat>().switcher = this;
            player.GetComponent<Rat>().gameStage = gameStage;
            currentRat = player;
            sewerCam.SetActive(false);
            FadeOut();
            yield return new WaitForSeconds(0.9f);
            inventoryPanel.SetActive(false);
            gameUI.SetActive(true);
            livesLeft--;
            biteTip.SetActive(true);
            if (showTip)
            {
                StartCoroutine(ShowTipWithDelay());
            }
        }
    }

    public IEnumerator SwitchToSewer(GameObject objToTurnOff = null)
    {
        if (livesLeft <= 0)
        {
            FadeIn();
            yield return new WaitForSeconds(0.9f);
            sewerCam.SetActive(true);
            gameOverUI.SetActive(true);
            TextMeshProUGUI gameOverText = gameOverUI.GetComponentInChildren<TextMeshProUGUI>();
            gameOverText.text = "All your rat lives are gone, Game over!";
        }
        else
        {
            FadeIn();
            yield return new WaitForSeconds(0.9f);
            if (objToTurnOff != null)
            {
                objToTurnOff.SetActive(false);
            }
            sacrificalRatsGroup.SetActive(true);
            sacrificalRatsAnimator[livesLeft - 1].SetTrigger("ReadyUp");
            sewerCam.SetActive(true);
            sewerUI.SetActive(true);
            gameUI.SetActive(false);
            biteTip.SetActive(false);
            FadeOut();
            yield return new WaitForSeconds(0.9f);
            livesText.text = $"Lives left: {livesLeft}";
        }
    }

    public void SwitchToMainV()
    {
        StartCoroutine(SwitchToMain());
    }

    public void SwitchToSewerV()
    {
        StartCoroutine(SwitchToSewer());
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

    public void SpawnIngredients()
    {
       StartCoroutine(ingredientsSpawner.Spawn(collectedIngredients));
    }

    public void FinishIntroCutscene()
    {

        gameStage = Rat.GameStage.Game;
        objectiveText.text = "● Infect everyone.";
        killBox.SetActive(true);
        foreach (GameObject obj in spawnedIngredients)
        {
            Destroy(obj);
        }
        StartCoroutine(SwitchToSewer(lab));
    }

    public void FadeIn()
    {
        uniAnimator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        uniAnimator.SetTrigger("FadeOut");
    }

    public void StopFade()
    {
        uniAnimator.SetTrigger("StopFade");
    }

    public void PlayButtonPress()
    {
        StartCoroutine(SwitchToMain());
    }

    public IEnumerator ShowTipWithDelay()
    {
        yield return new WaitForSeconds(2);
        if (currentRat.GetComponent<Rat>().ActivateBiteTip())
        {
            biteTip.SetActive(true);
        }
        else
        {
            biteTip.SetActive(false);
        }
    }

    public IEnumerator ShowPickepUpInfo(GameObject ingredient)
    {
        infoText.text = $"Picked up {ingredient.name}";
        infoObj.GetComponent<Animator>().SetTrigger("PopUp");
        yield return new WaitForSeconds(1.5f);
        infoObj.GetComponent<Animator>().SetTrigger("PopOut");
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerC());
    }

    public IEnumerator RespawnPlayerC()
    {
        FadeIn();
        yield return new WaitForSeconds(1.5f);
        GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
        Rat newRat = player.GetComponent<Rat>();
        newRat.switcher = this;
        newRat.gameStage = gameStage;
        preGameManager.player = player;
        foreach (GameObject obj in invSlots)
        {
            obj.GetComponent<Slot>().currentItem = null;
            obj.GetComponent<Slot>().UpdateIcon();
        }
        currentRat = player;
        FadeOut();
        yield return new WaitForSeconds(0.9f);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
