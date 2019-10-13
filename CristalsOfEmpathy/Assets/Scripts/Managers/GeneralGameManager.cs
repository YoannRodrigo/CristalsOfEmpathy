#region Using Directives

using UnityEngine;

#endregion

public class GeneralGameManager : MonoBehaviour
{
    #region Member Variables

    private static GameObject _playerPrefab;

    #endregion

    #region Methods

    public void SetPlayerPrefab(GameObject playerPrefab)
    {
        _playerPrefab = playerPrefab;
    }

    #endregion
}