using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Public variable for rotation speed
    private Quaternion startRotation; // Initial rotation of the object
    private Quaternion targetRotation; // Target rotation (180 degrees from initial rotation)
    public RotationController rotationController;

    private bool rotating = true; // Flag to control rotation

    private bool forwards = true; 

    void Start()
    {
        // Store the initial rotation of the object
        startRotation = transform.rotation;

        // Calculate the target rotation (180 degrees from initial rotation)
        targetRotation = Quaternion.Euler(startRotation.eulerAngles + new Vector3(0, 180, 0));

    }

    public void RotateForward()
    {
        if (!rotating)
            return;

        if (forwards)
        {
            // Rotate the GameObject around its own Y axis
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            // Check if the rotation has reached or exceeded the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.1f)
            {
                // Set the rotation to exactly 180 degrees
                transform.rotation = targetRotation;

                // Disable further rotation
                rotating = false;
                forwards = false;
            }
        }
        startRotation = transform.rotation;
    }
}
