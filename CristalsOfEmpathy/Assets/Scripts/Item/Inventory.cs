#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory inventoryInstance;

    #endregion

    #region Member Variables

    public int inventorySpace = 20;
    public List<Item> items = new List<Item>();

    #endregion

    #region Events

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    #endregion

    #region Methods

    private void Awake()
    {
        if (inventoryInstance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        inventoryInstance = this;
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Not enough space.");
                return false;
            }

            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    #endregion
}