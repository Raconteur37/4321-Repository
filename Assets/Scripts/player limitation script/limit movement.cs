using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply movement speed
        rb.velocity = movement * movementSpeed;
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if colliding with an object tagged as "Greenhouse"
        if (collision.gameObject.CompareTag("Greenhouse"))
        {
            // Prevent movement in the direction of the collision
            rb.velocity = Vector3.zero;
        }
    }
}
