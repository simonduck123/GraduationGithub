using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
    public void TurnOnFlock()
    {
        this.gameObject.SetActive(true);
    }

    public void TurnOffFlock()
    {
        this.gameObject.SetActive(false);
    }
}
