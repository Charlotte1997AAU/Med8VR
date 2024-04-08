using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MaterialFader : MonoBehaviour
{
    public Material targetMaterial; // The material you want to fade
    public float fadeSpeed = 0.5f; // Fading speed (you can adjust this in the inspector)
    public List<GameObject> objectsToCheck; // List of GameObjects to check for disabling

    private float currentAlpha = 0f; // Current alpha value of the material
    private bool fadingCompleted = false; // Flag to indicate if fading is completed

    void Start()
    {
        // Ensure the material exists and has its alpha set to 0 at the start
        if (targetMaterial != null)
        {
            Color materialColor = targetMaterial.color;
            materialColor.a = 0f;
            targetMaterial.color = materialColor;
        }
        else
        {
            Debug.LogError("Target material is not assigned!");
        }
    }

    void Update()
    {
        // Gradually increase the alpha value towards 1 if fading is not completed
        if (!fadingCompleted)
        {
            if (currentAlpha < 1f)
            {
                currentAlpha += fadeSpeed * Time.deltaTime;
                currentAlpha = Mathf.Clamp01(currentAlpha); // Ensure alpha stays between 0 and 1

                Color materialColor = targetMaterial.color;
                materialColor.a = currentAlpha;
                targetMaterial.color = materialColor;
            }
            else
            {
                fadingCompleted = true; // Fading is completed
                CheckObjectsAndSwitchScene(); // Check objects and switch scene
            }
        }
    }

void CheckObjectsAndSwitchScene()
{
    bool anyLightEnabled = false; // Flag to indicate if any light component is enabled

    // Check if any lights in the list are enabled
    foreach (GameObject obj in objectsToCheck)
    {
        Light lightComponent = obj.GetComponent<Light>();
        if (lightComponent != null && lightComponent.enabled)
        {
            anyLightEnabled = true;
            break; // Exit the loop as soon as an enabled light is found
        }
    }

    // Determine which scene to load based on the flag
    if (anyLightEnabled)
    {
        SceneManager.LoadScene("FailScene"); // Load FailScene if any light is enabled
    }
    else
    {
        SceneManager.LoadScene("WinScene"); // Load WinScene if no light is enabled
    }
}

}
