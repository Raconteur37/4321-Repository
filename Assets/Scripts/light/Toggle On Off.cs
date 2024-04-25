
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light spotLight;
    public BoxCollider LightBox;

    private bool isLightOn = false; 

    void Start()
    {
        
        LightBox.enabled = false;
        
        spotLight.enabled = false;
    }

    public void LightSwitch()
    {
        isLightOn = !isLightOn;

        spotLight.enabled = isLightOn;

        LightBox.enabled = isLightOn;

    }
    void Update()
    {

    }
}