#region Using Directives
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

public class CuriosityEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables
    public LevelChanger levelChanger;
    public RunesCounter runesCounter;
    public GameObject defeatScreen;
    public GameObject confirmationScreen;

    #endregion

    #region Methods

    private void Start()
    {
        Time.timeScale = 1;
        LevelChanger.instance.FadeOut();
    }
    public void LeaveButtonOnClick()
    {
        confirmationScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void GiveUpNoButtonOnClick()
    {
        confirmationScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GiveUpYesButtonOnClick()
    {
        confirmationScreen.SetActive(false);
        defeatScreen.SetActive(true);

        Time.timeScale = 1;
        StartCoroutine("WaitToReturnEnigma");

    }


    public IEnumerator WaitToReturnMenu()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade("CreditScene");
    }

    public IEnumerator WaitToReturnEnigma()
    {
        yield return new WaitForSeconds(2);
        LevelChanger.instance.ChangeToLevelWithFade("GuardianScreen");
    }

    public void StartWaitToReturnCoroutine()
    {
        if (runesCounter.runesCount == 6)
        {
            Debug.Log("Entering coroutine");
            StartCoroutine("WaitToReturnMenu");
        }
    }
    #endregion
}
