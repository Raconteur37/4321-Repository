using UnityEngine;
using UnityEngine.UI;

public class DisplayMessageOnClick : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text component to display the message
    public string message = "Hello"; // Default message to display

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the TestPot
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                // Display the message to the right side of the TestPot
                DisplayMessage();
            }
        }
    }

    void DisplayMessage()
    {
        // Set the message text and position it to the right side of the TestPot
        messageText.text = message;
        messageText.transform.position = transform.position + Vector3.right * 2f; // Adjust the offset as needed
    }
}
