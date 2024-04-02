using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public Renderer rend;
    public Material rendMaterial;

    private void Start()
    {
        rendMaterial = rend.GetComponent<Renderer>().material;
    }

    public void TurnOnComputer()
    {
        Debug.Log("Should Computer now");
        rendMaterial.EnableKeyword("_EMISSION");
    }

    public void TurnOffComputer()
    {
        Debug.Log("Should Computer Off");
        rendMaterial.DisableKeyword("_EMISSION");
    }

}
