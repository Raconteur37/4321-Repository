
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light spotLight; 

    private bool isLightOn = false; 

    void Start()
    {
        
        GetComponent<BoxCollider>().enabled = false;
        
        spotLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            isLightOn = !isLightOn;

            spotLight.enabled = isLightOn;
            
            GetComponent<BoxCollider>().enabled = true;
            
        }
    }
}