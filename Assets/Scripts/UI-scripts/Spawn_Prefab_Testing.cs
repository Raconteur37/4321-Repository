using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Spawn_Prefab_Testing : MonoBehaviour
{
    // Reference to the dropdown UI element
    public Dropdown prefabDropdown;

    private void Start()
    {
        // Add listener for dropdown value changes
        prefabDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(prefabDropdown);
        });

        // Initialize dropdown options
        InitializeDropdown();
    }

    // Method to initialize the dropdown with prefab names
    void InitializeDropdown()
    {
        // Load all assets of type GameObject from the specified folder
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Testing_UI_dynamic");

        // Clear existing options
        prefabDropdown.ClearOptions();

        // Create a list to hold the dropdown options
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        // Add prefab names as options
        foreach (GameObject prefab in prefabs)
        {
            options.Add(new Dropdown.OptionData(prefab.name));
        }

        // Assign the options to the dropdown
        prefabDropdown.AddOptions(options);
    }

    // Method called when dropdown value changes
    void DropdownValueChanged(Dropdown change)
    {
        // Load all assets of type GameObject from the specified folder
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Testing_UI_dynamic");

        // Get the selected prefab index
        int selectedPrefabIndex = change.value;

        // Check if the selected index is valid
        if (selectedPrefabIndex >= 0 && selectedPrefabIndex < prefabs.Length)
        {
            // Get the selected prefab
            GameObject selectedPrefab = prefabs[selectedPrefabIndex];

            // Instantiate the selected prefab
            GameObject g = Instantiate(selectedPrefab);

            // Set position and rotation
            Transform t = g.transform;
            t.position = new Vector3(30, 1, 0);
            t.rotation = Quaternion.identity; // No rotation
        }
    }
}
