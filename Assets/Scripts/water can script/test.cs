using UnityEngine;
using UnityEngine.UI;

public class testWaterCanController : MonoBehaviour
{
    public Canvas textCanvas; // Assign your canvas in the Inspector
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    public Transform potTransform; // Assign the transform of your pot in the Inspector
    public Text displayText; // Assign your Text UI element in the Inspector
    public float triggerDistance = 1.0f; // Adjust the distance threshold as needed

    private bool textShowing = false;
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // Set audio to loop

        // Turn off the audio initially
        audioSource.Stop();

        // Turn off the canvas initially
        if (textCanvas != null)
        {
            textCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (textCanvas == null || potTransform == null || audioClip == null || displayText == null)
        {
            Debug.LogWarning("Canvas, audio clip, text, or pot transform not assigned!");
            return;
        }

        float distance = Vector3.Distance(transform.position, potTransform.position);

        if (distance <= triggerDistance && !textShowing)
        {
            // Activate the canvas and show the text
            textCanvas.enabled = true;
            displayText.text = "Your Text Here"; // Change this to the text you want to display
            textShowing = true;

            // Play the audio clip if not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (distance > triggerDistance && textShowing)
        {
            // Deactivate the canvas and hide the text
            textCanvas.enabled = false;
            textShowing = false;

            // Stop the audio clip
            audioSource.Stop();
        }
    }
}
