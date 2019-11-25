#region Using Directives

using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    #region Member Variables

    public DialogueManager dialogueManager;
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
        }
        else
        {
            dialogueManager.StartDialogue(dialogues, playerAnswers, startId);
        }
    }
    #endregion
}
