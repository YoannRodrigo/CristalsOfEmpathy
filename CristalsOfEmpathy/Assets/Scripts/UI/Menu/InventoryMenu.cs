#region Using Directives

using UnityEngine;

#endregion

public class InventoryMenu : MonoBehaviour
{
    #region Properties

    public bool IsOpen { get; private set; }

    #endregion

    #region Methods

    public void InventoryButtonOnClick()
    {
        if (!IsOpen)
        {
            PauseMenu.SetPause(true);
            inventoryMenu.SetActive(true);
            pauseButton.SetActive(false);
            joystick.SetActive(false);
            IsOpen = true;
        }
        else
        {
            PauseMenu.SetPause(false);
            inventoryMenu.SetActive(false);
            pauseButton.SetActive(true);
            joystick.SetActive(true);
            IsOpen = false;
        }
    }

    #endregion

    #region Member Variables

    public GameObject inventoryMenu;
    public GameObject pauseButton;
    public GameObject joystick;

    #endregion
}