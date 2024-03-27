using UnityEngine;

public class Rotate180Degrees : MonoBehaviour
{
    public float rotationSpeed = 50f; // Set rotation speed
    private float totalRotation = 0f; // Track total rotation
    private bool rotateForward = true; // Flag to indicate rotation direction

    private Quaternion initialRotation; // Store initial rotation

    void Start()
    {
        // Store initial rotation
        initialRotation = transform.rotation;
    }

void Update()
{
    // Determine rotation direction
    int direction = rotateForward ? 1 : -1;

    // Rotate the object around its own X axis
    transform.Rotate(Vector3.right * rotationSpeed * direction * Time.deltaTime);

    // Update total rotation
    totalRotation += rotationSpeed * direction * Time.deltaTime;

    // Check if total rotation exceeds 180 degrees in either direction
    if (Mathf.Abs(totalRotation) >= 180f)
    {
        // Reset total rotation
        totalRotation = 0f;

        // Disable the script after the first forward rotation
        if (rotateForward)
        {
            enabled = false;
        }
    }
}

    // Method to enable rotation again
    public void EnableRotation()
    {
        // Reset total rotation
        totalRotation = 0f;
        // Enable the script
        enabled = true;

        // Determine initial rotation compared to the current rotation
        float angleDifference = Quaternion.Angle(initialRotation, transform.rotation);

        // If the angle difference is closer to 180 degrees, start rotating backward
        if (angleDifference > 90f)
        {
            rotateForward = false;
        }
        else
        {
            rotateForward = true;
        }
    }
}