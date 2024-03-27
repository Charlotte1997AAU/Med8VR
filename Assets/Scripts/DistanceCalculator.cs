using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    // Public variable to hold the reference to the other GameObject
    public GameObject otherGameObject;

    // Function to calculate and return the distance between the two GameObjects in centimeters
    public float CalculateDistanceInCentimeters()
    {
        if (otherGameObject != null)
        {
            // Calculate the distance using Vector3.Distance method
            float distance = Vector3.Distance(transform.position, otherGameObject.transform.position);

            // Convert the distance from meters to centimeters and round it to the nearest whole number
            float distanceInCentimeters = Mathf.Round(distance * 100f); // 1 meter = 100 centimeters

            return distanceInCentimeters;
        }
        else
        {
            Debug.LogError("Other GameObject is not assigned!");
            return -1f; // Return a negative value to indicate an error
        }
    }

    // Example of how to use the CalculateDistanceInCentimeters function
    void Update()
    {
        // Calculate and log the distance between the two GameObjects in centimeters every frame
        float distanceInCentimeters = CalculateDistanceInCentimeters();
        Debug.Log("Distance between the two GameObjects in centimeters: " + distanceInCentimeters);
    }
}
