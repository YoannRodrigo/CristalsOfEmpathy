#region Using Directives

using UnityEngine;

#endregion

public class InteractiblePnj : InteractibleItem
{
    #region Member Variables
    public Dialogue dialogue;

    public GameObject dialogueBox;
    #endregion
    
    #region Methods
    protected override void OnTouch()
    {
        if (canBeTouch)
        {
            Debug.Log("Interacting with a PNJ...");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            dialogueBox.SetActive(true);
        }
    }
    #endregion
}
