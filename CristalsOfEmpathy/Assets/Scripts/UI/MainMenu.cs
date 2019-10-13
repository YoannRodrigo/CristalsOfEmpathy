#region Using Directives

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