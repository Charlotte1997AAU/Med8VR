using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateButton : MonoBehaviour
{
    public GameObject[] disableButtons;
    // Rotation speed in degrees per second
    public float rotationSpeed = 120f;
    public float targetAngle = 180f;

    // Audio clip to play
    public AudioClip audioClip;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    private bool soundPlayed = true;
    // Timer to track the delay
    private float delayTimer = 0f;
    private float delayDuration = 0.4f; // Delay duration in seconds

    void Start()
    {

        // Check if an AudioSource component is attached, and if not, add one
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource component
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (soundPlayed && transform.rotation.eulerAngles.y <= 180)
        {
            Debug.Log("We are inside the if statement");
            audioSource.Play();
            soundPlayed = false;
        }
        
        // Increment the delay timer
        delayTimer += Time.deltaTime;

        // Check if enough time has passed
        if (delayTimer >= delayDuration)
        {
            if (transform.rotation.eulerAngles.y < targetAngle)
            {
                // Disable buttons immediately
                foreach (GameObject button in disableButtons)
                {
                    XRSimpleInteractable interactable = button.GetComponent<XRSimpleInteractable>();

                    if (interactable != null)
                    {
                        interactable.enabled = false;
                    }
                }
                // Rotate the GameObject around its local y-axis at a constant speed
                transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
                

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
                // Reset the delay timer
                delayTimer = 0f;
                soundPlayed = true;
                enabled = false;
            }
        }
    }
}
