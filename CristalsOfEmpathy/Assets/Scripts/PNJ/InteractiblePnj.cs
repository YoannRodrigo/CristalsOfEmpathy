#region Using Directives

using System;
using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    #region Member Variables

    public DialogueManager dialogueManager;
    public ScriptablePNJ scriptablePnj;

    #endregion

    #region Methods

    private void Start()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }
    }

    protected override void OnTouch()
    {
        if (canBeTouch)
        {
            Debug.Log("Interacting with a PNJ...");
            StartDialogue();
        }
    }

    public void StartDialogue(int startId = 0)
    {
        dialogueManager.SetInteractiblePnj(this);
        dialogueManager.currentPNJ = scriptablePnj;
        if (scriptablePnj.playerAnswers.Length == 0)
            dialogueManager.StartDialogue(scriptablePnj.dialogues, startId);
        else
            dialogueManager.StartDialogue(scriptablePnj.dialogues, scriptablePnj.playerAnswers, startId);
    }

    public virtual void OnDialogEnded()
    {
    }

    #endregion
}