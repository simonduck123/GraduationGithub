using UnityEngine;
using TMPro; // Make sure you have this namespace

public class InteractionManager : MonoBehaviour
{
    // Reference to your canvas text element
    public TextMeshProUGUI interactionText; // Use TextMeshProUGUI instead of Text

    // A method to call from the  BoxInteraction script to update the text
    public void UpdateInteractionText(string newText)
    {
        interactionText.text = "Action: " + newText;
    }
}
