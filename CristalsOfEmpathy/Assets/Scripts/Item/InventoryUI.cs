#region Using Directives
using UnityEngine;
#endregion
public class InventoryUI : MonoBehaviour
{
    #region Member Variables
    public Transform itemsParent;

    private Inventory inventory;
    private InventorySlot[] slots;
    #endregion

    #region Methods
    private void Start()
    {
        inventory = Inventory.inventoryInstance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
        }
    }
    #endregion
}
