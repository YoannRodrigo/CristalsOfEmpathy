#region Using Directives

using UnityEngine;

#endregion

public class InteractibleObject : InteractibleItem
{
    #region Methods

    protected override void OnTouch()
    {
        Debug.Log(canBeTouch ? "Touch" : "Too far");
        Debug.Log("Picking up" + item.name);

        if (canBeTouch && collectibleItem.tag != "Berlingots")
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp) Destroy(collectibleItem);
        }
    }

    #endregion

    #region Member Variables

    public GameObject collectibleItem;
    public Item item;

    #endregion
}