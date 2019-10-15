#region Using Directives

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class PauseMenu : MonoBehaviour
{
    #region Member Variables

    public GameObject pauseMenu;
    public GameObject optionsSubMenu;
    public GameObject joystickButton;

    public Button pauseButton;
    public Button backButton;
    public Button optionsButton;
    public Button menuButton;
    public Button backOptionsSubMenuOptions;

    #endregion

    #region Methods
    public void PauseButtonOnClick()
    {
        pauseMenu.gameObject.SetActive(true);
        joystickButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void BackToGameOnClick()
    {
        pauseMenu.gameObject.SetActive(false);
        joystickButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void OptionsGameOnClick()
    {
        pauseMenu.gameObject.SetActive(false);
        optionsSubMenu.gameObject.SetActive(true);
    }

    public void BackToMenuOnClick()
    {
        pauseMenu.gameObject.SetActive(true);
        optionsSubMenu.gameObject.SetActive(false);
    }

    public void MenuGameOnClick()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
