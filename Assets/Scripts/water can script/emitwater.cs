using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    public GameObject waterPot;
    public ParticleSystem splashParticles;

    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == waterPot && !isInside)
        {
            // Activate the particle system
            splashParticles.Play();
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == waterPot && isInside)
        {
            // Deactivate the particle system
            splashParticles.Stop();
            isInside = false;
        }
    }
}
