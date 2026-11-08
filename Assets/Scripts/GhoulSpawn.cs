using UnityEngine;

public class GhoulSpawn : MonoBehaviour
{
    public Animator ghoulAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ghoulAnimator.SetTrigger("Appear");
            Destroy(gameObject);
        }
    }
}
