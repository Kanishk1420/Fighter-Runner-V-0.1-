using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this speed as needed

    void Update()
    {
        // Move the camera continuously in the positive y-axis
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
