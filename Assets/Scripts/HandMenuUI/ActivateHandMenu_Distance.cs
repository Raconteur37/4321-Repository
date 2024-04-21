using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHandMenu_Distance : MonoBehaviour
{
    public Transform centerEyeCamera; // assign this to you vr rig
    public GameObject handObject; // assign the hand GameObject to what you want
    public GameObject objectToActivate; //this will be our hand ui

    public float distanceThreshold = 0.5f; // distance to activate hand ui in meters


    // Update is called once per frame
    void Update()
    {
        CheckDistanceToActivateHandMenu();
    }

    // Update is called once per frame
    void CheckDistanceToActivateHandMenu()
    {
        // calculate distance between the hand and the center eye camera
        float distance = Vector3.Distance(centerEyeCamera.position, handObject.transform.position);

        // Debug to find correct distance
        //Debug.Log("Distance to Hand: " + distance);

        // check if distance is less than or equal to threshold
        if (distance < distanceThreshold)
        {
            //Debug.Log("Activate hand menu - hand is less than threshold.");

            objectToActivate.SetActive(true);
        }
        else
        {
            // Debug to find correct distance
            //Debug.Log("Hand is out of range - greater than threshold");
        }
        
    }
}
