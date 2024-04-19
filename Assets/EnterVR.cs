using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVR : MonoBehaviour
{
    public GameObject environment;
    public GameObject passthroughWindow;
    public OVRPassthroughLayer oVRPassthroughLayer;
    public GameObject passThrough;
    public GameObject cameraRig;

    void OnCollisionEnter(Collision col)
    {
        //if vr player's hand touched the vr window
        if (col.gameObject.name == "Aloe_Grabbable_Pot")
        {
            //set back to vr
            oVRPassthroughLayer.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.UserDefined;
            oVRPassthroughLayer.overlayType = OVROverlay.OverlayType.Underlay;

            //enable greenhouse
            environment.SetActive(true);

            //get player controller in camera rig
            cameraRig.GetComponent<CharacterController>().enabled = true;

            //get OVR Player
            cameraRig.GetComponent<OVRPlayerController>().enabled = true;

            passthroughWindow.SetActive(true);
            passThrough.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
