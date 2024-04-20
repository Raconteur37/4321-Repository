using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the inspector
    public GameObject prefabToSpawn2; 

    // Method to instantiate the prefab
    public void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, new Vector3(0, 0, 4), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned.");
        }
    }
}
