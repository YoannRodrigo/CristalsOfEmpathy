#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public void Awake()
    {
        if(instance == null)
        {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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