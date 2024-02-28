using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed

    void Update()
    {
        // Get input (adjust "Horizontal" and "Vertical" if you changed them in Input Manager)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize for consistent speed diagonally
        movement.Normalize();

        // Apply movement (multiplied by speed and time for smooth motion)
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
