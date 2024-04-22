using UnityEngine;

public class SpawnPrefabPot : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the inspector
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
}