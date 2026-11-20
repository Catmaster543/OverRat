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

    public void Electrocute(FirstPersonControler firstPersonControler)
    {
        if (!used)
        {
            used = true;
            firstPersonControler.frozen = true;
            electrocutionAnimator.gameObject.SetActive(true);
        }
    }
}
