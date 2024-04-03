using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    // Start is called before the first frame update

    public void rainStatus(string status)
    {
        if (status == "Rain")
        {
            gameObject.SetActive(true);
            Debug.Log("setting rain to active");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("setting rain to non active");
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
