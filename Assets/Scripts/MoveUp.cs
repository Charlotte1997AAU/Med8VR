using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float endPointY = 10f; // Adjust this value in the inspector
    public float moveSpeed = 1f; // Adjust this value in the inspector

    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            // Move the object upwards
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Check if the object reached the endpoint
            if (transform.position.y >= endPointY)
            {
                isMoving = false;
            }
        }
    }
}
