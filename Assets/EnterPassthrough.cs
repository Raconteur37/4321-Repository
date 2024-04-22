using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPassthrough : MonoBehaviour
{
    public OVRPassthroughLayer oVRPassthroughLayer;
    public GameObject greenHouse;
    public OVRPassthroughLayer passThrough;
    public GameObject cameraRig;
    public GameObject vrWindow;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Aloe_Grabbable_Pot")
        {
            //oVRPassthroughLayer.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.Reconstructed;
            //oVRPassthroughLayer.overlayType = OVROverlay.OverlayType.Overlay;

            //get player controller in camera rig
            cameraRig.GetComponent<CharacterController>().enabled = false;

            //get OVR Player
            cameraRig.GetComponent<OVRPlayerController>().enabled = false;

            greenHouse.SetActive(false);
            passThrough.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.Reconstructed;
            passThrough.overlayType = OVROverlay.OverlayType.Overlay;
            passThrough.textureOpacity = 1.0f;

            vrWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
