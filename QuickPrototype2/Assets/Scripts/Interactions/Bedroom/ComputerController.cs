using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public Renderer rend;
    public Material rendMaterial;

    private void Start()
    {
        rendMaterial = rend.GetComponent<Renderer>().materials[1];
    }

    public void TurnOnComputer()
    {
        rendMaterial.EnableKeyword("_EMISSION");
    }

    public void TurnOffComputer()
    {
        rendMaterial.DisableKeyword("_EMISSION");
    }

}
