using UnityEngine;

public class LightColorChange : MonoBehaviour
{
    public Material targetMaterial; // Reference to the material you want to modify
    public Color normalColor = Color.white; // Default color
    public Color litColor = Color.red; // Color when lit by the specific light source
    public Light specificLight; // Reference to the specific light source

    void Update()
    {
       RaycastHit hit;
    Vector3 raycastDirection = specificLight.transform.position - transform.position; // Calculate the raycast direction

    // Perform the raycast
    if (Physics.Raycast(transform.position, raycastDirection, out hit))
    {
        Debug.DrawRay(transform.position, raycastDirection, Color.green); // Draw the ray for visualization
        Debug.Log("Raycast direction: " + raycastDirection);

        // Check if the hit object is the specific light source
        if (hit.collider.GetComponent<Light>() == specificLight)
        {
            Debug.Log("Hit object is the specific light source!");
            targetMaterial.color = litColor;
        }
        else
        {
            Debug.Log("Hit object is not the specific light source.");
            targetMaterial.color = normalColor;
        }
    }
    }

    bool IsHitBySpecificLight()
    {
        // Cast a ray from the object to detect if it's hit by the specific light source
        RaycastHit hit;
        if (Physics.Raycast(transform.position, specificLight.transform.forward, out hit))
        {
            // Check if the hit object is the specific light source
            if (hit.collider.GetComponent<Light>() != null)
            {
                Debug.Log("Hit object is a Light!");
        Debug.Log("Hit object name: " + hit.collider.name);
        Debug.Log("Specific light name: " + specificLight.name);
                Debug.Log("HITHITHITHTIHTI");
                return true; // Return true if hit by the specific light source
            }
        }
        return false; // Return false if not hit by the specific light source
    }
}
