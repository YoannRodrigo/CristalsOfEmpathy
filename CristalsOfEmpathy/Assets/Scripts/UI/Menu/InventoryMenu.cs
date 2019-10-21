#region Using Directives

using UnityEngine;

#endregion


public class InventoryMenu : MonoBehaviour
{
    #region Member Variables

    public GameObject inventoryMenu;

    //public Button inventoryButton;

    private bool isOpen;

    public bool IsOpen => isOpen;

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
