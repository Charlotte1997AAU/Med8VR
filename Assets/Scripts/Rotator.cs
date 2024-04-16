using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Public variable for rotation speed

    private bool rotating = false; // Flag to control rotation

    public void RotateForward()
    {
        // If already rotating, return
        if (rotating)
            return;

        // Calculate the target rotation (180 degrees from the current rotation)
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 180, 0);

        // Start coroutine to rotate gradually
        StartCoroutine(RotateTo(targetRotation));
    }

    private IEnumerator RotateTo(Quaternion targetRotation)
    {
        rotating = true;
        
        // Calculate the rotation step based on rotation speed
        float step = rotationSpeed * Time.deltaTime;

        // Rotate gradually towards the target rotation
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
            yield return null;
        }

        // Set the rotation to exactly the target rotation
        transform.rotation = targetRotation;

        rotating = false;
    }
}
