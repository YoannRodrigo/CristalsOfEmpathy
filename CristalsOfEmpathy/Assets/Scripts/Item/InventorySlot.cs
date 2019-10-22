#region Using Directives
using UnityEngine;
using UnityEngine.UI;
#endregion

public class InventorySlot : MonoBehaviour
{
    #region Member Variables
    public Image icon;
    private Item item;
    #endregion

    #region Methods
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    #endregion
}
