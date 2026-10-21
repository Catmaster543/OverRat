using System.Collections.Generic;
using UnityEngine;

public class RandomIngredientsSpawner : MonoBehaviour
{
    //[Header("Shared values")]
    //public int amountToSpawn;

    [Header("References")]
    [SerializeField] private GameObject spawnArea;
    //[SerializeField] private GameObject personPrefab;
    //[SerializeField] private List<GameObject> spawnedPeople = new List<GameObject>();

    private MainSceneFlipper switcher;


    void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MainSceneFlipper>();
        //SpawnPeople();
    }

    void Update()
    {

    }

    public void Spawn(List<GameObject> ingredients)
    {
        foreach (GameObject obj in ingredients)
        {
            Bounds b = spawnArea.GetComponent<Renderer>().bounds;

            float x = Random.Range(b.min.x, b.max.x);
            float z = Random.Range(b.min.z, b.max.z);
            float y = b.max.y + 1;

            obj.transform.position = new Vector3(x, y, z);
        }
    }
}
