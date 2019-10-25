#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class DialogueManager : MonoBehaviour
{
    #region Member Variables
    public Text pnjNameText;
    public Text dialogueText;

    public GameObject dialogueBox;

    private Queue<string> sentences;
    #endregion

    #region Methods
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        pnjNameText.text = dialogue.pnjName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    #endregion
}