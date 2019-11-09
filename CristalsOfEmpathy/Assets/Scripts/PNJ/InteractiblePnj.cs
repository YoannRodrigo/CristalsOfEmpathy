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
            if(playerAnswers.Length == 0)
            {
                dialogueManager.StartDialogue(dialogues);
            }
            else
            {
                dialogueManager.StartDialogue(dialogues, playerAnswers);
            }
            dialogueBox.SetActive(true);
        }
    }
    #endregion
}
