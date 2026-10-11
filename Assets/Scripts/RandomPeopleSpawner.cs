using UnityEngine;

public class RandomPeopleSpawner : MonoBehaviour
{
    [Header("Shared values")]
    public int amountToSpawn;

    [Header("References")]
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private GameObject personPrefab;


    void Start()
    {
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

            Instantiate(personPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}
