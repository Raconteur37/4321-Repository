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
        // Start the coroutine
        StartCoroutine(ScaleCubeCoroutine());
    }

    // Define the scaling factor
    public float scaleIncreaseAmount = 0.1f;

    IEnumerator ScaleCubeCoroutine()
    {
        while (true)
        {
            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);
            realtimeTransform.RequestOwnership();
            // Increase the scale of the cube
            transform.localScale += new Vector3(scaleIncreaseAmount, scaleIncreaseAmount, scaleIncreaseAmount);
        }
    }
}
