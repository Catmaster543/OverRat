using UnityEngine;

public class AntennaTrigger : MonoBehaviour
{
    public Antenna antenna;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(antenna.Electrocute(other.gameObject.GetComponent<FirstPersonControler>()));
        }
    }
}
