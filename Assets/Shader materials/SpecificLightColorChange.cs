using UnityEngine;

public class LightColorChange : MonoBehaviour
{
    public Material targetMaterial; // Reference to the material you want to modify
    public Color normalColor = Color.white; // Default color
    public Color litColor = Color.red; // Color when lit by the specific light source
    public Light specificLight; // Reference to the specific light source

    void Update()
    {
        if (IsHitBySpecificLight())
        {
            Debug.Log("Object is hit by specific light.");
            targetMaterial.color = litColor;
        }
        else
        {
            Debug.Log("Object is not hit by specific light.");
            targetMaterial.color = normalColor;
        }
    }

    bool IsHitBySpecificLight()
    {
        // Cast a ray from the specific light towards the object to detect if it hits it
        RaycastHit hit;
        Vector3 raycastDirection = transform.position - specificLight.transform.position;
        if (Physics.Raycast(specificLight.transform.position, raycastDirection, out hit))
        {
            // Visualize the ray
            Debug.DrawRay(specificLight.transform.position, raycastDirection, Color.green);

            // Check if the hit object is the gameObject
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Hit by specific light!");
                return true; // Return true if hit by the specific light source
            }
        }

        // Visualize the ray even if no hit occurs
        Debug.DrawRay(specificLight.transform.position, raycastDirection, Color.red);

        return false; // Return false if not hit by the specific light source
    }
}
