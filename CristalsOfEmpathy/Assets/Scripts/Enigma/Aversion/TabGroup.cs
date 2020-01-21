#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class TabGroup : MonoBehaviour
{
    #region Member Variables

    public List<TabButton> tabButtons;

    public GameObject TomatoWindow;

    public GameObject PipeWindow;
    //public GameObject IndicationWindow;

    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    public TabButton selectedTab;

    public Animator aversionEnigmaAnimator;

    private static readonly int toIndicationWindow = Animator.StringToHash("ToIndicationWindow");

    #endregion

    #region Methods

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null) tabButtons = new List<TabButton>();

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab) button.background.sprite = tabHover;
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;

        switch (button.name)
        {
            case "TabTomatoButton":
                TomatoWindow.SetActive(true);
                PipeWindow.SetActive(false);
                break;

            case "TabPipeButton":
                PipeWindow.SetActive(true);
                TomatoWindow.SetActive(false);
                break;

            case "TabIndicationButton":
                aversionEnigmaAnimator.SetBool(toIndicationWindow, true);
                break;
        }

        //int index = button.transform.GetSiblingIndex();
        //for (int i = 0; i < windowToSwap.Count; i++)
        //{
        //    if (i == index)
        //    {
        //        windowToSwap[i].SetActive(true);
        //    }

        //    else
        //    {
        //        windowToSwap[i].SetActive(false);
        //    }
        //}
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) continue;
            button.background.sprite = tabIdle;
        }
    }

    #endregion
}