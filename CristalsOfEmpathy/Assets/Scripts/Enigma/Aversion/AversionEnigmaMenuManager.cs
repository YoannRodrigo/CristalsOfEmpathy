#region Using Directives
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class AversionEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables
    public Image backDialogsImage;
    public Image backYesImage;
    public Image backNoImage;

    public Button backYesButton;
    public Button backNoButton;

    public Button arrowButton;

    public GameObject tomatoWindow;
    public GameObject pipeWindow;
    public GameObject backWindow;

    public Animator aversionEnigmaAnimatorLeave;
    public Animator aversionEnigmaAnimatorIndication;

    private static readonly int toLeaveWindow = Animator.StringToHash("ToLeaveWindow");
    private static readonly int toIndicationWindow = Animator.StringToHash("ToIndicationWindow");
    #endregion

    #region Methods
    public void BackButtonOnClick()
    {
        //backWindow.SetActive(true);
        aversionEnigmaAnimatorLeave.SetBool(toLeaveWindow, true);
        Debug.Log("BB Clicked");
    }

    public void BackYesButtonOnClick()
    {
        //Application.Quit();

        Debug.Log("BB Y Clicked");
    }

    public void BackNoButtonOnClick()
    {
        //backWindow.SetActive(false);

        aversionEnigmaAnimatorLeave.SetBool(toLeaveWindow, false);
        Debug.Log("BB N Clicked");
    }

    public void ArrowButtonOnClick()
    {
        aversionEnigmaAnimatorIndication.SetBool(toIndicationWindow, false);
        Debug.Log("Arrow Clicked");
    }
    #endregion
}
