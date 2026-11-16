using UnityEngine;

public class Person : MonoBehaviour
{
    public float hp;
    public float walkSpeed;
    public int xpReward;

    private MainSceneFlipper switcher;

    public GameObject ratPrefab;

    void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MainSceneFlipper>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            Vector3 pos = transform.position;
            pos.y = -0.4f;
            Instantiate(ratPrefab, pos, Quaternion.identity);
            switcher.playerXp += xpReward;
            switcher.UpdateXpCounter();
            switcher.people.Remove(gameObject);
            switcher.CheckCompletion();
            Destroy(gameObject);
        }
    }
}
