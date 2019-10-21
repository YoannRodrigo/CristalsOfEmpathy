#region Using Directives

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class PlayerChoiceManager : MonoBehaviour
{
    #region Member Variables

    private const int SPLASHSCREEN_ID = 1;
    
    private PlayerChoice playerChoice = PlayerChoice.NONE;
    
    public List<GameObject> playerPrefabs = new List<GameObject>();
    public GeneralGameManager generalGameManager;
    public Button validateButton;
    public LevelChanger levelChanger;

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
        playerChoice = PlayerChoice.PLAYER_A;
        validateButton.gameObject.SetActive(true);
    }

    public void PlayerBOnClick()
    {
        playerChoice = PlayerChoice.PLAYER_B;
        validateButton.gameObject.SetActive(true);
    }

    public void PlayerCOnClick()
    {
        playerChoice = PlayerChoice.PLAYER_C;
        validateButton.gameObject.SetActive(true);
    }

    public void ValidateOnClick()
    {
        generalGameManager.SetPlayerPrefab(playerPrefabs[(int) playerChoice]);
        levelChanger.ChangeToLevelWithFade(SPLASHSCREEN_ID);
    }

    #endregion
}