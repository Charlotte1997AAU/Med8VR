using UnityEngine;
using TMPro;

public class NumberDisplay : MonoBehaviour
{
    public ButtonInteractionManager buttonManager; // Reference to the ButtonInteractionManager script
    public TMP_Text textObject; // Reference to the TextMeshPro object to display the number

    void Update()
    {
        // Get the specific number from ButtonInteractionManager
        int specificNumberValue = buttonManager.GetSpecificNumber();

        // Update the TextMeshPro object with the specific number
        int Numb = specificNumberValue+=1; 
        textObject.text = "Painting " + Numb;
    }
}
