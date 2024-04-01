using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentBackground : MonoBehaviour
{
    public Image backgroundImage;
    // Start is called before the first frame update
    void Start()
    {
        Color color = backgroundImage.color;
        color.a = 0.6f;
        backgroundImage.color = color;
    }
}
