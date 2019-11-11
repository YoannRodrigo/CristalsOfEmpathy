#region Using Directives
using UnityEngine;
#endregion

public class InteractibleObject : InteractibleItem
{
    #region Member Variables
    public DialogueManager dialogueManager;
    public GameObject collectibleItem;
    public Item item;
    #endregion

    #region Methods
    protected override void OnTouch()
    {
        Debug.Log(canBeTouch ? "Touch" : "Too far");
        Debug.Log("Picking up" + item.name);

        if (canBeTouch && collectibleItem.tag != "Berlingots")
        {
            bool wasPickedUp = Inventory.inventoryInstance.Add(item);
            if (wasPickedUp)
            {
                Destroy(collectibleItem);
            }
        }

        // BERLINGOTS HANDLING

        if (canBeTouch && collectibleItem.tag == "Berlingots" && dialogueManager.isQuestActivated)
        {
            bool wasPickedUp = Inventory.inventoryInstance.Add(item);
            int inventorySpace = Inventory.inventoryInstance.items.Count;

            if (wasPickedUp)
            {
                Destroy(collectibleItem);
                Debug.Log(inventorySpace);

                // INVENTORY SPACE IS 6 SO 6 BERLINGOTS PICKED UP
                if(inventorySpace == 6)
                {
                    Debug.Log("Quest finished");
                    dialogueManager.isQuestAchieved = true;
                }
            }
        }
        
        else if (!dialogueManager.isQuestActivated)
        {
            Debug.Log("QUEST AIN'T ACCEPTED");
        }
    }
    #endregion
}
