using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MaterialFader : MonoBehaviour
{
    public ButtonInteractionManager buttonInteractionManager;
    public Material targetMaterial; // The material you want to fade
    public float fadeSpeed = 0.5f; // Fading speed (you can adjust this in the inspector)
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
        if (buttonInteractionManager.GetSpecificNumber() == 2)
        {
            SceneManager.LoadScene("WinScene"); 
        }
        else
        {
            SceneManager.LoadScene("FailScene"); 
        }
    }
}

