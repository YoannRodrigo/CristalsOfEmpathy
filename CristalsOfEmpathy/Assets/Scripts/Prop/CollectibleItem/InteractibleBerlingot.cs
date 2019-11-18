#region Using Directives
using UnityEngine;
#endregion

public class InteractibleBerlingot : InteractibleItem
{
    #region Member Variables
    public GameObject berlingotItem;
    public Item item;

    private bool isQuestActivated;
    #endregion

    #region Methods

    public void ActivateQuest()
    {
        isQuestActivated = true;
    }
    protected override void OnTouch()
    {
        // BERLINGOTS HANDLING

        if (canBeTouch && berlingotItem.CompareTag("Berlingots") && isQuestActivated)
        {
            bool wasPickedUp = Inventory.inventoryInstance.Add(item);

            if (wasPickedUp)
            {
                Destroy(berlingotItem.gameObject);
            }
        }
        else if (!isQuestActivated)
        {
            Debug.Log("QUEST AIN'T ACCEPTED");
        }
    }

    #endregion
}
