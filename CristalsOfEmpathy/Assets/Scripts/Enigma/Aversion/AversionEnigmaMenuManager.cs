#region Using Directives
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class AversionEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables

    public Animator enigmaAnimator;
    private static readonly int isGiveUpWindowsNeeded = Animator.StringToHash("isGiveUpWindowsNeeded");
    private static readonly int isTipsWindowsNeeded = Animator.StringToHash("isTipsWindowsNeeded");
    private static readonly int isWaterNeeded = Animator.StringToHash("isWaterNeeded");
    private static readonly int isTomatoNeeded = Animator.StringToHash("isTomatoNeeded");

    #endregion

    #region Methods
    public void GiveUpButtonOnClick()
    {
        enigmaAnimator.SetBool(isGiveUpWindowsNeeded,true);
    }

    public void TipsButtonOnClick()
    {
        enigmaAnimator.SetBool(isTipsWindowsNeeded, true);
    }

    public void TipsBackButtonOnClick()
    {
        enigmaAnimator.SetBool(isTipsWindowsNeeded,false);
    }

    public void GiveUpNoButtonOnClick()
    {
        enigmaAnimator.SetBool(isGiveUpWindowsNeeded,false);
    }

    public void TomatoButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded,true);
        enigmaAnimator.SetBool(isWaterNeeded, false);
    }
    
    public void WaterButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded,false);
        enigmaAnimator.SetBool(isWaterNeeded, true);
    }
    
    #endregion
}
