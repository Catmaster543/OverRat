using UnityEngine;

public class Person : MonoBehaviour
{
    public float hp;
    public float walkSpeed;
    public int xpReward;

    private MainSceneFlipper switcher;

    void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MainSceneFlipper>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            switcher.playerXp += xpReward;
            switcher.UpdateXpCounter();
            Destroy(gameObject);
        }
    }
}
