using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HandMeasuring : MonoBehaviour
{
    public DistanceCalculator distanceCalculator; // Reference to the ButtonInteractionManager script
    public TMP_Text textObject; // Reference to the TextMeshPro object to display the number

    void Update()
    {
        // Get the specific number from ButtonInteractionManager
        float specificNumberValue = distanceCalculator.CalculateDistanceInCentimeters();

        // Update the TextMeshPro object with the specific number
        string Numb = specificNumberValue.ToString();
        textObject.text = Numb;
    }
}
