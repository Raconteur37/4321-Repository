using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class StopwatchModel
{
    [RealtimeProperty(1, true)]
    private double _startTime;
}