// using UnityEngine;

// public class Spawn_based_folder : MonoBehaviour
// {
//     private void Start()
//     {
//         // Load all assets of type GameObject from the specified folder
//         GameObject[] prefabs = Resources.LoadAll<GameObject>("Testing_UI_dynamic");

//         // Find the prefab named "Potato_Plants_Collection"
//         GameObject myPrefab = null;
//         foreach (GameObject prefab in prefabs)
//         {
//             if (prefab.name == "Potato_Plants_Collection")
//             {
//                 myPrefab = prefab;
//                 break;
//             }
//         }

//         if (myPrefab == null)
//         {
//             Debug.LogError("Prefab Potato_Plants_Collection not found in Testing_UI_dynamic folder.");
//             return;
//         }

//         // Instantiate the prefab
//         GameObject g = Instantiate(myPrefab);

//         // Set position and rotation
//         Transform t = g.transform;
//         t.position = new Vector3(30, 1, 0);
//         t.rotation = Quaternion.Euler(0, 0, 0);
//     }
// }

// using System.Collections;
// using UnityEngine;

// public class Spawn_based_folder : MonoBehaviour
// {
//     private void Start()
//     {
//         StartCoroutine(SpawnPrefabsWithDelay());
//     }

//     IEnumerator SpawnPrefabsWithDelay()
//     {
//         // Load all assets of type GameObject from the specified folder
//         GameObject[] prefabs = Resources.LoadAll<GameObject>("Testing_UI_dynamic");

//         foreach (GameObject prefab in prefabs)
//         {
//             // Instantiate the prefab
//             GameObject g = Instantiate(prefab);

//             // Set position and rotation
//             Transform t = g.transform;
//             t.position = new Vector3(30, 1, 0);
//             t.rotation = Quaternion.identity; // No rotation

//             yield return new WaitForSeconds(2f); // Wait for 2 seconds before instantiating the next prefab
//         }
//     }
// }

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawn_based_folder : MonoBehaviour
{
    // Reference to the button
    public Button spawnButton;

    // Index to keep track of which prefab to spawn next
    private int prefabIndex = 0;

    private void Start()
    {
        // Attach the method to the button's click event
        spawnButton.onClick.AddListener(SpawnNextPrefab);
    }

    // Method to spawn the next prefab from the folder
    private void SpawnNextPrefab()
    {
        // Load all assets of type GameObject from the specified folder
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Testing_UI_dynamic");

        // Check if there are any prefabs to spawn
        if (prefabIndex < prefabs.Length)
        {
            // Get the next prefab to spawn
            GameObject prefab = prefabs[prefabIndex];

            // Instantiate the prefab
            GameObject g = Instantiate(prefab);

            // Set position and rotation
            Transform t = g.transform;
            t.position = new Vector3(30, 1, 0);
            t.rotation = Quaternion.identity; // No rotation

            // Increment the index for the next prefab
            prefabIndex++;
        }
        else
        {
            Debug.LogWarning("No more prefabs to spawn.");
        }
    }
}
