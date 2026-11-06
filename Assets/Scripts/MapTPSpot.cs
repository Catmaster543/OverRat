using UnityEngine;

public class MapTPSpot : MonoBehaviour
{
    public MapManager mapManager;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Smth touched me");
        if (other.gameObject.tag == "Player")
        {
            mapManager.SwitchToOTher(this.gameObject, other.gameObject);
        }
    }
}
