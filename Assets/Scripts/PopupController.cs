using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;

    void Start()
    {
        // Hide the popup panel initially
        popupPanel.SetActive(false);
    }

    // Method to show the popup panel
    public void ShowPopupPanel()
    {
        popupPanel.SetActive(true);
    }

    // Method to hide the popup panel
    public void HidePopupPanel()
    {
        popupPanel.SetActive(false);
    }
}
