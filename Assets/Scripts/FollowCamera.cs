using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour

{
    public Camera cameraToFollow; // choose camera that you want to follow
    public Transform gameObjectToRotate; // choose game object to rotate towards camera

    // Update is called once per frame
    void Update()
    {
        gameObjectToRotate.rotation = Quaternion.Slerp(gameObjectToRotate.rotation, cameraToFollow.transform.rotation, 5f*Time.deltaTime);   
    }
}
