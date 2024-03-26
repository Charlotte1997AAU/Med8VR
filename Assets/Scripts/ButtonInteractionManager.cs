using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractionManager : MonoBehaviour
{
    public LightController lightController; // Reference to the LightController script

    // Variable to store the specific number
    private int specificNumber;

    // Function to set the specific number
    public void SetSpecificNumber(int number)
    {
        specificNumber = number;
    }

    // Function to read the specific number and turn off lights based on it
    public void ReadSpecificNumberAndTurnOffLight()
    {
        // Call the TurnOffLight method of LightController based on the specific number
        lightController.TurnOffLight(specificNumber);
    }
}
