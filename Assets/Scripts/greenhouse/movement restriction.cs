using UnityEngine;

public class RestrictPlayerMovement : MonoBehaviour
{
    private Collider boundaryCollider;

    void Start()
    {
        // Find the collider of the greenhouse boundary
        boundaryCollider = GameObject.FindGameObjectWithTag("GreenhouseBoundary").GetComponent<Collider>();

        // Ensure the boundary collider is not null
        if (boundaryCollider == null)
        {
            Debug.LogError("Boundary collider not found. Make sure you have tagged the greenhouse boundary collider with 'GreenhouseBoundary'.");
        }
    }

    void FixedUpdate()
    {
        // Restrict player movement within the boundary collider
        if (boundaryCollider != null)
        {
            Vector3 newPosition = transform.position;

            // Clamp the player's position to stay within the boundary
            newPosition.x = Mathf.Clamp(newPosition.x, boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x);
            newPosition.z = Mathf.Clamp(newPosition.z, boundaryCollider.bounds.min.z, boundaryCollider.bounds.max.z);

            // Update the player's position
            transform.position = newPosition;
        }
    }
}
