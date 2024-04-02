using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateTabletOpposite : MonoBehaviour
{
     public GameObject[] disableButtons;
    // Rotation speed in degrees per second
    public float rotationSpeed = 120f;
    public float targetAngle = 30f;

    private float delayTimer = 0f;
    private float delayDuration = 0.4f; // Delay duration in seconds


    void Update()
    {
        delayTimer += Time.deltaTime;

        // Check if enough time has passed
        if (delayTimer >= delayDuration)
        {

            if (transform.rotation.eulerAngles.y > targetAngle)
            {
                 foreach (GameObject button in disableButtons)
                {
                    XRSimpleInteractable interactable = button.GetComponent<XRSimpleInteractable>();

                    if (interactable != null)
                    {
                        interactable.enabled = false;
                    }
                }
                // Rotate the GameObject around its local y-axis at a constant speed
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            
            else
            {
                foreach (GameObject button in disableButtons)
                {
                    XRSimpleInteractable interactable = button.GetComponent<XRSimpleInteractable>();

                    if (interactable != null)
                    {
                        interactable.enabled = true;
                    }
                }
                enabled = false;
            }
        }
    }
}
