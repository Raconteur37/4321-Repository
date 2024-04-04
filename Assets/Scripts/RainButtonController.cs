using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RainButtonController : MonoBehaviour
{

    public Button rainButton;

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
        
    }
}
