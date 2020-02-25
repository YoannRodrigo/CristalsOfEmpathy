#region Using Directives

using System.Collections.Generic;
using UnityEngine;

#endregion

public class PlayerChoiceManager : MonoBehaviour
{
    #region Member Variables
    private const int SPLASHSCREEN_ID = 1;
    private PlayerChoice playerChoice = PlayerChoice.NONE;

    #endregion

    #region Methods

    private enum PlayerChoice
    {
        PLAYER_A,
        PLAYER_B,
        PLAYER_C,
        NONE
    }

    public void PlayerAOnClick()
    {
        if (playerChoice != PlayerChoice.PLAYER_A)
            playerChoice = PlayerChoice.PLAYER_A;
        else
            ValidateOnClick();
    }

    public void PlayerBOnClick()
    {
        if (playerChoice != PlayerChoice.PLAYER_B)
            playerChoice = PlayerChoice.PLAYER_B;
        else
            ValidateOnClick();
    }

    public void PlayerCOnClick()
    {
        if (playerChoice != PlayerChoice.PLAYER_C)
            playerChoice = PlayerChoice.PLAYER_C;
        else
            ValidateOnClick();
    }

    private void ValidateOnClick()
    {
        GeneralGameManager.instance.SetPlayerPrefab((int) playerChoice);
        LevelChanger.instance.ChangeToLevelWithFade(SPLASHSCREEN_ID);
    }

    public void LoveEnigmaOnClick()
    {
		LevelChanger.instance.ChangeToLevelWithFade(4);
    }

    public void AversionEnigmaOnClick()
    {
		LevelChanger.instance.ChangeToLevelWithFade(5);
    }

    public void FearEnigmaOnClick()
    {
		LevelChanger.instance.ChangeToLevelWithFade(6);
    }

    public void CuriosityEnigmaOnClick()
    {
		LevelChanger.instance.ChangeToLevelWithFade(7);
    }

    #endregion
}