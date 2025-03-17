using UnityEngine;
using UnityEngine.SceneManagement;
using extOSC;

public class SceneSwitcher : MonoBehaviour
{
    public OSCReceiver oscReceiver; // Assign in Inspector
    private string oscAddress = "/scene"; // OSC message to listen for

    private void Start()
    {
        if (oscReceiver != null)
        {
            oscReceiver.Bind(oscAddress, OnSceneChangeReceived);
        }
        else
        {
            Debug.LogError("OSC Receiver is not assigned!");
        }
    }

    private void OnSceneChangeReceived(OSCMessage message)
    {
        if (message.Address.Contains(oscAddress) && message.Values.Count > 0)
        {
            // Extract scene index from OSC message like "/scene/1"
            string[] parts = message.Address.Split('/');
            if (parts.Length > 2 && int.TryParse(parts[2], out int sceneIndex))
            {
                if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    Debug.Log($"Switching to Scene {sceneIndex}");
                    SceneManager.LoadScene(sceneIndex);
                }
                else
                {
                    Debug.LogWarning($"Invalid scene index received: {sceneIndex}");
                }
            }
        }
    }
}
