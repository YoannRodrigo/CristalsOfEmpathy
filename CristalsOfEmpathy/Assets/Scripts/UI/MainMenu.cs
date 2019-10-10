#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class MainMenu : MonoBehaviour
{
    #region Member Variables

    #endregion

    #region Methods
    public void PlayGameOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGameOnClick()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OptionsGameOnClick()
    {

    }

    #endregion
}
