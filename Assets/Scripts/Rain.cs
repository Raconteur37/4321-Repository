using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rain : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject rainParent;
    [SerializeField] GameObject rain;


    public void rainStatus(string status)
    {
        if (status == "Rain" || status == "Thunderstorm")
        {
            rain.SetActive(true);
            Debug.Log("setting rain to active");
            if (status == "Thunderstorm")
            {
                Debug.Log("Thunderstorm in progress");
            }
        }
        else
        {
            rain.SetActive(false);
            Debug.Log("setting rain to non active");
        }
    }

    private void Start()
    {
        //gameObject.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    {

    }
}
