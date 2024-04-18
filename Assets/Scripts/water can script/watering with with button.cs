using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Update()
    {
        // Turn on particle system when 'O' key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            particleSystem.Play();
        }

        // Turn off particle system when 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            particleSystem.Stop();
        }
    }
}
