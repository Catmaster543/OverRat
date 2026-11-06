using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapTPSpot place1;
    public MapTPSpot place2;

    public Animator uniAnimator;

    float time;

    void Update()
    {
        if (time <= 3)
        {
            time += Time.deltaTime;
        }
    }

    public void SwitchToOTher(MapTPSpot originObj, GameObject player)
    {
        if (time >= 3)
        {
            time = 0;
            if (originObj == place1)
            {
                CharacterController controller = player.GetComponent<CharacterController>();

                StartCoroutine(TeleportPlayer(place2.resultTransform, controller));
            }
            else if (originObj == place2)
            {
                CharacterController controller = player.GetComponent<CharacterController>();

                StartCoroutine(TeleportPlayer(place1.resultTransform, controller));
            }
        }
    }

    public IEnumerator TeleportPlayer(Transform destination, CharacterController controller)
    {
        controller.enabled = false;

        uniAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        uniAnimator.SetTrigger("FadeOut");
        controller.gameObject.transform.position = destination.position;
        controller.gameObject.transform.rotation = destination.rotation;
        controller.enabled = true;
        yield return new WaitForSeconds(1.5f);
    }
}
