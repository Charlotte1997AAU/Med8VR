using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float rotationDuration = 1.0f; // Duration for each rotation in seconds

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
        
        float elapsedTime = 0.0f;
        Quaternion startRotation = transform.rotation;

        // Rotate gradually towards the target rotation
        while (elapsedTime < rotationDuration)
        {
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set the rotation to exactly the target rotation
        transform.rotation = targetRotation;

        rotating = false;
    }
}
