using UnityEngine;

public class MapTPSpot : MonoBehaviour
{
    public MapManager mapManager;
    public Transform resultTransform;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mapManager.SwitchToOTher(this, other.gameObject);
        }
    }
}
