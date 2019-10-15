#region Using Directives

using System;
using UnityEngine;

#endregion

public class GeneralGameManager : MonoBehaviour
{
    #region Member Variables

    public Transform playerSpawnerTransform;
    
    private static GameObject _playerPrefab;

    #endregion

    #region Methods

    public void SetPlayerPrefab(GameObject playerPrefab)
    {
        _playerPrefab = playerPrefab;
    }

    private void Start()
    {
        Time.timeScale = 1;
        if (playerSpawnerTransform != null && _playerPrefab != null)
        {
            Instantiate(_playerPrefab, playerSpawnerTransform.position, playerSpawnerTransform.rotation);
        }
    }

    #endregion
}