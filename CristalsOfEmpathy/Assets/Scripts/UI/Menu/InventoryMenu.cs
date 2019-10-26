#region Using Directives
using UnityEngine;
#endregion

public class InventoryMenu : MonoBehaviour
{
    #region Member Variables
    private bool isOpen;
    public GameObject inventoryMenu;
    public GameObject pauseButton;
    public GameObject joystick;
    #endregion

    #region Properties
    public bool IsOpen => isOpen;
    #endregion

    #region Methods

    public void InventoryButtonOnClick()
    {
        if (!isOpen)
        {
            PauseMenu.SetPause(true);
            inventoryMenu.SetActive(true);
            pauseButton.SetActive(false);
            joystick.SetActive(false);
            isOpen = true;
        }
        else
        {
            PauseMenu.SetPause(false);
            inventoryMenu.SetActive(false);
            pauseButton.SetActive(true);
            joystick.SetActive(true);
            isOpen = false;
        }
    }

    #endregion
}
