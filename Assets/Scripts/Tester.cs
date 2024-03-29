using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public PlantStatsUI progressBar;
    private float testValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        progressBar.SetProgress(testValue);
    }

    // Update is called once per frame
    void Update()
    {
        testValue += Time.deltaTime * 0.1f;
        testValue = Mathf.Clamp(testValue, 0f, 1f);
        progressBar.SetProgress(testValue);
        if (testValue >= 1f)
        {
            testValue = 0f;
        }    
    }
}
