using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ScalePlant : MonoBehaviour
{
    public RealtimeTransform realtimeTransform;
    private float scale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Passed in?
        if (realtimeTransform == null) { return; }

        realtimeTransform.RequestOwnership();
        transform.localScale = new Vector3(scale, scale, scale);
        scale += 0.001f;
        realtimeTransform.ClearOwnership();
    }
}
