using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Classes.Plants;

public class WateringCanCollision : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioClip audioClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    private bool flag = false;
    private Collider collision;

    public void SetCollider(Collider collider) {  collision = collider; }

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
        if (flag) { wateringPlant(); }
    }

    private void wateringPlant()
    {

            PotManager potManager = collision.GetComponent<PotManager>();

            PlantClass plant = potManager.getPlant();

            double currentPlantWater = plant.getWaterAmount() + 0.1;

            Debug.Log("Current water lever for plant: " + currentPlantWater);

            plant.setWaterAmount(currentPlantWater);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Pot"))
        {
            flag = true;
            SetCollider(collision);
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
            flag = false;
        }
    }
}
