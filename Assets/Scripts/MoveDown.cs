using UnityEngine;
using System.Collections;

public class MoveDown : MonoBehaviour
{
    public float endPointY = -10f; // Adjust this value in the inspector
    public float moveSpeed = 1f; // Adjust this value in the inspector
    public float startDelay = 1f; // Delay before starting movement
    public AudioClip moveSound; // Sound to play while moving

    private bool isMoving = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.loop = true; // Loop the sound while moving
        }
        StartCoroutine(StartMovingWithDelay());
    }

    IEnumerator StartMovingWithDelay()
    {
        yield return new WaitForSeconds(startDelay);
        isMoving = true;
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the object downwards
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // Check if the object reached the endpoint
            if (transform.position.y <= endPointY)
            {
                isMoving = false;
                if (audioSource != null)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
