using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour
{
    public Animator fridgeAnimator;
    public bool fridgeOpen;

    public void OpenFridge()
    {
        Debug.Log("Should Open now");
        fridgeAnimator.SetBool("FridgeOpen", true);
    }

    public void CloseFridge()
    {
        Debug.Log("Should Close now");
        fridgeAnimator.SetBool("FridgeOpen", false);
    }
}
