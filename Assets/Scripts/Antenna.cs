using UnityEngine;

public class Antenna : MonoBehaviour
{
    public bool used;
    public Animator electrocutionAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Electrocute()
    {
        if (!used)
        {
            used = true;

        }
    }
}
