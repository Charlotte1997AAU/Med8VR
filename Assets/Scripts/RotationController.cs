using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Rotator[] rotators; // Array of Rotator scripts attached to the target objects
    public bool rotateOn = false; // Boolean to toggle rotation on/off
    public AudioSource rotationSound; // Reference to the AudioSource component for playing sound

    public void startRotation()
    {
        rotateOn = true;
    }


    void Update()
    {
        if (rotateOn)
        {
            foreach (Rotator rotator in rotators)
            {
                rotator.RotateForward();
            }
            if (rotationSound != null)
                rotationSound.Play();
        }
    }
}


