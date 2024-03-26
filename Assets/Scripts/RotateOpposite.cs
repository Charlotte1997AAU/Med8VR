using UnityEngine;

public class RotateOpposite : MonoBehaviour
{
    public float rotationSpeed = 50f; // Set rotation speed
    private Quaternion initialRotation; // Store initial rotation
    private Quaternion targetRotation; // Store target rotation

    private bool isRotating = true;

    void Start()
    {
        // Store initial rotation
        initialRotation = transform.rotation;

        // Calculate target rotation (180 degrees from initial rotation in the opposite direction)
        targetRotation = initialRotation * Quaternion.Euler(-180f, 0f, 0f);
    }

    void Update()
    {
        if (isRotating)
        {
            // Rotate the object towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the object has reached the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                // Stop rotating
                isRotating = false;
                Debug.Log("Object reached target rotation.");
            }
        }
    }
}
