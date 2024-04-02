using Normal.Realtime;
using UnityEngine;

public class GetRoomTime : MonoBehaviour
{
    public GameObject realtimeGO = null;

    private Realtime realtime = null;

    private void Start()
    {
        realtime = realtimeGO.GetComponent<Realtime>();
    }

    // Update is called once per frame
    void Update()
    {
        if(realtime != null)
        {
            //DateTime realTime = DateTimeOffset.FromUnixTimeSeconds(realtime.roomTime).UtcDateTime;
            Debug.Log("Room time: " + realtime.roomTime.ToString());
        }
    }
}
