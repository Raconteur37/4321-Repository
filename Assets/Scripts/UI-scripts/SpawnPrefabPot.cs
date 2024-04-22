using UnityEngine;

public class SpawnPrefabPot : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the inspector
    private float spawnHeight = 0.5f; // Height to spawn above the ground
    private float currentHeight = 0f; // Current height for spawning

    // Method to instantiate the prefab
    public void SpawnObject()
    {
        if (prefabToSpawn != null && WristMenuTransform != null)
        {
            // Increment the current height
            currentHeight += spawnHeight;
            
            // Calculate the spawn position with the incremented height
            Vector3 spawnPosition = new Vector3(0, currentHeight, -4);
            
            // Instantiate the prefab at the calculated position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }
}
