using UnityEngine;

public class SpawnPrefabPot : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the inspector
    public GameObject prefab_Soil; // Assign this in the inspector
    public GameObject prefab_Seed; // Assign this in the inspector
    public GameObject prefab_Watering_Can; // Assign this in the inspector
    public GameObject prefab_Shovel; // Assign this in the inspector

    [SerializeField] private Transform WristMenuTransform;
    [SerializeField] private Vector3 offsetFromWristMenu = new Vector3(0f, 0.1f, 0f);

    // Method to instantiate the prefab
    public void SpawnObject()
    {
        if (prefabToSpawn != null && WristMenuTransform != null)
        {
            // Calculate the spawn position relative to the wrist menu with the offset
            Vector3 spawnPosition = WristMenuTransform.TransformPoint(offsetFromWristMenu);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }

    public void SpawnSoil()
    {
        if (prefab_Soil != null && WristMenuTransform != null)
        {
            // Calculate the spawn position relative to the wrist menu with the offset
            Vector3 spawnPosition = WristMenuTransform.TransformPoint(offsetFromWristMenu);
            Instantiate(prefab_Soil, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }

    public void SpawnSeed()
    {
        if (prefab_Seed != null && WristMenuTransform != null)
        {
            // Calculate the spawn position relative to the wrist menu with the offset
            Vector3 spawnPosition = WristMenuTransform.TransformPoint(offsetFromWristMenu);
            Instantiate(prefab_Seed, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }

    public void SpawnWateringCan()
    {
        if (prefab_Watering_Can != null && WristMenuTransform != null)
        {
            // Calculate the spawn position relative to the wrist menu with the offset
            Vector3 spawnPosition = WristMenuTransform.TransformPoint(offsetFromWristMenu);
            Instantiate(prefab_Watering_Can, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }

    public void SpawnShovel()
    {
        if (prefab_Shovel != null && WristMenuTransform != null)
        {
            // Calculate the spawn position relative to the wrist menu with the offset
            Vector3 spawnPosition = WristMenuTransform.TransformPoint(offsetFromWristMenu);
            Instantiate(prefab_Shovel, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn or wrist menu transform is not assigned.");
        }
    }
    
}