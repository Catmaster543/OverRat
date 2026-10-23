using System.Collections;
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
        //Spawn();
    }

    void Update()
    {

    }

    public IEnumerator Spawn(List<GameObject> ingredients)
    {
        foreach (GameObject obj in ingredients)
        {
            Bounds b = spawnArea.GetComponent<Renderer>().bounds;

            float x = Random.Range(b.min.x, b.max.x);
            float z = Random.Range(b.min.z, b.max.z);
            float y = b.max.y + 1;

            GameObject spawnedObj = Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
            spawnedObj.GetComponent<Rigidbody>().isKinematic = false;
            spawnedObj.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
}
