using UnityEngine;

public class RotateTabletOpposite : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 20f;
    public float targetAngle = 30f;
    void Update()
    {

        if (transform.rotation.eulerAngles.y > targetAngle)
        {
            // Rotate the GameObject around its local y-axis at a constant speed
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        // Rotate the GameObject around its local y-axis at a constant speed
        //transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
}
