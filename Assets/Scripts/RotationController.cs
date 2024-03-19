using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Rotator[] rotators; // Array of Rotator scripts attached to the target objects
    public bool rotateOn = false; // Boolean to toggle rotation on/off

    public AudioSource rotationSound; // Reference to the AudioSource component for playing sound

    private bool previousRotateOn = false; // To keep track of the previous state of rotateOn

    void Update()
    {
        // Check if rotateOn is true and rotators array is assigned
        if (rotateOn && rotators != null && rotateOn != previousRotateOn)
        {
            // Enable Rotator scripts to start rotation for all target objects
            foreach (Rotator rotator in rotators)
            {
                if (rotator != null)
                    rotator.enabled = true;
            }

            // Play rotation sound if assigned
            if (rotationSound != null)
                rotationSound.Play();
        }
        else if (!rotateOn && previousRotateOn)
        {
            // Disable Rotator scripts to stop rotation for all target objects
            foreach (Rotator rotator in rotators)
            {
                if (rotator != null)
                    rotator.enabled = false;
            }
        }

        // Update previousRotateOn
        previousRotateOn = rotateOn;
    }
}
