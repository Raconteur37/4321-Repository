using System;  // might need to delete with Guid
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SunSpatialAnchor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Retrive the contents of scene
    private async void retriveContentsOfScene()
    {
        var anchors = new List<OVRAnchor>();
        await OVRAnchor.FetchAnchorsAsync<OVRRoomLayout>(anchors);

        // no rooms - call Space Setup or check Scene permission
        if (anchors.Count == 0)
            return;

        // access anchor data by retrieving the components
        var room = anchors.First();

        // access the ceiling, floor and walls with the OVRRoomLayout component
        var roomLayout = room.GetComponent<OVRRoomLayout>();
        if (roomLayout.TryGetRoomLayout(out Guid ceiling, out Guid floor, out Guid[] walls))
        {
            // use these guids to fetch the OVRAnchor object directly
            await OVRAnchor.FetchAnchorsAsync(walls, anchors);
        }

        // access the list of children with the OVRAnchorContainer component
        if (!room.TryGetComponent(out OVRAnchorContainer container))
            return;

        // use the component helper function to access all child anchors
        await container.FetchChildrenAsync(anchors);
    }

}
