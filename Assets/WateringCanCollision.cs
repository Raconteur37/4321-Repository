using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanCollision : MonoBehaviour
{

    private void OnCollisonEnter(Collision collision)
    {
        if(collision.gameObject.name == "WateringCan_Grabbable")
        {
            // Activate the particle system
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

    private void OnCollisonExit(Collision collision)
    {
        if (collision.gameObject.name == "WateringCan_Grabbable")
        {
            // Activate the particle system
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }
}
