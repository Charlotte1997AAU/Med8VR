using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class RotateToPosition : MonoBehaviour
{
    public GameObject[] frontButtons;
    public GameObject[] backButtons;
    private float forwardRotation = -142f; // Set the forward rotation
    private float backwardRotation = 38f; // Set the backward rotation
    private float rotationSpeed = 150f; // Set rotation speed
    private float bufferPeriod = 0.1f; // Set the buffer period in seconds
    private Quaternion forwardQuaternion; // Store forward rotation in Quaternion representation
    private Quaternion backwardQuaternion; // Store backward rotation in Quaternion representation
    private bool rotationInProgress = false; // Flag to track if rotation is in progress

    void Start()
    {
        // Calculate the forward and backward rotations in Quaternion representation
        forwardQuaternion = Quaternion.Euler(forwardRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        backwardQuaternion = Quaternion.Euler(backwardRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        // You can leave this empty if you only want to use the SetTargetRotation method.
    }

    // Method to set a new target rotation
    public void SetTargetRotation(float newTargetRotation)
    {
        // Update target rotation
        forwardRotation = newTargetRotation;
        // Recalculate the forward rotation in Quaternion representation
        forwardQuaternion = Quaternion.Euler(forwardRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    // Rotate the object to the forward position (-142 degrees)
    public void RotateToForwardPosition()
    {
        if (!rotationInProgress)
        {
            StartCoroutine(RotateWithBuffer(forwardQuaternion, frontButtons, backButtons));
        }
    }

    // Rotate the object to the backward position (38 degrees)
    public void RotateToBackwardPosition()
    {
        if (!rotationInProgress)
        {
            StartCoroutine(RotateWithBuffer(backwardQuaternion, backButtons, frontButtons));
        }
    }

    // Coroutine to rotate with buffer period before enabling buttons
    private IEnumerator RotateWithBuffer(Quaternion targetQuaternion, GameObject[] disableButtons, GameObject[] enableButtons)
    {
        rotationInProgress = true;

        // Disable buttons immediately
        foreach (GameObject button in disableButtons)
        {
            XRSimpleInteractable interactable = button.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                interactable.enabled = false;
            }
        }


        // Rotate towards the target
        while (transform.rotation != targetQuaternion)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Wait for buffer period
        yield return new WaitForSeconds(bufferPeriod);

        // Enable buttons after buffer period
        foreach (GameObject button in enableButtons)
        {
            XRSimpleInteractable interactable = button.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                interactable.enabled = true;
            }
        }

        rotationInProgress = false;
    }

    // Getter method for forwardQuaternion
    public Quaternion GetForwardQuaternion()
    {
        return forwardQuaternion;
    }

    // Getter method for backwardQuaternion
    public Quaternion GetBackwardQuaternion()
    {
        return backwardQuaternion;
    }
}
