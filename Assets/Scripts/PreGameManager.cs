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
    [SerializeField] private GameObject uniUi;

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
                uniUi.SetActive(false);
                Destroy(player);
            }
        }
    }

    public void SpawnPlayer()
    {
        GameObject spawnedPlayer = Instantiate(playerPrefab, playerSpawn);
        spawnedPlayer.GetComponent<Rat>().switcher = flipper;
        player = spawnedPlayer;
    }
}
