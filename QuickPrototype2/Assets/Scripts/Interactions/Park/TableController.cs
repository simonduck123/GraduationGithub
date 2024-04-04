using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public void TableAppear()
    {
        this.gameObject.SetActive(true);
    }

    public void TableDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
