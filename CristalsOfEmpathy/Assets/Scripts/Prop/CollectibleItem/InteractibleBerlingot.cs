#region Using Directives
using UnityEngine;
#endregion

public class InteractibleBerlingot : InteractibleItem
{
    #region Member Variables
    public TutorialManager tutorialManager;
    public DialogueManager dialogueManager;

    public GameObject berlingotItem;
    public Item item;
    #endregion

    #region Methods
    protected override void OnTouch()
    {
        // BERLINGOTS HANDLING

        if (canBeTouch && berlingotItem.tag == "Berlingots" && tutorialManager.isQuestActivated)
        {
            bool wasPickedUp = Inventory.inventoryInstance.Add(item);

            if (wasPickedUp)
            {
                Destroy(berlingotItem.gameObject);
                tutorialManager.BerlingotListRemover();

                if (tutorialManager.berlingotsList.Count == 1)
                {
                    tutorialManager.TutorialQuestCompleted();
                }
            }
        }

        else if (!tutorialManager.isQuestActivated)
        {
            Debug.Log("QUEST AIN'T ACCEPTED");
        }
    }

    #endregion
}
