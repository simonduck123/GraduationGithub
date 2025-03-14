using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene("Test");
        Debug.Log("swap");
    }
}
