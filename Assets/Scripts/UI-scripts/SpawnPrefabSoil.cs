using UnityEngine;

public class SpawnPrefabSoil : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the inspector

    // Method to instantiate the prefab
    public void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned.");
        }
    }
}
