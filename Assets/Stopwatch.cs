using Normal.Realtime;
using UnityEngine;

using System;
using UnityEngine.UIElements;

public class Stopwatch : RealtimeComponent<StopwatchModel>
{
    public Transform cube;
    private float scale = 0.1f;

    public float time
    {
        get
        {
            // Return 0 if we're not connected to the room yet.
            if (model == null) return 0.0f;

            // Make sure the stopwatch is running
            if (model.startTime == 0.0) return 0.0f;

            // Calculate how much time has passed
            return (float)(realtime.room.time - model.startTime);
        }
    }

    private void Update()
    {
        double time = Math.Round(realtime.room.time);
        if ( time % 2 == 0)
        {
            Debug.Log(time);
            scale += 0.0001f;
            cube.transform.localScale = new Vector3(scale, scale, scale);
        }
    }


    public void StartStopwatch()
    {
        model.startTime = realtime.room.time;
    }


}