using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private bool isParticleSystemPlaying = false;

    void Start()
    {
        // Assuming the particle system is already attached to the same GameObject
        particleSystem = GetComponent<ParticleSystem>();
        StopParticleSystem(); // Ensure particle system starts in a stopped state
    }

    void Update()
    {
        // Check for input to start or stop the particle system
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartParticleSystem();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            StopParticleSystem();
        }
    }

    void StartParticleSystem()
    {
        if (particleSystem != null && !isParticleSystemPlaying)
        {
            particleSystem.Play();
            isParticleSystemPlaying = true;
        }
    }

    void StopParticleSystem()
    {
        if (particleSystem != null && isParticleSystemPlaying)
        {
            particleSystem.Stop();
            isParticleSystemPlaying = false;
        }
    }
}
