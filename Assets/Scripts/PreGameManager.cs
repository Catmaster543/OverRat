using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreGameManager : MonoBehaviour
{
    public MainSceneFlipper flipper;
    public GameObject playerPrefab;
    public GameObject pregameCanvas;
    public Transform playerSpawn;
    [SerializeField] private TextMeshProUGUI collectTimeText;
    [SerializeField] private GameObject lab;
    [SerializeField] private GameObject gameUi;
    [SerializeField] private GameObject xpCounter;
    [SerializeField] private GameObject resultObj;
    [SerializeField] private Material resultMaterial;

    [Header("Settings")]
    [SerializeField] private float collectTime;

    bool tick = false;
    GameObject player;

    void Start()
    {
        SpawnPlayer();
        pregameCanvas.SetActive(true);
        tick = true;
    }

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
                tick = false;
                lab.SetActive(true);
                gameUi.SetActive(false);
                xpCounter.SetActive(false);
                Destroy(player);
                SetResultColors();
            }
        }
    }

    public void SpawnPlayer()
    {
        GameObject spawnedPlayer = Instantiate(playerPrefab, playerSpawn);
        spawnedPlayer.GetComponent<Rat>().switcher = flipper;
        player = spawnedPlayer;
    }

    public void SetResultColors()
    {
        Debug.Log("Setting result colors");
        List<Color> ingColors = new();
        List<float> ingSmoothness = new();

        Debug.Log($"Flipper collected items has this many rn: {flipper.collectedIngredients.Count}");

        foreach (GameObject obj in flipper.collectedIngredients)
        {
            ingColors.Add(obj.GetComponent<Ingredient>().colorEffect);
            Debug.Log($"Added the color of {obj.name}, the color of it is {obj.GetComponent<Ingredient>().colorEffect}");
            ingSmoothness.Add(obj.GetComponent<Ingredient>().smoothnessEff);
        }

        resultMaterial.color = resultObj.GetComponent<InfColorResolver>().MatchUpColor(ingColors);
        resultMaterial.SetFloat("_Glossiness", resultObj.GetComponent<InfColorResolver>().MatchUpSmoothness(ingSmoothness));
    }
}
