using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{

    private int currentProgression = 0; 
    public int timeBetweenGrowth; 
    public int maxGrowth; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Growth", timeBetweenGrowth, timeBetweenGrowth); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Growth() {
        if (currentProgression != maxGrowth) {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true); 
        }
        if (currentProgression > 0 && currentProgression < maxGrowth) {

            gameObject.transform.GetChild(currentProgression - 1).gameObject.SetActive(false); 
        }
        if (currentProgression < maxGrowth) {
            currentProgression++; 
        }

    }
}
