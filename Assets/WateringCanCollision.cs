using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanCollision : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // Set audio to loop

        // Turn off the audio initially
        audioSource.Stop();

        // Turn off the particle system initially
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Pot"))
        {
            // Activate the particle system
            particleSystem.Play();
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Pot"))
        {
            // Activate the particle system
            particleSystem.Stop();
            audioSource.Stop();
        }
    }
}
