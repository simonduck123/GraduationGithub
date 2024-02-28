using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    // Reference to your InteractionManager
    public InteractionManager interactionManager;

    //  Text to display specific to this box
    public string interactionMessage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the InteractionManager 
            interactionManager.UpdateInteractionText(interactionMessage);
        }
    }


}
