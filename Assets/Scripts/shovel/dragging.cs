using UnityEngine;
using UnityEngine.EventSystems;

public class ShovelDragObject : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool isDragging = false;
    private Vector3 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calculate the offset between the object's position and the mouse position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            // Update the object's position based on the mouse position
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
