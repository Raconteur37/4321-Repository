using UnityEngine;

public class WaterCanController : MonoBehaviour
{
    public ParticleSystem particleSystem; // Assign your particle system in the Inspector
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    public Transform potTransform; // Assign the transform of your pot in the Inspector
    public float triggerDistance = 1.0f; // Adjust the distance threshold as needed

    private bool particlesPlaying = false;
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

    private void Update()
    {
        if (particleSystem == null || potTransform == null || audioClip == null)
        {
            Debug.LogWarning("Particle system, audio clip, or pot transform not assigned!");
            return;
        }

        float distance = Vector3.Distance(transform.position, potTransform.position);

        if (distance <= triggerDistance && !particlesPlaying)
        {
            // Activate the particle system
            particleSystem.Play();
            particlesPlaying = true;

            // Play the audio clip if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (distance > triggerDistance && particlesPlaying)
        {
            // Deactivate the particle system
            particleSystem.Stop();
            particlesPlaying = false;

            // Stop the audio clip
            audioSource.Stop();
        }
    }
}
