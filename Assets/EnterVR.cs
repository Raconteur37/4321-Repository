using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterVR : MonoBehaviour
{
    public GameObject environment;
    public GameObject passthroughWindow;
    public OVRPassthroughLayer oVRPassthroughLayer;
    public OVRPassthroughLayer passThrough;
    public GameObject cameraRig;
    public TextMeshProUGUI text;

    void OnCollisionEnter(Collision col)
    {
        //if vr player's hand touched the vr window
        if (col.gameObject.name == "Aloe_Grabbable_Pot")
        {
            //set back to vr
            //oVRPassthroughLayer.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.UserDefined;
            //oVRPassthroughLayer.overlayType = OVROverlay.OverlayType.Underlay;

            //enable greenhouse
            environment.SetActive(true);

            //get player controller in camera rig
            cameraRig.GetComponent<CharacterController>().enabled = true;

            //get OVR Player
            cameraRig.GetComponent<OVRPlayerController>().enabled = true;

            //passthroughWindow.SetActive(true);
            passThrough.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.Reconstructed;
            passThrough.overlayType = OVROverlay.OverlayType.None;
            passThrough.textureOpacity = 0.0f;

            passthroughWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
