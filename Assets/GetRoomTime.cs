using UnityEngine;
using TMPro;
using Normal.Realtime;
using System;

public class GetRoomTime : MonoBehaviour
{
    public TMP_Text text = null;
    public GameObject realtimeGO = null;

    private Realtime realtime = null;

    private void Start()
    {
        realtime = realtimeGO.GetComponent<Realtime>();
    }
    // Update is called once per frame
    void Update()
    {
        if(text != null && realtime != null)
        {
            //DateTime realTime = DateTimeOffset.FromUnixTimeSeconds(realtime.roomTime).UtcDateTime;
            text.text = "Room time: " + realtime.roomTime.ToString();
        }
    }
}
