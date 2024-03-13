using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanController : MonoBehaviour
{
    public void MakeCanAppear()
    {
        this.gameObject.SetActive(true);
    }

    public void MakeCanDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
