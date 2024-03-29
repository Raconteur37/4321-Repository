using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportController : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;

    public InputHelpers.Button teleportRayButton;

    public float activationThreshold = 0.1f;    // how much is the button thress till it activates

    private XRInteractorLineVisual leftRay;
    private GameObject leftReticle;

    private XRInteractorLineVisual rightRay;
    private GameObject rightReticle;


    // Start is called before the first frame update
    void Start()
    {
        leftRay = leftController.gameObject.GetComponent<XRInteractorLineVisual>();
        leftReticle = leftRay.reticle;

        rightRay = rightController.gameObject.GetComponent<XRInteractorLineVisual>();
        rightReticle = rightRay.reticle;
    }

    // Update is called once per frame
    void Update()
    {
        bool isLeftPressed = isButtonPressed(leftController);
        leftRay.enabled = isLeftPressed;
        leftReticle.SetActive(isLeftPressed);

        bool isRightPressed = isButtonPressed(rightController);
        rightRay.enabled = isRightPressed;
        rightReticle.SetActive(isRightPressed);
    }

    public bool isButtonPressed(XRController controller)
    {
        //takes the input device, the button that is being check if pressed, boolean that will determine if button is pressed, a threshold of what defines a press
        InputHelpers.IsPressed(controller.inputDevice, teleportRayButton, out bool isPressed, activationThreshold);

        //does it checcks and returns tru if device and button are valid. otherwise, returns false
        return isPressed;
    }
}
