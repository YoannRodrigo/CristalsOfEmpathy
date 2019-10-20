#region Using Directives

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#endregion


public class InventoryMenu : MonoBehaviour
{
    #region Member Variables

    public GameObject inventoryMenu;

    public Button inventoryButton;

    private bool isOpen = false;

    #endregion

    #region Methods

    public void InventoryButtonOnClick()
    {
        if (!isOpen)
        {
            inventoryMenu.SetActive(true);
            isOpen = true;
        }
        else
        {
            inventoryMenu.SetActive(false);
            isOpen = false;
        }

    }

    #endregion

}
