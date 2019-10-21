#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class PauseMenu : MonoBehaviour
{
    #region Member Variables

    private const int MAIN_MENU_SCENE_ID = 0;
    
    public GameObject pauseMenu;
    public GameObject optionsSubMenu;
    public GameObject inventoryButtonGameObject;
    public GameObject joystickButton;
    public GameObject inventoryMenu;
    public LevelChanger levelChanger;
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
        levelChanger.ChangeToLevelWithFade(MAIN_MENU_SCENE_ID);
    }

    #endregion
}
