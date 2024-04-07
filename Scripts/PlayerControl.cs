using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftBorder = -5f; // Left border position
    public float rightBorder = 5f; // Right border position// Adjust this value to control player movement speed

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        // Get input for horizontal movement (left and right)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the player's new position based on input and speed
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Restrict the player's position within the left and right borders
        float clampedX = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    
    // Horizontal movement
    float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        
        
    }
}
