using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject place1;
    public GameObject place2;

    float time;

    void Update()
    {
        if (time <= 3)
        {
            time += Time.deltaTime;
        }
    }

    public void SwitchToOTher(GameObject originObj, GameObject player)
    {
        Debug.Log("Checking time since last tp");
        if (time >= 3)
        {
            Debug.Log($"Time fine, tp the player ({player}) from {originObj}");
            time = 0;
            if (originObj == place1)
            {
                Debug.Log("Place is number 1, tp the player there.");
                player.transform.position = new Vector3(place2.transform.position.x, place2.transform.position.y, place2.transform.position.z);
            }
            else if (originObj == place2)
            {
                Debug.Log("Place is number 2, tp the player there.");
                player.transform.position = new Vector3(place1.transform.position.x, place1.transform.position.y, place1.transform.position.z);
            }
        }
    }
}
