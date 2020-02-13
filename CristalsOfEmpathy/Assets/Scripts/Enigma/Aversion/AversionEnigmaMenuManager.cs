#region Using Directives

using System.Collections;
using TMPro;
using UnityEngine;

#endregion

public class AversionEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables

    public Transform spawnerTransform;
    public GameObject tomatoPrefab;
    public GameObject waterCanonPrefab;
    public TextMeshProUGUI scoreText;
    public GameObject victoryScreen;
    public GameObject loseScreen;
    public Animator enigmaAnimator;
    public LevelChanger levelChanger;
    private static readonly int isGiveUpWindowsNeeded = Animator.StringToHash("isGiveUpWindowsNeeded");
    private static readonly int isTipsWindowsNeeded = Animator.StringToHash("isTipsWindowsNeeded");
    private static readonly int isWaterNeeded = Animator.StringToHash("isWaterNeeded");
    private static readonly int isTomatoNeeded = Animator.StringToHash("isTomatoNeeded");

    private float currentScore;
    private GameObject currentTomato;

    public enum GameState
    {
        TOMATO,
        WATER
    }

    private GameState gameState = GameState.TOMATO;

    #endregion

    #region Methods

    private void Start()
    {
        AkSoundEngine.PostEvent("StartAversionMusic", gameObject);
        LevelChanger.instance.FadeOut();
    }
    public void UpdateScore(float pointToAdd)
    {
        currentScore -= pointToAdd;
        scoreText.text = "" + currentScore;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    private void Update()
    {
        if (currentScore <= -1500)
        {
            loseScreen.SetActive(true);
            StartCoroutine(WaitToReturnAversionEnigma());
        }
        switch (gameState)
        {
            case GameState.TOMATO:
                if (!currentTomato)
                {
                    currentTomato = Instantiate(tomatoPrefab, spawnerTransform);
                }
                waterCanonPrefab.SetActive(false);
                break;
            case GameState.WATER:
                if (currentTomato)
                {
                    Destroy(currentTomato);
                }
                waterCanonPrefab.SetActive(true);
                break;
        }
    }

    public void GiveUpButtonOnClick()
    {
        enigmaAnimator.SetBool(isGiveUpWindowsNeeded, true);
    }

    public void TipsButtonOnClick()
    {
        enigmaAnimator.SetBool(isTipsWindowsNeeded, true);
    }

    public void TipsBackButtonOnClick()
    {
        enigmaAnimator.SetBool(isTipsWindowsNeeded, false);
    }

    public void GiveUpNoButtonOnClick()
    {
        enigmaAnimator.SetBool(isGiveUpWindowsNeeded, false);
    }

    public void GiveUpYesButtonOnClick()
    {
        victoryScreen.SetActive(true);
        StartCoroutine(WaitToReturn());
    }

    public void TomatoButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded, true);
        enigmaAnimator.SetBool(isWaterNeeded, false);
        gameState = GameState.TOMATO;
    }

    public void WaterButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded, false);
        enigmaAnimator.SetBool(isWaterNeeded, true);
        gameState = GameState.WATER;
    }

    private IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }

    private IEnumerator WaitToReturnAversionEnigma()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(5);
    }

    #endregion
}