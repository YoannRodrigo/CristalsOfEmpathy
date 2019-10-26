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
    public bool canBeDesativate;
    public bool canActivateOption;
    private bool isActivateForOption;

    #endregion

    #region Methods

    private void OnEnable()
    {
        if(!isActivateForOption)
        {
            isActivateForOption = true;
        }
    }

    private void Update()
    {
        if (canBeDesativate)
        {
            if (canActivateOption)
            {
                canActivateOption = false;
                optionsSubMenu.SetActive(true);
            }
            isActivateForOption = false;
            canBeDesativate = false;
            gameObject.SetActive(false);
        }
    }

    public void PauseButtonOnClick()
    {
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<PauseAnimatorController>().SlideUiIn();
        joystickButton.SetActive(false);
        inventoryMenu.SetActive(false);
        inventoryButtonGameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void BackToGameOnClick()
    {
        pauseMenu.GetComponent<PauseAnimatorController>().SlideUiOut();
        joystickButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        inventoryButtonGameObject.SetActive(true);
        if (inventoryButtonGameObject.GetComponent<InventoryMenu>().IsOpen)
        {
            inventoryMenu.SetActive(true);
        }
    }

    public void OptionsGameOnClick()
    {
        pauseMenu.GetComponent<PauseAnimatorController>().SlideToOption();
    }

    public void BackToMenuOnClick()
    {
        optionsSubMenu.GetComponent<OptionAnimatorController>().SlideUiOut();
    }

    public void MenuGameOnClick()
    {
        levelChanger.ChangeToLevelWithFade(MAIN_MENU_SCENE_ID);
    }

    #endregion
}
