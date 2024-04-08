using UnityEngine;

public class MaterialFadeOut : MonoBehaviour
{
    public Material targetMaterial; // The material you want to fade
    public float fadeSpeed = 0.5f; // Fading speed (you can adjust this in the inspector)

    private float currentAlpha = 1f; // Current alpha value of the material

    void Start()
    {
        // Ensure the material exists and has its alpha set to 1 at the start
        if (targetMaterial != null)
        {
            Color materialColor = targetMaterial.color;
            materialColor.a = 1f;
            targetMaterial.color = materialColor;
        }
        else
        {
            Debug.LogError("Target material is not assigned!");
        }
    }

    void Update()
    {
        // Gradually decrease the alpha value towards 0
        if (currentAlpha > 0f)
        {
            currentAlpha -= fadeSpeed * Time.deltaTime;
            currentAlpha = Mathf.Clamp01(currentAlpha); // Ensure alpha stays between 0 and 1

            Color materialColor = targetMaterial.color;
            materialColor.a = currentAlpha;
            targetMaterial.color = materialColor;
        }
    }
}
