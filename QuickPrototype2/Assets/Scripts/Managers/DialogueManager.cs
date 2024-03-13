using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string[] dialogueLines;
    public int currentLineIndex = 0;
    public TextMeshProUGUI textMeshProText;

    public void NextDialogue()
    {
        currentLineIndex = Mathf.Min(currentLineIndex + 1, dialogueLines.Length - 1);
        DisplayCurrentLine();
    }

    public void PreviousDialogue()
    {
        currentLineIndex = Mathf.Max(currentLineIndex - 1, 0);
        DisplayCurrentLine();
    }

    private void DisplayCurrentLine()
    {
        textMeshProText.text = dialogueLines[currentLineIndex];
    }
}