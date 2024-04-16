using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractionManager : MonoBehaviour
{
    // Variable to store the specific number
    private int specificNumber;

    // Function to set the specific number
    public void SetSpecificNumber(int number)
    {
        specificNumber = number;
        Debug.Log("light number: " + number);
    }

    public int GetSpecificNumber()
    {
        return specificNumber;
    }

}
