#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class InventorySlot : MonoBehaviour
{
    #region Methods

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    #endregion

    #region Member Variables

    public Image icon;
    private Item item;

    #endregion
}