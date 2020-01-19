#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class InventoryUI : MonoBehaviour
{
    #region Member Variables

    private Inventory inventory;
    public List<InventorySlot> slots = new List<InventorySlot>();

    #endregion

    #region Methods

    private void Start()
    {
        inventory = Inventory.inventoryInstance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    private void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Count; i++)
            if (i < inventory.items.Count)
                slots[i].AddItem(inventory.items[i]);
    }

    #endregion
}