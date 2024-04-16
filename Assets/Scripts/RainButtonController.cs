using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class RainButtonController : MonoBehaviour
{

    public Button rainButton;
    public InputAction playerControl;

    /*private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        Button btn = rainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("rain button has been clicked");
        FindObjectOfType<GetCurrentWeatherInfo>().changeRainButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            Debug.Log("X button pressed");
            FindAnyObjectByType<GetCurrentWeatherInfo>().changeRainButton();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X button on keyboard was pressed");
            FindAnyObjectByType<GetCurrentWeatherInfo>().changeRainButton();
        }
    }
}
