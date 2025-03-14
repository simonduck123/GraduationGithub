using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] lightSource;

    public void TurnOnLights()
    {
        foreach (GameObject light in lightSource)
        {
            light.SetActive(true);
            Debug.Log("true");
        }
    }

    public void TurnOffLights()
    {
        foreach (GameObject light in lightSource)
        {
            light.SetActive(false);
            Debug.Log("false");
        }
    }
}
