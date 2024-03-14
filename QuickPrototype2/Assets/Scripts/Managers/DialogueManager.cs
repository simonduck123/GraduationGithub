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

    private Coroutine typingCoroutine;

    private void Start()
    {
        NextDialogue();
    }

    public void NextDialogue()
    {
        currentLineIndex = Mathf.Min(currentLineIndex + 1, dialogueLines.Length - 1);
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        DisplayCurrentLine();
    }

    public void PreviousDialogue()
    {
        currentLineIndex = Mathf.Max(currentLineIndex - 1, 0);
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        DisplayCurrentLine();
    }

    public void ShowDialogue()
    {
        this.gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        this.gameObject.SetActive(false);
    }

    private void DisplayCurrentLine()
    {
        writer = dialogueLines[currentLineIndex];
        _tmpProText.text = "";

        typingCoroutine = StartCoroutine("TypeWriterTMP");
    }

    IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        for (int i = 0; i < writer.Length; i++)
        {
            if (i < writer.Length - 1 && Input.GetKeyDown(KeyCode.Space)) 
            {
                _tmpProText.text += writer.Substring(i);
                break;
            }

            if (_tmpProText.text.Length > 0)
            {
                _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            }
            _tmpProText.text += writer[i];
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
}
