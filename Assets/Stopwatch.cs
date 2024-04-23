using Normal.Realtime;
using UnityEngine;

public class Stopwatch : RealtimeComponent<StopwatchModel>
{
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

    public void StartStopwatch()
    {
        model.startTime = realtime.room.time;
    }
}