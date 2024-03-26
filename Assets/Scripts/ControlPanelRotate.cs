using UnityEngine;

public class RotateButton : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 20f;
    public float targetAngle = 90f;
    void Update()
    {

        if (transform.rotation.eulerAngles.y < targetAngle)
        {
            // Rotate the GameObject around its local y-axis at a constant speed
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        }
        // Rotate the GameObject around its local y-axis at a constant speed
        //transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        Debug.Log("Rotation Angles: " + transform.rotation.eulerAngles);
    }
}
