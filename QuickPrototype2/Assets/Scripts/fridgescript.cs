using UnityEngine;

public class fridgescript : MonoBehaviour
{
    public Animator fridgeAnimator; // Reference to the fridge's animator component
    public GameObject can;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if it's the player
        {
            fridgeAnimator.SetTrigger("IsOpen"); // Trigger the "IsOpen" parameter
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fridgeAnimator.SetBool("IsOpen", false); // Set "IsOpen" parameter to false
            can.SetActive(true);
        }
    }
}
