using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public string[] dialogueLines;
    private int currentLineIndex = 0;

    public TMP_Text _tmpProText;
    string writer;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;

    private void Start()
    {
        NextDialogue();
    }

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
        writer = dialogueLines[currentLineIndex];
        _tmpProText.text = "";

        StartCoroutine("TypeWriterTMP");
    }

    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += c;
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
}