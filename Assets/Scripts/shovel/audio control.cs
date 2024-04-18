using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        // Turn on audio when 'O' key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            audioSource.enabled = true;
        }

        // Turn off audio when 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.enabled = false;
        }
    }
}
