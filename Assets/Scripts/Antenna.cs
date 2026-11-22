using System.Collections;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    public bool used;
    public Animator electrocutionAnimator;
    public PlayerInputHandler playerInputHandler;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public IEnumerator Electrocute(FirstPersonControler firstPersonControler)
    {
        yield return new WaitForSeconds(5);
        if (!used)
        {
            used = true;
            firstPersonControler.frozen = true;
            firstPersonControler.gameObject.GetComponentInChildren<Camera>().gameObject.SetActive(false);
            electrocutionAnimator.SetTrigger("Start");
        }
    }
}
