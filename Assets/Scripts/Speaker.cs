using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Speaker : MonoBehaviour
{
    public string name;

    public Line[] lines;

    public UnityEvent reaction;
}
