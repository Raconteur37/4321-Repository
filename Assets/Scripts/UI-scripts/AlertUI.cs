using UnityEngine;
using UnityEngine.UI;

public class AlertNotification : MonoBehaviour
{
    public GameObject alertUIPrefab; // Assign your alert UI prefab in the inspector

    private void Start()
    {
        // Spawn the alert UI prefab after 10 seconds
        Invoke("ShowAlert", 10f);
    }

    void ShowAlert()
    {
        // Instantiate the alert UI prefab
        GameObject alertUI = Instantiate(alertUIPrefab, transform.position, Quaternion.identity);
        
        // Set the parent of the alert UI to a canvas or another appropriate GameObject
        // Ensure that the alert UI prefab is positioned correctly in your scene

        // Set the color of the alert UI to green
        Image alertImage = alertUI.GetComponent<Image>();
        if (alertImage != null)
        {
            alertImage.color = Color.green;
        }
        else
        {
            Debug.LogWarning("Alert UI prefab does not have an Image component.");
        }
    }
}
