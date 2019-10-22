#region Using Directives
using UnityEngine;
#endregion

public class InteractibleObject : InteractibleItem
{
    #region Member Variables
    public GameObject collectibleItem;
    public Item item;
    #endregion

    #region Methods

    protected override void OnTouch()
    {
        Debug.Log(canBeTouch ? "Touch" : "Too far");
        Debug.Log("Picking up" + item.name);

        if (canBeTouch)
        {
            bool wasPickedUp = Inventory.inventoryInstance.Add(item);
            if (wasPickedUp)
            {
                Destroy(collectibleItem);
            }
        }
    }
    #endregion
}
