#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
#endregion

public class AversionEnigmaMenuManager : MonoBehaviour
{
    #region Member Variables

    public Transform spawnerTransform;
    public GameObject tomatoPrefab;
    public GameObject waterCanonPrefab;
    public TextMeshProUGUI scoreText;
    public GameObject victoryScreen;
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

    public void UpdateScore(float pointToAdd)
    {
        currentScore += pointToAdd;
        scoreText.text = "" + currentScore;
    }
    
    public GameState GetGameState()
    {
        return gameState;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.TOMATO :
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
            default:
                break;
        }
    }

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

    public void GiveUpYesButtonOnClick()
    {
        victoryScreen.SetActive(true);
        StartCoroutine(waitToReturn());
    }

    public void TomatoButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded,true);
        enigmaAnimator.SetBool(isWaterNeeded, false);
        gameState = GameState.TOMATO;
    }
    
    public void WaterButtonOnClick()
    {
        enigmaAnimator.SetBool(isTomatoNeeded,false);
        enigmaAnimator.SetBool(isWaterNeeded, true);
        gameState = GameState.WATER;
    }

    private IEnumerator waitToReturn()
    {
        yield return new WaitForSeconds(2);
        levelChanger.ChangeToLevelWithFade(0);
    }
    
    #endregion
}
