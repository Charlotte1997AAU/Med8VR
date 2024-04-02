using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject otherGameObject;
    private GameObject cylinderObject; // Variable to hold the cylinder GameObject

    public float CalculateDistanceInCentimeters()
    {
        if (otherGameObject != null)
        {
            float distance = Vector3.Distance(transform.position, otherGameObject.transform.position);
            float distanceInCentimeters = Mathf.Round(distance * 100f); // Convert distance to centimeters
            return distanceInCentimeters;
        }
        else
        {
            Debug.LogError("Other GameObject is not assigned!");
            return -1f; // Return a negative value to indicate an error
        }
    }

    void Update()
    {
        float distanceInCentimeters = CalculateDistanceInCentimeters();
        Debug.Log("Distance between the two GameObjects in centimeters: " + distanceInCentimeters);

        // Destroy previous cylinder object if it exists
        if (cylinderObject != null)
        {
            Destroy(cylinderObject);
        }

        // Create a cylinder GameObject dynamically
        cylinderObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // Calculate position between the two GameObjects
        Vector3 position = (transform.position + otherGameObject.transform.position) / 2f;

        // Set the position of the cylinder
        cylinderObject.transform.position = position;

        // Calculate the scale of the cylinder based on distance
        float diameter = 0.1f; // Diameter of the cylinder
        cylinderObject.transform.localScale = new Vector3(diameter, distanceInCentimeters / 100f, diameter);

        // Rotate the cylinder to align with the direction between the two GameObjects
        cylinderObject.transform.LookAt(otherGameObject.transform);

        // Offset the rotation by 90 degrees on the x-axis to make it vertical
        cylinderObject.transform.Rotate(90f, 0f, 0f);
    }
}
