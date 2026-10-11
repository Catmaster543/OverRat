using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RandomPeopleSpawner : MonoBehaviour
{
    [Header("Shared values")]
    public int amountToSpawn;

    [Header("References")]
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private GameObject personPrefab;
    [SerializeField] private List<GameObject> spawnedPeople = new List<GameObject>();

    private MainSceneFlipper switcher;


    void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MainSceneFlipper>();
        SpawnPeople();
    }

    void Update()
    {
        
    }

    public void SpawnPeople()
    {
        for (int i = 0; i < amountToSpawn;  i++)
        {
            Bounds b = spawnArea.GetComponent<Renderer>().bounds;

            float x = Random.Range(b.min.x, b.max.x);
            float z = Random.Range(b.min.z, b.max.z);
            float y = b.max.y + 1;

            GameObject person = Instantiate(personPrefab, new Vector3(x, y, z), Quaternion.identity);
            spawnedPeople.Add(person);
        }
        switcher.people = spawnedPeople;
    }
}
