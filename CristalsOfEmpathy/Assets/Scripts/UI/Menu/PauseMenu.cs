#region Using Directives

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class PauseMenu : MonoBehaviour
{
    #region Member Variables

    public GameObject pauseMenu;
    public GameObject optionsSubMenu;
    public GameObject inventoryButtonGameObject;
    public GameObject joystickButton;
    public GameObject inventoryMenu;

    public Button pauseButton;

    #endregion

    #region Methods
    public void PauseButtonOnClick()
    {
        pauseMenu.SetActive(true);
        joystickButton.SetActive(false);
        inventoryMenu.SetActive(false);
        inventoryButtonGameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void BackToGameOnClick()
    {
        pauseMenu.SetActive(false);
        joystickButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        inventoryButtonGameObject.SetActive(true);
        if (inventoryButtonGameObject.GetComponent<InventoryMenu>().IsOpen)
        {
            inventoryMenu.SetActive(true);
        }
        Time.timeScale = 1;
    }

    public void OptionsGameOnClick()
    {
        pauseMenu.SetActive(false);
        optionsSubMenu.gameObject.SetActive(true);
    }

    public void BackToMenuOnClick()
    {
        pauseMenu.SetActive(true);
        optionsSubMenu.gameObject.SetActive(false);
    }

    public void MenuGameOnClick()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
