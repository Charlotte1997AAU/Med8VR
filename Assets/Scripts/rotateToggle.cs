using UnityEngine;

public class rotateToggle : MonoBehaviour
{
    public RotateToPosition rotateToPositionScript; // Reference to the RotateToPosition script
    public bool rotateToForward = false; // Set to true to rotate to forward position
    public bool rotateToBackward = false; // Set to true to rotate to backward position

    void Update()
    {
        // If rotateToForward is true, call RotateToForwardPosition function
        if (rotateToForward)
        {
            rotateToPositionScript.RotateToForwardPosition();

            // Check if the rotation has reached the target before disabling the bool
            if (Quaternion.Angle(transform.rotation, rotateToPositionScript.GetForwardQuaternion()) < 0.1f)
            {
                rotateToForward = false; // Disable the bool
            }
        }

        // If rotateToBackward is true, call RotateToBackwardPosition function
        if (rotateToBackward)
        {
            rotateToPositionScript.RotateToBackwardPosition();

            // Check if the rotation has reached the target before disabling the bool
            if (Quaternion.Angle(transform.rotation, rotateToPositionScript.GetBackwardQuaternion()) < 0.1f)
            {
                rotateToBackward = false; // Disable the bool
            }
        }
    }
}
