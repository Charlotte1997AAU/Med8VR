using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{
    public Light[] lights; // Array to hold all the light sources
    public AudioClip lightSound; // Sound clip for all lights
    private AudioSource audioSource; // AudioSource component to play the sound

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartLightSequence());
    }

    IEnumerator StartLightSequence()
    {
        // Wait for 1 second before starting the light sequence
        yield return new WaitForSeconds(1.0f);

        // Start turning on lights
        StartCoroutine(TurnOnLightsWithDelay());
    }

    IEnumerator TurnOnLightsWithDelay()
    {
        // Loop through each light source
        for (int i = 0; i < lights.Length; i++)
        {
            // Turn on the light
            lights[i].enabled = true;

            // Play the sound associated with the light
            if (lightSound != null)
            {
                audioSource.PlayOneShot(lightSound);
            }

            // Wait for 1 second before turning on the next light
            yield return new WaitForSeconds(1.0f);
        }
    }
}
