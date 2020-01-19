#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class MainMenu : MonoBehaviour
{
    #region Member Variables

    public Button playButton;
    public Button optionsButton;
    public Button backButton;

    public GameObject playerSubMenu;
    public GameObject optionsSubMenu;
    public GameObject mainMenu;

    #endregion

    #region Methods

    public void PlayGameOnClick()
    {
        if (playButton)
        {
            mainMenu.gameObject.SetActive(false);
            playerSubMenu.gameObject.SetActive(true);
        }
    }

    public void OptionsGameOnClick()
    {
        if (optionsButton)
        {
            mainMenu.gameObject.SetActive(false);
            optionsSubMenu.gameObject.SetActive(true);
        }
    }

    public void BackOptionsOnClick()
    {
        if (backButton)
        {
            optionsSubMenu.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void QuitGameOnClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    #endregion
}