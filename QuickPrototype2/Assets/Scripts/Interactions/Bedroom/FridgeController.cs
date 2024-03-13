using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour
{
    public Animator fridgeAnimator;
    public bool fridgeOpen;

    public void OpenFridge()
    {
        fridgeOpen = true;
        fridgeAnimator.SetBool("FridgeOpen", fridgeOpen);
    }

    public void CloseFridge()
    {
        fridgeOpen = false;
        fridgeAnimator.SetBool("FridgeOpen", fridgeOpen);
    }
}
