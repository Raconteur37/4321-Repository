using UnityEngine;

public class WateringSystem : MonoBehaviour
{
    public Transform wateringPoint; // The point where watering should start
    public GameObject waterEffect; // The water effect object

    private bool isWatering = false; // Flag to track if watering is in progress

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the object we are interested in
        if (other.gameObject.CompareTag("YourObjectTag"))
        {
            // Check if watering has already started
            if (!isWatering)
            {
                // Start watering
                StartWatering();
            }
        }
    }

    void StartWatering()
    {
        isWatering = true;
        // Instantiate the water effect at the watering point
        GameObject waterEffectInstance = Instantiate(waterEffect, wateringPoint.position, Quaternion.identity);
        
        // You can put your watering logic here, for example, you could enable particle systems, play sounds, etc.
        // For this example, I'll just print a message.
        Debug.Log("Watering started!");

        // Assuming you want to stop watering after a certain time, you could use Invoke to call a method after a delay
        Invoke("StopWatering", 5f); // Adjust 5f to whatever duration you want watering to last
    }

    void StopWatering()
    {
        // Put any cleanup logic here if needed
        Debug.Log("Watering stopped!");
        isWatering = false;
    }
}
