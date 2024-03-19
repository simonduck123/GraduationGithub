using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public void OrbAppear()
    {
        this.gameObject.SetActive(true);
    }

    public void OrbDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
