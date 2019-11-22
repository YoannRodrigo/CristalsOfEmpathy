#region Using Directives

using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    #region Member Variables

    public DialogueManager dialogueManager;
    public DialogueGuardian dialogueGuardian;
    public Dialogue[] dialogues;
    public PlayerAnswers[] playerAnswers;

    public GameObject dialogueBox;
    #endregion
    
    #region Methods
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
        if(playerAnswers.Length == 0)
        {
            dialogueManager.StartDialogue(dialogues, startId);
            dialogueGuardian.StartDialogueGuardian(dialogues, startId);
        }
        else
        {
            dialogueManager.StartDialogue(dialogues, playerAnswers, startId);
            dialogueGuardian.StartDialogueGuardian(dialogues, playerAnswers, startId);
        }

        dialogueBox.SetActive(true); 
    }
    #endregion
}
