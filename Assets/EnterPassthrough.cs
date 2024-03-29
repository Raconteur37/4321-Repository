using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPassthrough : MonoBehaviour
{
    public OVRPassthroughLayer oVRPassthroughLayer;
    public GameObject greenHouse;
    public GameObject passThrough;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "NetworkGrabbablePlant")
        {
            oVRPassthroughLayer.projectionSurfaceType = OVRPassthroughLayer.ProjectionSurfaceType.Reconstructed;
            oVRPassthroughLayer.overlayType = OVROverlay.OverlayType.Overlay;
            greenHouse.SetActive(false);
            passThrough.SetActive(true);
        }
    }

}
